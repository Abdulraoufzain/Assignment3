using ApiManagementApp.MDmContext;
using ApiManagementApp.Reposetory.Interface;
using ApiManagementApp.ViewMode;
using Management;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiManagementApp.Reposetory.Clases
{
    public class CarRepository : ICar
    {
        private ManagmentDbContexts _context;

        public CarRepository(ManagmentDbContexts contect )
        {
            this._context = contect;
        }


        public async Task<Car?> DeleteCarBy(int id)
        {
           var result = await _context.Cars.FindAsync(id);
            if(result is null )
            {
                return null;
            }
            _context.Cars.Remove( result );
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<Car?>> CreateCarById(CarWithOutId carWithOutId)
        {

            if(carWithOutId is null)
            {
                return null;
            }
            int MaxId = _context.Cars.Max(c => c.Id);
            Car car = new Car();
            car.Id = ++MaxId;
            car.KM = carWithOutId.KM;
            car.Sales = carWithOutId.Sales;
            car.Year = carWithOutId.Year;
            car.Gear = carWithOutId.Gear;
            car.Name = carWithOutId.Name;
            car.Model=carWithOutId.Model;
            car.KmKm = carWithOutId.KmKm;

            
            _context.Cars.AddAsync( car );
            await _context.SaveChangesAsync();
            return await _context.Cars.ToListAsync(); 
        }

        public async Task<List<Car>> GetAllCars()
        {
            var result = await _context.Cars.ToListAsync();
            return result;
        }

        public async Task<Car?> GetCarsById(int id)
        {
           return await _context.Cars.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Car?> UpdateCarBy(int id, Car car)
        {
            var result = await _context.Cars.FirstOrDefaultAsync(c=> c.Id == id);
            if(result == null)
            {
                return null;
            }

            result.Id= id;
            result.Sales = car.Sales;
            result.Year = car.Year;
            result.Gear = car.Gear;
            result.Name = car.Name;
            result.KM = car.KM;
            result.Model = car.Model;
            result.KmKm = car.KmKm;

            await _context.SaveChangesAsync();

            return result;

        }
    }
}

