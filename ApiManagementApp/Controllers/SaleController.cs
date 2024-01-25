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
    public class SaleController : ControllerBase
    {
        private readonly ISale saleReposetory;

        public SaleController(ISale saleReposetory)
        {
            this.saleReposetory = saleReposetory;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sale>>> GetAllSales()
        {
            return await saleReposetory.GetAllSales();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetById(int id)
        {
            var result = await saleReposetory.GetSalesById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Sale>>> CreateSale(SaleWithOutId carWithOutId)
        {
            await saleReposetory.CreateSaleById(carWithOutId);
            return Ok(saleReposetory.GetAllSales());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Sale>> UpdateSale(int id, Sale car)
        {
            var result = await saleReposetory.UpdateSaleBy(id, car);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Sale>>> DeleteSale(int id)
        {
            var result = await saleReposetory.DeleteSaleBy(id);
            return Ok(result);
        }

    }
}
