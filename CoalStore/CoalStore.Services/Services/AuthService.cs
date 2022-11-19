using System.Security.Claims;
using CoalStore.DB.Models;
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
            await ClearSession(model.Login, model.Role);
            UserSession userSession;
            IUser user = await GetUserByLoginAndRole(model.Login, model.Role);
            userSession = new UserSession
            {
                UserId = user.Id,
                UserRole = model.Role,
                SessionStart = DateTime.Now,
            };
            await _unitOfWork.UserSession.AddAndComplete(userSession);
        }

        public async Task<int> GetSessionId(AuthorizationModel model)
        {
            IUser user = await GetUserByLoginAndRole(model.Login, model.Role);
            var sessionId = await _unitOfWork.UserSession.GetSessionIdByUserIdAndRole(user.Id, model.Role);
            return sessionId;
        }

        public async Task ClearSession(string login, string role)
        {
            IUser user = await GetUserByLoginAndRole(login, role);

            var userSession = await _unitOfWork.UserSession.GetByUserIdAndRole(user.Id, role);
            if ( userSession != null)
            {
                await _unitOfWork.UserSession.Remove(userSession);

                await _unitOfWork.Complete();
            }
        }

        public async Task<List<Claim>> GetUserClaims(AuthorizationModel model, int sessionId)
        {
            IUser user = await GetUserByLoginAndRole(model.Login, model.Role);
            var claimsList = new List<Claim>();
            claimsList.Add(new Claim(Codes.ClaimTypes.Login, model.Login));
            claimsList.Add(new Claim(Codes.ClaimTypes.UserId, user.Id.ToString()));
            claimsList.Add(new Claim(Codes.ClaimTypes.Role, model.Role));
            claimsList.Add(new Claim(Codes.ClaimTypes.SessionId, sessionId.ToString()));

            return claimsList;
        }

        private async Task<IUser> GetUserByLoginAndRole(string login, string role)
        {
            IUser user;
            if (role == UserRole.Customer)
            {
                user = await _unitOfWork.Customer.GetCustomerByLogin(login);
            }
            else
            {
                user = await _unitOfWork.Supplier.GetSupplierByLogin(login);
            }

            return user;
        }
    }
}
