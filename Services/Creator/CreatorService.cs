using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Data.Entities;
using webapi.Models.Creators;
using webapi.webapi.Data;

namespace webapi.Services.Creator
{
    public class CreatorService : ICreatorService
    {
        private readonly ApplicationDbContext _dbcontext;

        public CreatorService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<bool> CreateCreatorAsync(CreatorCreate model)
        {
            CreatorEntity doesExist = await _dbcontext.Creators.FirstOrDefaultAsync(x => x.DisplayName == model.DisplayName);
            if (doesExist != null)
            {
                return false;
            }
            CreatorEntity creatorEntity = new CreatorEntity
            {
                DisplayName = model.DisplayName,
            };
            _dbcontext.Creators.Add(creatorEntity);
            int numberOfChanges = await _dbcontext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<CreatorDetail> GetCreatorByIdAsync(int creatorId)
        {
            CreatorEntity creator = await _dbcontext.Creators.FirstOrDefaultAsync(x => x.CreatorId == creatorId);
            if (creator == null)
            {
                return null;
            }
            CreatorDetail CreatorDetail = new CreatorDetail
            {
             CreatorId = creator.CreatorId,
             DisplayName = creator.DisplayName,
             GamesCreated = creator.CreatedGames,
            };
            return CreatorDetail;
        }

        public async Task<IEnumerable<CreatorListItem>> GetCreatorListAsync()
        {
            IEnumerable<CreatorListItem> creators = await _dbcontext.Creators.Select(entity => new CreatorListItem
            {
                CreatorId = entity.CreatorId,
                DisplayName = entity.DisplayName,
            }).ToListAsync();
            return creators;
        }

        public async Task<bool> UpdateCreatorAsync(int creatorId, CreatorUpdate model)
        {
            CreatorEntity creator = _dbcontext.Creators.FirstOrDefault(x => x.CreatorId == model.CreatorId);
            if (creator == null)
            {
                return false;
            }
            else
            {
                creator.DisplayName = model.DisplayName;
            }
            var numberOfChanges = await _dbcontext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteCreatorAsync(int creatorId)
        {

            CreatorEntity creator = _dbcontext.Creators.FirstOrDefault(x => x.CreatorId == creatorId);
            if (creator == null)
            {
                return false;
            }
            else
            {
                _dbcontext.Creators.Remove(creator);
                int numberOfChanges = await _dbcontext.SaveChangesAsync();
                return numberOfChanges == 1;
            }
        }
    }
}
