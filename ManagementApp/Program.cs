using Management;

namespace ManagementApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Administration repository = new Administration();

            // إضافة سيارة
            Car car = new Car
            {
                Model ="Tesla" ,
                Gear = "Automatic",
                KM = "10000"
            };
            repository.AddCar(car);

            // إضافة قطعة
            Part part = new Part
            {
                Name = "Part1",
                Qunantity = "10",
                Price ="50" ,
                SupliersId = 1
            };
            repository.AddPart(part);

            // إضافة مصنع
            Supplier supplier = new Supplier
            {
                Name = "Supplier1",
                Address = "Address1"
            };
            repository.AddSupplier(supplier);
        }
    }
}