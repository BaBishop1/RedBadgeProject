using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Models.Creators;

namespace webapi.Services.Creator
{
    public interface ICreatorService
    {
        Task<bool> CreateCreatorAsync(CreatorCreate model);
        Task<CreatorDetail> GetCreatorByIdAsync(int creatorId);
        Task<IEnumerable<CreatorListItem>> GetCreatorListAsync();
        Task<bool> UpdateCreatorAsync(int creatorId, CreatorUpdate model);
        Task<bool> DeleteCreatorAsync(int creatorId);
    }
}
