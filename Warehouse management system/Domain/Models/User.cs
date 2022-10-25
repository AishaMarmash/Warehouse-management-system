namespace Warehouse_management_system.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Country { get; set; }
        public String City { get; set; }
        public String Street { get; set; }
        public String Zip { get; set; }
        public String Nationality { get; set; }
        public String Email { get; set; }
        public String CountryCode { get; set; }
        public String CityCode { get; set; }
        public String PhoneNumber { get; set; }
    
        public User(int id, string firstName, string middleName, string lastName, string country, string city, string street, string zip, string nationality, string email, string countryCode, string cityCode, string phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Country = country;
            City = city;
            Street = street;
            Zip = zip;
            Nationality = nationality;
            Email = email;
            CountryCode = countryCode;
            CityCode = cityCode;
            PhoneNumber = phoneNumber;
        }
    }
}
