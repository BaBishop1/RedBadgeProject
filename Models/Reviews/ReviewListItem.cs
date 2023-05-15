using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.Models.Reviews
{
    public class ReviewListItem
    {
        public int ReviewId { get; set; }
        public string GameTitle { get; set; }
        public double GameScore { get; set; }
    }
}
