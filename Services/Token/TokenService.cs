using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using webapi.Models.Token;
using webapi.webapi.Data;
using webapi.Data.Entities;

namespace webapi.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IConfiguration _configuration;

        public TokenService(ApplicationDbContext dbcontext, IConfiguration configuration)
        {
            _dbcontext = dbcontext;
            _configuration = configuration;
        }

        public async Task<TokenResponse> GetTokenAsync<T>(TokenRequest model) where T : LoginEntity
        {
            T loginEntity = await GetValidUserAsync<T>(model);
            if (loginEntity is null)
            {
                return null;
            }
            return GenerateToken(loginEntity);
        }

        private async Task<T> GetValidUserAsync<T>(TokenRequest model) where T : LoginEntity
        {
            T? loginEntity = await _dbcontext.Logins.OfType<T>().FirstOrDefaultAsync(user => user.Username.ToLower() == model.Username.ToLower());
            if (loginEntity is null)
                return null;
            PasswordHasher<T> passwordHasher = new PasswordHasher<T>();
            PasswordVerificationResult verifyPasswordResult = passwordHasher.VerifyHashedPassword(loginEntity, loginEntity.Password, model.Password);
            if (verifyPasswordResult == PasswordVerificationResult.Failed)
                return null;

            return loginEntity;
        }

        private TokenResponse GenerateToken<T>(T entity) where T : LoginEntity
        {
            Claim[] claims = GetClaims(entity);

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                Subject = new ClaimsIdentity(claims),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(14),
                SigningCredentials = credentials
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            TokenResponse tokenResponse = new TokenResponse
            {
                Token = tokenHandler.WriteToken(token),
                IssuedAt = token.ValidFrom,
                Expires = token.ValidTo
            };

            return tokenResponse;
        }
        private Claim[] GetClaims<T>(T login) where T: LoginEntity
        {


            string loginType = login.GetType().Name;

            Claim[] claims = new Claim[] { new Claim("Id", login.Id.ToString()), new Claim("Username", login.Username), new Claim("Role", loginType) };

            return claims;
        }
    }
}