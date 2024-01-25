using Management;

namespace ApiManagementApp.ViewMode
{
    public class CustomerWithOutId
    {

        public string Name { get; set; } = null!;

        public string Age { get; set; } = null!;

        public string Address { get; set; } = null!;

        public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
