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
        Task<GameDetail> GetGameDetailByIdAsync(int gameId);
        Task<IEnumerable<GameListItem>> GetGameListByCreatorAsync(int creatorId);
        Task<bool> UpdateGameInfoAsync(GameUpdate model);
        Task<bool> DeleteGameInfoAsync(int gameId);

    }
}
