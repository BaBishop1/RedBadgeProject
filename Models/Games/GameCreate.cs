using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Data.Entities;

namespace webapi.Models.Games
{
    public class GameCreate
    {
        [ForeignKey("CreatorId")]
        [Required]
        public int CreatorId { get; set; }
        [Required]
        public string GameTitle { get; set; }
        [Required]
        public string GameDescription { get; set; }
        [Required]
        [ForeignKey("GenreId")]
        public int GenreId { get; set; }
        [Required]
        public DateTimeOffset DateUploaded { get; set; }
    }
}
