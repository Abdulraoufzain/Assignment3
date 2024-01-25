using ApiManagementApp.ViewMode;
using Management;

namespace ApiManagementApp.Reposetory.Interface
{
    public interface IPart
    {
        public Task<List<Part>> GetAllParts();
        public Task<Part?> GetPartsById(int id);
        public Task<List<Part?>> CreatePartById(PartWithOutId carWithOutId);
        public Task<Part?> DeletePartBy(int id);
        public Task<Part?> UpdatePartBy(int id, Part car);
    }
}
