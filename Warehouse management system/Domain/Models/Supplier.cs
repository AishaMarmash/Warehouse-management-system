using Warehouse_management_system.Domain.Models;

namespace Warehouse_management_system.Models
{
    public class Supplier : User
    {
        public Supplier(int id, string firstName, string middleName, string lastName, string country, string city, string street, string zip, string nationality, string email, string countryCode, string cityCode, string phoneNumber) : base(id, firstName, middleName, lastName, country, city, street, zip, nationality, email, countryCode, cityCode, phoneNumber)
        {
        }
        public List<Container> Containers { get; set; }
    }
}
