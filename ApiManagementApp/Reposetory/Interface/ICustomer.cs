using ApiManagementApp.ViewMode;
using Management;
using Microsoft.AspNetCore.Mvc;


namespace ApiManagementApp.Reposetory.Interface
{
    public interface ICustomer
    {
        public Task<List<Customer>> GetAllCustomers();
        public Task<Customer?> GetCustomersById(int id);
        public Task<List<Customer?>> CreateCustomerById(CustomerWithOutId carWithOutId);
        public Task<Customer?> DeleteCustomerBy(int id);
        public Task<Customer?> UpdateCustomerBy(int id, Customer car);
    }
}
