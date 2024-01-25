using ApiManagementApp.ViewMode;
using Management;

namespace ApiManagementApp.Reposetory.Interface
{
    public interface ISale
    {
        public Task<List<Sale>> GetAllSales();
        public Task<Sale?> GetSalesById(int id);
        public Task<List<Sale?>> CreateSaleById(SaleWithOutId carWithOutId);
        public Task<Sale?> DeleteSaleBy(int id);
        public Task<Sale?> UpdateSaleBy(int id, Sale car);
    }
}
