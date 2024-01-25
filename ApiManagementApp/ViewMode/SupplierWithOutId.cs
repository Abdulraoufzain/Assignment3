using Management;

namespace ApiManagementApp.ViewMode
{
    public class SupplierWithOutId
    {

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
    }
}
