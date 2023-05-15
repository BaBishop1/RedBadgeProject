using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.Models.Players
{
    public class PlayerCreate
    {
        [Required]
        public string DisplayName { get; set; }
    }
}
