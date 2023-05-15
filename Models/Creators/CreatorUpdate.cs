using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.Models.Creators
{
    public class CreatorUpdate
    {
        [Required]
        public int CreatorId { get; set; }
        [Required]
        public string DisplayName;
    }
}
