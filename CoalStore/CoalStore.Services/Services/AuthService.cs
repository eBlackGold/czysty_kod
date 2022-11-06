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
    }
}
