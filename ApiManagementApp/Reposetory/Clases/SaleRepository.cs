using ApiManagementApp.MDmContext;
using ApiManagementApp.Reposetory.Interface;
using ApiManagementApp.ViewMode;
using Management;
using Microsoft.EntityFrameworkCore;

namespace ApiManagementApp.Reposetory.Clases
{
    public class SaleRepository : ISale
    {
        private ManagmentDbContexts _context;

        public SaleRepository(ManagmentDbContexts contect)
        {
            this._context = contect;
        }


        public async Task<Sale?> DeleteSaleBy(int id)
        {
            var result = await _context.Sales.FindAsync(id);
            if (result is null)
            {
                return null;
            }
            _context.Sales.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<Sale?>> CreateSaleById(SaleWithOutId SaleWithOutId)
        {

            if (SaleWithOutId is null)
            {
                return null;
            }
            int MaxId = _context.Sales.Max(c => c.Id);
            Sale sale = new Sale();
            sale.Id = ++MaxId;
            sale.Coustomer = SaleWithOutId.Coustomer;
            sale.Car = SaleWithOutId.Car;
            sale.CoustomerId = SaleWithOutId.CoustomerId;
            sale.CarId = SaleWithOutId.CarId;
            sale.Total = SaleWithOutId.Total;

            _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
            return await _context.Sales.ToListAsync();
        }

        public async Task<List<Sale>> GetAllSales()
        {
            var result = await _context.Sales.ToListAsync();
            return result;
        }

        public async Task<Sale?> GetSalesById(int id)
        {
            return await _context.Sales.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Sale?> UpdateSaleBy(int id, Sale Sale)
        {
            var result = await _context.Sales.FirstOrDefaultAsync(c => c.Id == id);
            if (result == null)
            {
                return null;
            }

            result.Id = id;
            result.Coustomer = Sale.Coustomer;
            result.Car = Sale.Car;
            result.CoustomerId = Sale.CoustomerId;
            result.CarId = Sale.Id;
            result.Total = Sale.Total;

            await _context.SaveChangesAsync();

            return result;

        }
    }
}
