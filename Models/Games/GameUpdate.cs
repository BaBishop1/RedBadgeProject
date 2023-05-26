using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Data.Entities;

namespace webapi.Models.Games
{
    public class GameUpdate
    {
        [Required]
        public int CreatorId { get; set; }
        public string GameTitle { get; set; }
        public string GameDescription { get; set; }
        public int GenreId { get; set; }
    }
}
