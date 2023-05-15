using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Models.Login;

namespace webapi.Services.Login
{
    public interface ILoginService
    {
        Task<bool> CreateLoginAsync(LoginCreate model);
        Task<bool> GetLoginByIdAsync(int id);
        Task<IEnumerable<LoginListItem>> GetLoginListAsync();
        Task<bool> UpdateLoginAsync(LoginUpdate model);
        Task<bool> DeleteLoginAsync(int id);
    }
}
