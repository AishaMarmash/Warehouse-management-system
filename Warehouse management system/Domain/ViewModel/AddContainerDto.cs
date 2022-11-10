using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Warehouse_management_system.Domain.ViewModel
{
    public class AddContainerDto
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public string Type { get; set; }
        public string ContainerNumber { get; set; }
    }
}