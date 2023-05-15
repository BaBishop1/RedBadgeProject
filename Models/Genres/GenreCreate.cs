using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.Models.Genres
{
    public class GenreCreate
    {
        [Required]
        public string GenreName { get; set; }
        [Required]
        public string GenreDescription { get; set; }
    }
}
