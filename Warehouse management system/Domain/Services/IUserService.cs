using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Domain.ViewModel;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Domain.Services
{
    public interface IUserService
    {
        public List<UserDto> BuildResponse(List<User> users);
    }
}
