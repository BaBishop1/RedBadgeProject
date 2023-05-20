using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Data.Entities;
using webapi.Models.Players;
using webapi.webapi.Data;

namespace webapi.Services.Player
{
    public class PlayerService : IPlayerService
    {
        private readonly ApplicationDbContext _dbcontext;

        public PlayerService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> CreatePlayerAsync(PlayerCreate model)
        {
            PlayerEntity doesExist = await _dbcontext.Players.FirstOrDefaultAsync(x => x.DisplayName == model.DisplayName);
            if (doesExist != null)
            {
                return false;
            }
            PlayerEntity playerEntity = new PlayerEntity
            {
                DisplayName = model.DisplayName,
            };
            _dbcontext.Players.Add(playerEntity);
            int numberOfChanges = await _dbcontext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<PlayerDetail> GetPlayerByIdAsync(int playerId)
        {
            PlayerEntity player = await _dbcontext.Players.FirstOrDefaultAsync(x => x.PlayerId == playerId);
            if (player == null)
            {
                return null;
            }
            PlayerDetail playerDetail = new PlayerDetail
            {
                PlayerId = player.PlayerId,
                DisplayName = player.DisplayName,
            };
            return playerDetail;
        }

        public async Task<IEnumerable<PlayerListItem>> GetPlayerListAsync()
        {
            IEnumerable<PlayerListItem> players = await _dbcontext.Players.Select(entity => new PlayerListItem
            {
                PlayerId = entity.PlayerId,
                DisplayName = entity.DisplayName,
            }).ToListAsync();
            return players;
        }

        public async Task<bool> UpdatePlayerAsync(int playerId, PlayerUpdate model)
        {
            PlayerEntity player = _dbcontext.Players.FirstOrDefault(x => x.PlayerId == playerId);
            if (player == null)
            {
                return false;
            }
            else
            {
                player.DisplayName = model.DisplayName;
            }
            var numberOfChanges = await _dbcontext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeletePlayerAsync(int playerId)
        {
            PlayerEntity player = _dbcontext.Players.FirstOrDefault(x => x.PlayerId == playerId);
            if (player == null)
            {
                return false;
            }
            else
            {
                _dbcontext.Players.Remove(player);
                int numberOfChanges = await _dbcontext.SaveChangesAsync();
                return numberOfChanges == 1;
            }
        }
    }
}
