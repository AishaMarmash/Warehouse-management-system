using AutoMapper;
using Warehouse_management_system.Domain.Models;
using Warehouse_management_system.Domain.Repositories;
using Warehouse_management_system.Domain.Services;
using Warehouse_management_system.Domain.ViewModel;
using Warehouse_management_system.Models;

namespace Warehouse_management_system.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<UserDto> BuildResponse(List<User> users)
        {
            List<UserDto> mappedUsers = _mapper.Map<List<UserDto>>(users);
            return mappedUsers;
        }

    }
}
