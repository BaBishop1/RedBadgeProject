using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Models.Players;

namespace webapi.Services.Player
{
    public interface IPlayerService
    {
        Task<bool> CreatePlayerAsync(PlayerCreate model);
        Task<PlayerDetail> GetPlayerByIdAsync(int playerId);
        Task<IEnumerable<PlayerListItem>> GetPlayerListAsync();
        Task<bool> UpdatePlayerAsync(int playerId, PlayerUpdate model);
        Task<bool> DeletePlayerAsync(int playerId);
    }
}
