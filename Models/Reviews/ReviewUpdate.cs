using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.Models.Reviews
{
    public class ReviewUpdate
    {
        [Required]
        public int ReviewId { get; set; }
        [Required]
        public int GameId { get; set; }
        [Required]
        public double GameScore { get; set; }
        [Required]
        public string ReviewText { get; set; }
    }
}
