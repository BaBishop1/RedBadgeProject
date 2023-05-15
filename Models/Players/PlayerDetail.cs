using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Data.Entities;

namespace webapi.Models.Players
{
    public class PlayerDetail
    {
        public int PLayerId { get; set; }
        public string DisplayName { get; set; }
        public List<GameEntity> FavoriteGames { get; set; }
    }
}
