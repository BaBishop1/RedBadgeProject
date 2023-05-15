using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Models.Creators;

namespace webapi.Services.Creator
{
    public class CreatorService : ICreatorService
    {
        public Task<bool> CreateCreatorAsync(CreatorCreate model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCreatorAsync(int creatorId)
        {
            throw new NotImplementedException();
        }

        public Task<CreatorDetail> GetCreatorDetailByIdAsync(int creatorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CreatorListItem>> GetCreatorListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCreatorInfoAsync(CreatorUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
