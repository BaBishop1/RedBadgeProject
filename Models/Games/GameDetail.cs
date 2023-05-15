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
        public List<GenreEntity> Genres { get; set; }
        public List<ReviewEntity> Reviews { get; set; }
    }
}
