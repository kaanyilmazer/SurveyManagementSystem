using Core.Dtos;

using Core.Model;
using Core.Results;
using Core.Services;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IValidator<CreateUserDto> _userValidator;

        public UserService(UserManager<UserApp> userManager, RoleManager<IdentityRole> roleManager, IValidator<CreateUserDto> userValidator)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userValidator = userValidator;
        }

        public async Task<DataResult<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var validationResults = await _userValidator.ValidateAsync(createUserDto);
            if (validationResults.Errors.Any())
            {
                return new ErrorDataResult<UserAppDto>(string.Concat(validationResults.Errors.Select(x => x.ErrorMessage)));
            }
            var user = new UserApp { Email = createUserDto.Email, UserName = createUserDto.UserName };
            var result = await _userManager.CreateAsync(user, createUserDto.Password);
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            return new SuccessDataResult<UserAppDto>(ObjectMapper.Mapper.Map<UserAppDto>(user),"Kullanıcı Oluştu.");
        }   

        public async Task<DataResult<UserAppDto>> CreateAdminAsync(CreateUserDto createUserDto)
        {
            var user = new UserApp { Email = createUserDto.Email, UserName = createUserDto.UserName };
            var result = await _userManager.CreateAsync(user, createUserDto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                return new ErrorDataResult<UserAppDto>();
            }
            await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            return new SuccessDataResult<UserAppDto>(ObjectMapper.Mapper.Map<UserAppDto>(user));
        }

        public async Task<DataResult<UserAppDto>> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {   
                return new ErrorDataResult<UserAppDto>();
            }
            return new SuccessDataResult<UserAppDto>(ObjectMapper.Mapper.Map<UserAppDto>(user));
        }
        public Task<DataResult<UserAppDto>> GetRolesAsync(string roles)
        {
            throw new NotImplementedException();
        }
    }
}