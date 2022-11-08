using System.Security.Claims;
using System.Threading.Tasks;
using CoalStore.Repositories.UnitOfWork;
using CoalStore.Services.IServices;
using CoalStore.Shared.Consts;
using CoalStore.Shared.Models.Authorization;

namespace CoalStore.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> IsPasswordValid(AuthorizationModel model)
        {
            string userPassword;
            if (model.Role == UserRole.Customer)
            {
                userPassword = (await _unitOfWork.Customer.GetCustomerByLogin(model.Login))?.Password;
            }
            else
            {
                userPassword = (await _unitOfWork.Supplier.GetSupplierByLogin(model.Login))?.Password;
            }

            return model.Password == userPassword;
        }

        public async Task CreateSession(AuthorizationModel model)
        {
            if (model.Role == UserRole.Customer)
            {
                var user = await _unitOfWork.Customer.GetCustomerByLogin(model.Login);
                user.SessionStart = DateTime.Now;
            }
            else
            {
                var user = await _unitOfWork.Supplier.GetSupplierByLogin(model.Login);
                user.SessionStart = DateTime.Now;
            }

            await _unitOfWork.Complete();
        }

        public async Task ClearSession(AuthorizationModel model)
        {
            if (model.Role == UserRole.Customer)
            {
                var user = await _unitOfWork.Customer.GetCustomerByLogin(model.Login);
                user.SessionStart = null;
            }
            else
            {
                var user = await _unitOfWork.Supplier.GetSupplierByLogin(model.Login);
                user.SessionStart = null;
            }

            await _unitOfWork.Complete();
        }

        public async Task<List<Claim>> GetUserClaims(AuthorizationModel model)
        {
            int userId;
            if (model.Role == UserRole.Customer)
            {
                var user = await _unitOfWork.Customer.GetCustomerByLogin(model.Login);
                userId = user.Id;
            }
            else
            {
                var user = await _unitOfWork.Supplier.GetSupplierByLogin(model.Login);
                userId = user.Id;
            }

            var claimsList = new List<Claim>();
            claimsList.Add(new Claim(Codes.ClaimTypes.Login, model.Login));
            claimsList.Add(new Claim(Codes.ClaimTypes.UserId, userId.ToString()));
            claimsList.Add(new Claim(Codes.ClaimTypes.Role, model.Role));

            return claimsList;
        }
    }
}
