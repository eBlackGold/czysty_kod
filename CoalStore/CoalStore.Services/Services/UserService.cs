using CoalStore.DB.Models;
using CoalStore.Repositories.UnitOfWork;
using CoalStore.Services.IServices;
using CoalStore.Shared.Consts;
using CoalStore.Shared.Models.User;

namespace CoalStore.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task RegisterUser(RegisterUserModel model, string userRole)
        {
            if (userRole == UserRole.Customer)
            {
                var customer = new Customer
                {
                    Login = model.Login,
                    Password = model.Password,
                };

                await _unitOfWork.Customer.AddAndComplete(customer);
            }
            else
            {
                var supplier = new Supplier
                {
                    Login = model.Login,
                    Password = model.Password,
                };

                await _unitOfWork.Supplier.AddAndComplete(supplier);
            }
        }

        public async Task EditUser(EditUserModel model, string userRole)
        {
            if (userRole == UserRole.Customer)
            {
                var customer = await _unitOfWork.Customer.GetCustomerByLogin(model.Login);
                UpdateCustomer(customer, (EditCustomerModel)model);
                await _unitOfWork.Customer.UpdateAndComplete(customer);
            }
            else
            {
                var supplier = await _unitOfWork.Supplier.GetSupplierByLogin(model.Login);
                UpdateSupplier(supplier, (EditSupplierModel)model);
                await _unitOfWork.Supplier.UpdateAndComplete(supplier);
            }
        }

        private void UpdateCustomer(Customer existingCustomer, EditCustomerModel model)
        {
            existingCustomer.Name = model.Name;
            existingCustomer.Surname = model.Surname;
            existingCustomer.Address = model.Address;
        }

        private void UpdateSupplier(Supplier existingSupplier, EditSupplierModel model)
        {
            existingSupplier.CompanyName = model.CompanyName;
            existingSupplier.Address = model.Address;
        }
    }
}
