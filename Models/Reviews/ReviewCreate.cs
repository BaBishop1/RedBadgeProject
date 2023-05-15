using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.Data.Entities;

namespace webapi.Models.Reviews
{
    public class ReviewCreate
    {
        [Required]
        public int GameId { get; set; }
        [Required]
        public double GameScore { get; set; }
        [Required]
        public string ReviewText { get; set; }
    }
}
