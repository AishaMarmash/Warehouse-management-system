using Warehouse_management_system.Domain.Models;

namespace Warehouse_management_system.Models
{
    public class Customer : User
    {
        public Customer(int id, string firstName, string middleName, string lastName, string country, string city, string street, string zip, string nationality, string email, string phoneNumber) : base(id, firstName, middleName, lastName, country, city, street, zip, nationality, email, phoneNumber)
        {
        }
        public List<Package> Packages { get; set; }
    }
}
