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
    public class CarController : ControllerBase
    {
        private readonly ICar carReposetory;

        public CarController(ICar carReposetory)
        {
            this.carReposetory = carReposetory;
        }

        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetAllCars()
        {
           return await carReposetory.GetAllCars();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetById(int id)
        {
            var result = await carReposetory.GetCarsById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Car>>> CreateCar(CarWithOutId carWithOutId)
        {
            await carReposetory.CreateCarById(carWithOutId);
            return Ok(carReposetory.GetAllCars());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Car>> UpdateCar(int id,Car car)
        {
            var result = await carReposetory.UpdateCarBy(id,car);
            if(result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Car>>> DeleteCar(int id)
        {
            var result = await carReposetory.DeleteCarBy(id);
            return Ok(result);
        }
        
    }
}
