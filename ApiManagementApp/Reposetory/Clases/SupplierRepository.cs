using ApiManagementApp.MDmContext;
using ApiManagementApp.Reposetory.Interface;
using ApiManagementApp.ViewMode;
using Management;
using Microsoft.EntityFrameworkCore;

namespace ApiManagementApp.Reposetory.Clases
{

        public class SupplierRepository : ISupplier
        {
            private ManagmentDbContexts _context;

        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public SupplierRepository(ManagmentDbContexts contect)
            {
                this._context = contect;
            }


            public async Task<Supplier?> DeleteSupplierBy(int id)
            {
                var result = await _context.Suppliers.FindAsync(id);
                if (result is null)
                {
                    return null;
                }
                _context.Suppliers.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }

            public async Task<List<Supplier?>> CreateSupplierById(SupplierWithOutId SupplierWithOutId)
            {

                if (SupplierWithOutId is null)
                {
                    return null;
                }
                int MaxId = _context.Suppliers.Max(c => c.Id);
                Supplier supplier= new Supplier();
                supplier.Id = ++MaxId;
                supplier.Name = SupplierWithOutId.Name;
                supplier.Address= SupplierWithOutId.Address;
                supplier.Parts = SupplierWithOutId.Parts;



            _context.Suppliers.AddAsync(supplier);
                await _context.SaveChangesAsync();
                return await _context.Suppliers.ToListAsync();
            }

            public async Task<List<Supplier>> GetAllSuppliers()
            {
                var result = await _context.Suppliers.ToListAsync();
                return result;
            }

            public async Task<Supplier?> GetSuppliersById(int id)
            {
                return await _context.Suppliers.Where(c => c.Id == id).FirstOrDefaultAsync();
            }

            public async Task<Supplier?> UpdateSupplierBy(int id, Supplier Supplier)
            {
                var result = await _context.Suppliers.FirstOrDefaultAsync(c => c.Id == id);
                if (result == null)
                {
                    return null;
                }

                result.Id = id;
                result.Name = Supplier.Name;
                result.Address = Supplier.Address;
                result.Parts= Supplier.Parts;

                await _context.SaveChangesAsync();

                return result;

            }
        }
    
}
