using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Models.Games;

namespace webapi.Services.Game
{
    public interface IGameService
    {
        Task<bool> CreateGameAsync(GameCreate model);
        Task<GameDetail> GetGameByIdAsync(int gameId);
        Task<IEnumerable<GameListItem>> GetGameListByCreatorAsync(int creatorId);
        Task<bool> UpdateGameAsync(int gameId, GameUpdate model);
        Task<bool> DeleteGameAsync(int gameId);
    }
}
