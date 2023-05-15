using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Models.Players;

namespace webapi.Services.Player
{
    public class PlayerService : IPlayerService
    {
        public Task<bool> CreatePlayerAsync(PlayerCreate model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePlayerAsync(int playerId)
        {
            throw new NotImplementedException();
        }

        public Task<PlayerDetail> GetPlayerById(int playerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PlayerListItem>> GetPlayerListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePlayerInfoAsync(PlayerUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
