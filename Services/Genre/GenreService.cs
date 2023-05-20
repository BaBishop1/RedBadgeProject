using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Data.Entities;
using webapi.Models.Genres;
using webapi.webapi.Data;

namespace webapi.Services.Genre
{
    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext _dbcontext;

        public GenreService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<bool> CreateGenreAsync(GenreCreate model)
        {
            GenreEntity doesExist = await _dbcontext.Genres.FirstOrDefaultAsync(x => x.GenreName == model.GenreName);
            if (doesExist != null)
            {
                return false;
            }
            GenreEntity genreEntity = new GenreEntity
            {
                GenreName = model.GenreName,
                GenreDescription = model.GenreDescription,
            };
            _dbcontext.Genres.Add(genreEntity);
            int numberOfChanges = await _dbcontext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<GenreDetail> GetGenreByIdAsync(int genreId)
        {
            GenreEntity genre = await _dbcontext.Genres.FirstOrDefaultAsync(x => x.GenreId == genreId);
            if (genre == null)
            {
                return null;
            }
            GenreDetail genreDetail = new GenreDetail
            {
                GenreId = genre.GenreId,
                GenreName = genre.GenreName,
                GenreDescription = genre.GenreDescription,
            };
            return genreDetail;
        }

        public async Task<IEnumerable<GenreListItem>> GetGenreListAsync()
        {
            IEnumerable<GenreListItem> genres = await _dbcontext.Genres.Select(genre => new GenreListItem
            {
                GenreId = genre.GenreId,
                GenreName = genre.GenreName,
            }).ToListAsync();
            return genres;
        }

        public async Task<bool> UpdateGenreAsync(int genreId, GenreUpdate model)
        {
            GenreEntity genre = _dbcontext.Genres.FirstOrDefault(x => x.GenreId == genreId);
            if (genre == null)
            {
                return false;
            }
            else
            {
                genre.GenreName = model.GenreName;
                genre.GenreDescription = model.GenreDescription;
            }
            var numberOfChanges = await _dbcontext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteGenreAsync(int genreId)
        {
            GenreEntity genre = _dbcontext.Genres.FirstOrDefault(x => x.GenreId == genreId);
            if (genre == null)
            {
                return false;
            }
            else
            {
                _dbcontext.Genres.Remove(genre);
                int numberOfChanges = await _dbcontext.SaveChangesAsync();
                return numberOfChanges == 1;
            }
        }
    }
}
