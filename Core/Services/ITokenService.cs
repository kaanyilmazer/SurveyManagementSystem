using Core.Configuration;
using Core.Dtos;
using Core.Model;
using Core.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp userApp, List<string> userRoles);
        ClientTokenDto ClientTokenByClient(Client client);
    }
}
