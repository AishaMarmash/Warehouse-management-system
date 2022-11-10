using System.ComponentModel;
using System.Reflection;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Services
{
    public static class Helper
    {
        public static List<Package> GetPackages(this List<Models.Container> containersList)
        {
            List<Package> packages = new List<Package>();
            foreach(var container in containersList)
            {
                packages.AddRange(container.Packages);
            }
            return packages;
        }

        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

    }
}
