using ApiManagementApp.ViewMode;
using Management;
using Microsoft.AspNetCore.Mvc;

namespace ApiManagementApp.Reposetory.Interface
{
    public interface ICar
    {

        public Task<List<Car>> GetAllCars();
        public Task<Car?> GetCarsById(int id);
        public Task<List<Car?>> CreateCarById(CarWithOutId carWithOutId);
        public Task<Car?> DeleteCarBy(int id);
        public Task<Car?> UpdateCarBy(int id , Car car);
        
    }
}
