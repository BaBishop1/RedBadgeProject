using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Models.Games;

namespace webapi.Services.Game
{
    public class GameService : IGameService
    {
        public Task<bool> CreateGameAsync(GameCreate model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGameInfoAsync(int gameId)
        {
            throw new NotImplementedException();
        }

        public Task<GameDetail> GetGameDetailByIdAsync(int gameId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GameListItem>> GetGameListByCreatorAsync(int creatorId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateGameInfoAsync(GameUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
