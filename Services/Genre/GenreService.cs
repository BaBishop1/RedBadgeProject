using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Models.Genres;

namespace webapi.Services.Genre
{
    public class GenreService : IGenreService
    {
        public Task<bool> CreateGenreAsync(GenreCreate model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGenreAsync(int genreId)
        {
            throw new NotImplementedException();
        }

        public Task<GenreDetail> GetGenreByIdAsync(int genreId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GenreListItem>> GetGenreListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateGenreInfoAsync(GenreUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
