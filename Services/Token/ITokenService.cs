using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Data.Entities;
using webapi.Models.Token;

namespace webapi.Services.Token
{
    public interface ITokenService{
        Task<TokenResponse> GetTokenAsync<T>(TokenRequest model) where T: LoginEntity;

    }
}