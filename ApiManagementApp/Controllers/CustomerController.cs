using ApiManagementApp.Reposetory.Clases;
using ApiManagementApp.Reposetory.Interface;
using ApiManagementApp.ViewMode;
using Management;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer customerReposetory;

        public CustomerController(ICustomer customerReposetory)
        {
            this.customerReposetory = customerReposetory;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            return await customerReposetory.GetAllCustomers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            var result = await customerReposetory.GetCustomersById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> CreateCustomer(CustomerWithOutId customerWithOutId)
        {
            await customerReposetory.CreateCustomerById(customerWithOutId);
            return Ok(customerReposetory.GetAllCustomers());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(int id, Customer customer)
        {
            var result = await customerReposetory.UpdateCustomerBy(id, customer);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id)
        {
            var result = await customerReposetory.DeleteCustomerBy(id);
            return Ok(result);
        }

    }
}
