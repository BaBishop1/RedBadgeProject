using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Models.Genres;

namespace webapi.Services.Genre
{
    public interface IGenreService
    {
        Task<bool> CreateGenreAsync(GenreCreate model);
        Task<GenreDetail> GetGenreByIdAsync(int genreId);
        Task<IEnumerable<GenreListItem>> GetGenreListAsync();
        Task<bool> UpdateGenreInfoAsync(GenreUpdate model);
        Task<bool> DeleteGenreAsync(int genreId);

    }
}
