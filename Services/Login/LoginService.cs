using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
            if (_dbcontext.Logins.Where(login => login.Username == model.Username).FirstOrDefault(c => c.Username == model.Username) != null)
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
                    Username = model.Username,
                    Email = model.Email,
                };
                PasswordHasher<UserEntity> passwordHasher = new PasswordHasher<UserEntity>();
                userEntity.Password = passwordHasher.HashPassword(userEntity, model.Password);
                _dbcontext.Logins.Add(userEntity);
                int numberOfChanges = await _dbcontext.SaveChangesAsync();
                return numberOfChanges == 1;
            }
            else
            {
                return false;
            }
        }

        public async Task<LoginDetail> GetLoginByIdAsync(int id)
        {
            LoginEntity login = await _dbcontext.Logins.FirstOrDefaultAsync(x => x.Id == id);
            if (login == null)
            {
                return null;
            }
            LoginDetail loginDetail = new LoginDetail
            {
                Id = login.Id,
                Username = login.Username,
                Email = login.Email,
            };
            return loginDetail;
        }

        public async Task<IEnumerable<LoginListItem>> GetLoginListAsync()
        {
            IEnumerable<LoginListItem> logins = await _dbcontext.Logins.Select(entity => new LoginListItem
            {
                Role = entity.GetType().Name,
                Id = entity.Id,
                Username = entity.Username
            }).ToListAsync();
            return logins;
        }

        public async Task<bool> UpdateLoginAsync(LoginUpdate model)
        {
            LoginEntity login = _dbcontext.Logins.FirstOrDefault(x => x.Id == model.Id);
            if (login == null)
            {
                return false;
            }
            else
            {
                login.Id = model.Id;
                login.Username = model.Username;
                login.Email = model.Email;
                login.Password = model.Password;
            }
            var numberOfChanges = await _dbcontext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteLoginAsync(int id)
        {
            LoginEntity login = _dbcontext.Logins.FirstOrDefault(x => x.Id == id);
            if (login == null)
            {
                return false;
            }
            else
            {
                _dbcontext.Logins.Remove(login);
                int numberOfChanges = await _dbcontext.SaveChangesAsync();
                return numberOfChanges == 1;
            }
        }
    }
}
