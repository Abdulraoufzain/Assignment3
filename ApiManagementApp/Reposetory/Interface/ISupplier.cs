using ApiManagementApp.ViewMode;
using Management;

namespace ApiManagementApp.Reposetory.Interface
{
    public interface ISupplier
    {
        public Task<List<Supplier>> GetAllSuppliers();
        public Task<Supplier?> GetSuppliersById(int id);
        public Task<List<Supplier?>> CreateSupplierById(SupplierWithOutId carWithOutId);
        public Task<Supplier?> DeleteSupplierBy(int id);
        public Task<Supplier?> UpdateSupplierBy(int id, Supplier car);
    }
}
