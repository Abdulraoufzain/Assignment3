using ApiManagementApp.MDmContext;
using ApiManagementApp.Reposetory.Interface;
using ApiManagementApp.ViewMode;
using Management;
using Microsoft.EntityFrameworkCore;

namespace ApiManagementApp.Reposetory.Clases
{
    public class PartRepository : IPart
    {
        private ManagmentDbContexts _context;

        public PartRepository(ManagmentDbContexts contect)
        {
            this._context = contect;
        }


        public async Task<Part?> DeletePartBy(int id)
        {
            var result = await _context.Parts.FindAsync(id);
            if (result is null)
            {
                return null;
            }
            _context.Parts.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<Part?>> CreatePartById(PartWithOutId PartWithOutId)
        {

            if (PartWithOutId is null)
            {
                return null;
            }
            int MaxId = _context.Parts.Max(c => c.Id);
            Part part = new Part();
            part.Id = ++MaxId;
            part.Supliers = PartWithOutId.Supliers;
            part.SupliersId = PartWithOutId.SupliersId;
            part.Name = PartWithOutId.Name;
            part.Qunantity = PartWithOutId.Qunantity;
            part.Price = PartWithOutId.Price;


            _context.Parts.AddAsync(part);
            await _context.SaveChangesAsync();
            return await _context.Parts.ToListAsync();
        }

        public async Task<List<Part>> GetAllParts()
        {
            var result = await _context.Parts.ToListAsync();
            return result;
        }

        public async Task<Part?> GetPartsById(int id)
        {
            return await _context.Parts.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Part?> UpdatePartBy(int id, Part Part)
        {
            var result = await _context.Parts.FirstOrDefaultAsync(c => c.Id == id);
            if (result == null)
            {
                return null;
            }

            result.Id = id;
            result.Price = Part.Price;
            result.Qunantity = Part.Qunantity;
            result.Name = Part.Name;
            result.SupliersId = Part.SupliersId;
            result.Supliers = Part.Supliers;

            await _context.SaveChangesAsync();

            return result;

        }
    }
}
