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
    public class SupplierController : ControllerBase
    {
        private readonly ISupplier supplierReposetory;

        public SupplierController(ISupplier carReposetory)
        {
            this.supplierReposetory = supplierReposetory;
        }

        [HttpGet]
        public async Task<ActionResult<List<Supplier>>> GetAllSuppliers()
        {
            return await supplierReposetory.GetAllSuppliers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetById(int id)
        {
            var result = await supplierReposetory.GetSuppliersById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Supplier>>> CreateSupplier(SupplierWithOutId carWithOutId)
        {
            await supplierReposetory.CreateSupplierById(carWithOutId);
            return Ok(supplierReposetory.GetAllSuppliers());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Supplier>> UpdateSupplier(int id, Supplier car)
        {
            var result = await supplierReposetory.UpdateSupplierBy(id, car);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Supplier>>> DeleteSupplier(int id)
        {
            var result = await supplierReposetory.DeleteSupplierBy(id);
            return Ok(result);
        }

    }
}
