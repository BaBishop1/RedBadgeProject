using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.Models.Players
{
    public class PlayerListItem
    {
        public int PlayerId { get; set; }
        public string DisplayName { get; set; }
    }
}
