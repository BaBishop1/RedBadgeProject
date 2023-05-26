using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Data.Entities;

namespace webapi.Models.Games
{
    public class GameDetail
    {
        public int GameId { get; set; }
        public int CreatorId { get; set; }
        public string GameTitle { get; set; }
        public string GameDescription { get; set; }
        public int GenreId { get; set; }
        public DateTimeOffset DateUploaded { get; set; }
    }
}
