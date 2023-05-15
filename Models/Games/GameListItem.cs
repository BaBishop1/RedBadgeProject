using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Data.Entities;

namespace webapi.Models.Games
{
    public class GameListItem
    {
        public int GameId { get; set; }
        public int CreatorId { get; set; }
        public string GameTitle { get; set; }
        public List<GenreEntity> Genres { get; set; }
        public DateTimeOffset DateUploaded { get; set; }
    }
}
