using ApiManagementApp.MDmContext;
using ApiManagementApp.Reposetory.Interface;
using ApiManagementApp.ViewMode;
using Management;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiManagementApp.Reposetory.Clases
{
    public class CustomerRepository : ICustomer
    {
        private ManagmentDbContexts _context;

        public CustomerRepository(ManagmentDbContexts contect)
        {
            this._context = contect;
        }


        public async Task<Customer?> DeleteCustomerBy(int id)
        {
            var result = await _context.Customers.FindAsync(id);
            if (result is null)
            {
                return null;
            }
            _context.Customers.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<Customer?>> CreateCustomerById(CustomerWithOutId CustomerWithOutId)
        {

            if (CustomerWithOutId is null)
            {
                return null;
            }
            int MaxId = _context.Customers.Max(c => c.Id);
            Customer customer = new Customer();
            customer.Id = ++MaxId;
            customer.Sales = CustomerWithOutId.Sales;
            customer.Age = CustomerWithOutId.Age;
            customer.Name = CustomerWithOutId.Name;
            customer.Address = CustomerWithOutId.Address;


            _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return await _context.Customers.ToListAsync();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var result = await _context.Customers.ToListAsync();
            return result;
        }

        public async Task<Customer?> GetCustomersById(int id)
        {
            return await _context.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Customer?> UpdateCustomerBy(int id, Customer Customer)
        {
            var result = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (result == null)
            {
                return null;
            }

            result.Id = id;
            result.Sales = Customer.Sales;
            result.Address = Customer.Address;
            result.Name = Customer.Name;

            await _context.SaveChangesAsync();

            return result;

        }
    }
}

