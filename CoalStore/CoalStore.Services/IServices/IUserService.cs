using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoalStore.Shared.Models.Authorization;
using CoalStore.Shared.Models.User;

namespace CoalStore.Services.IServices
{
    public interface IUserService
    {
        Task RegisterUser(RegisterUserModel model, string userRole);

        Task EditUser(EditUserModel model, string userRole);
    }
}
