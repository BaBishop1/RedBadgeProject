using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Data.Entities;
using webapi.Models.Games;
using webapi.webapi.Data;

namespace webapi.Services.Game
{
    public class GameService : IGameService
    {
        private readonly ApplicationDbContext _dbcontext;

        public GameService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<bool> CreateGameAsync(GameCreate model)
        {
            CreatorEntity creatorExists = await _dbcontext.Creators.FirstOrDefaultAsync(x => x.CreatorId == model.CreatorId);
            GameEntity doesExist = await _dbcontext.Games.FirstOrDefaultAsync(x => x.GameTitle == model.GameTitle);
            if (doesExist != null)
            {
                return false;
            }
            GameEntity gameEntity = new GameEntity
            {
                CreatorId = model.CreatorId,
                GameTitle = model.GameTitle,
                GameDescription = model.GameDescription,
                GenreId = model.GenreId,
                DateUploaded = model.DateUploaded,
            };
            _dbcontext.Games.Add(gameEntity);
            int numberOfChanges = await _dbcontext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<GameDetail> GetGameByIdAsync(int gameId)
        {
            GameEntity game = await _dbcontext.Games.FirstOrDefaultAsync(x => x.GameId == gameId);
            if (game == null)
            {
                return null;
            }
            GameDetail gameDetail = new GameDetail
            {
                CreatorId = game.CreatorId,
                GameId = game.GameId,
                GameTitle = game.GameTitle,
                GameDescription = game.GameDescription,
                GenreId = game.GenreId,
                DateUploaded = game.DateUploaded,
            };
            return gameDetail;
        }

        public async Task<IEnumerable<GameListItem>> GetGameListByCreatorAsync(int creatorId)
        {
            IEnumerable<GameListItem> games = await _dbcontext.Games.Select(game => new GameListItem
            {
                GameId = game.GameId,
                GameTitle = game.GameTitle,
            }).ToListAsync();
            return games;
        }

        public async Task<bool> UpdateGameAsync(int gameId, GameUpdate model)
        {
            GameEntity game = _dbcontext.Games.FirstOrDefault(x => x.GameId == gameId);
            if (game == null)
            {
                return false;
            }
            else
            {
                game.CreatorId = model.CreatorId;
                game.GameTitle = model.GameTitle;
                game.GameDescription = model.GameDescription;
                game.GenreId = model.GenreId;
            }
            var numberOfChanges = await _dbcontext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteGameAsync(int gameId)
        {
            GameEntity game = _dbcontext.Games.FirstOrDefault(x => x.GameId == gameId);
            if (game == null)
            {
                return false;
            }
            else
            {
                _dbcontext.Games.Remove(game);
                int numberOfChanges = await _dbcontext.SaveChangesAsync();
                return numberOfChanges == 1;
            }
        }
    }
}
