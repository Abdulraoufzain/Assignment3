using Management;

namespace ApiManagementApp.ViewMode
{
    public class PartWithOutId
    {
        public string Name { get; set; }

        public string Price { get; set; } = null!;

        public string Qunantity { get; set; } = null!;

        public int SupliersId { get; set; }

        public virtual Supplier Supliers { get; set; } = null!;
    }
}
