using Core.Configuration;
using Core.Dtos;
using Core.Model;
using Core.Repositories;
using Core.Services;
using Core.Token;
using Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Results;

namespace Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly List<Client> _clients;
        private readonly ITokenService _tokenService;
        private readonly UserManager<UserApp> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<UserRefreshToken> _userRefreshTokenService;

        public AuthenticationService(IOptions<List<Client>> optionsClients, ITokenService tokenService, UserManager<UserApp> userManager, IUnitOfWork unitOfWork, IGenericRepository<UserRefreshToken> userRefreshTokenService)
        {
            _clients = optionsClients.Value;
            _tokenService = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _userRefreshTokenService = userRefreshTokenService;
        }
        public async Task<DataResult<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            if (loginDto == null) throw new ArgumentNullException(nameof(loginDto));

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return new ErrorDataResult<TokenDto>();
            var userRoles = (await _userManager.GetRolesAsync(user)).ToList();
            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return new ErrorDataResult<TokenDto>();
            }
            var token = _tokenService.CreateToken(user, userRoles);
            var userRefreshToken = await _userRefreshTokenService.Where(X => X.UserId == user.Id).SingleOrDefaultAsync();
            if (userRefreshToken == null)
            {
                await _userRefreshTokenService.AddAsync(new UserRefreshToken { UserId = user.Id, Code = token.RefreshToken, Expiration = token.RefreshTokenExpiration });
            }
            else
            {
                userRefreshToken.Code = token.RefreshToken;
                userRefreshToken.Expiration = token.RefreshTokenExpiration;
            }
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<TokenDto>(token);
        }

        public DataResult<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientloginDto)
        {
            var client = _clients.SingleOrDefault(x => x.Id == clientloginDto.ClientId && x.Secret == clientloginDto.ClientSecret);

            if (client == null)
            {
                return new ErrorDataResult<ClientTokenDto>();
            }
            var token = _tokenService.ClientTokenByClient(client);
            return new SuccessDataResult<ClientTokenDto>(token);
        }

        public async Task<DataResult<TokenDto>> CreateTokenByRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _userRefreshTokenService.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();
            if (existRefreshToken == null)
            {
                return new ErrorDataResult<TokenDto>();
            }
            var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);
            if (user == null)
            {
                return new ErrorDataResult<TokenDto>();
            }
            var userRoles = (await _userManager.GetRolesAsync(user)).ToList();
            var tokenDto = _tokenService.CreateToken(user, userRoles);
            existRefreshToken.Code = tokenDto.RefreshToken;
            existRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<TokenDto>();

        }

        public async Task<DataResult<NoContentDto>> RevokeRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _userRefreshTokenService.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();
            if (existRefreshToken == null)
            {
                return new ErrorDataResult<NoContentDto>();
            }
            _userRefreshTokenService.Remove(existRefreshToken);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<NoContentDto>();
        }
    }
}

