using Core.Dtos;
using Core.Results;
using Core.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IAuthenticationService
    {
        Task<DataResult<TokenDto>> CreateTokenAsync(LoginDto loginDto);
        Task<DataResult<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        Task<DataResult<NoContentDto>> RevokeRefreshToken(string refreshToken);
        DataResult<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientloginDto);
    }
}
