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
    public class ReviewDetail
    {
        public int ReviewId { get; set; }
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        public double GameScore { get; set; }
        public string ReviewText { get; set; }
    }
}
