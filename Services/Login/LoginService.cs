using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Data.Entities;
using webapi.Models.Login;
using webapi.webapi.Data;

namespace webapi.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly ApplicationDbContext _dbcontext;

        public LoginService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> CreateLoginAsync(LoginCreate model)
        {
            if(_dbcontext.Logins.Where(login => login.Username == model.Username).FirstOrDefault() == null)
            {
                return false;
            }

            if (model.Role.ToLower() == "admin") 
            {
                AdminEntity adminEntity = new AdminEntity
                {
                Username = model.Username,
                Email = model.Email,
                };
                PasswordHasher<AdminEntity> passwordHasher = new PasswordHasher<AdminEntity>();
                adminEntity.Password = passwordHasher.HashPassword(adminEntity, model.Password);
                _dbcontext.Logins.Add(adminEntity);
                int numberOfChanges = await _dbcontext.SaveChangesAsync();
                return numberOfChanges == 1;
            }
            
            if (model.Role.ToLower() == "User")
            {
                UserEntity userEntity = new UserEntity
                {
                    Username= model.Username,
                    Email = model.Email,
                };
                PasswordHasher<UserEntity> passwordHasher = new PasswordHasher<UserEntity>();
                userEntity.Password =passwordHasher.HashPassword(userEntity, model.Password);
                _dbcontext.Logins.Add(userEntity);
                int numberOfChanges = await _dbcontext.SaveChangesAsync();
                return numberOfChanges == 1;
            }
            int counter = await _dbcontext.SaveChangesAsync();
            return counter == 1;
        }

        public Task<bool> DeleteLoginAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetLoginByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LoginListItem>> GetLoginListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateLoginAsync(LoginUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
