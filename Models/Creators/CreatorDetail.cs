using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Data.Entities;

namespace webapi.Models.Creators
{
    public class CreatorDetail
    {
        public int CreatorId { get; set; }
        public string DisplayName { get; set; }
        public virtual List<GameEntity> GamesCreated { get; set; }
    }
}
