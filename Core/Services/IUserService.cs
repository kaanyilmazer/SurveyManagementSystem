using Core.Dtos;
using Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IUserService
    {
        Task<DataResult<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<DataResult<UserAppDto>> GetUserByNameAsync(string userName);
        Task<DataResult<UserAppDto>> CreateAdminAsync(CreateUserDto createUserDto);
        Task<DataResult<UserAppDto>> GetRolesAsync(string roles);
    }
}
