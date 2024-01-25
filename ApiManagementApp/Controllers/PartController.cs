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
    public class PartController : ControllerBase
    {
        private readonly IPart partReposetory;

        public PartController(IPart partReposetory)
        {
            this.partReposetory = partReposetory;
        }

        [HttpGet]
        public async Task<ActionResult<List<Part>>> GetAllParts()
        {
            return await partReposetory.GetAllParts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Part>> GetById(int id)
        {
            var result = await partReposetory.GetPartsById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Part>>> CreatePart(PartWithOutId carWithOutId)
        {
            await partReposetory.CreatePartById(carWithOutId);
            return Ok(partReposetory.GetAllParts());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Part>> UpdatePart(int id, Part car)
        {
            var result = await partReposetory.UpdatePartBy(id, car);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Part>>> DeletePart(int id)
        {
            var result = await partReposetory.DeletePartBy(id);
            return Ok(result);
        }

    }
}
