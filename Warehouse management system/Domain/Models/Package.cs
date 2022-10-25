using Warehouse_management_system.Domain;

namespace Warehouse_management_system.Models
{
    public class Package
    {
        public int Id { get; set; }
        public bool? IsExpired { get; set; }
        public bool? IsOut { get; set; }
        public List<string>? Notes { get; set; }
        public PackageType Type { get; set; }
        public int[] Dimintions { get; set; }
        public Package(int id, PackageType type, int[] dimintions, bool? isExpired = null, bool? isOut = null, List<string>? notes = null)
        {
            Id = id;
            IsExpired = isExpired;
            IsOut = isOut;
            Notes = notes;
            Type = type;
            if (type.Equals(PackageType.Box))
            {
                Dimintions = new int[dimintions.Length];
            }
            else
            {
                Dimintions = new int[dimintions.Length];
            }
            for (int i = 0; i < dimintions.Length; i++)
                Dimintions[i] = dimintions[i];
        }
    }
}