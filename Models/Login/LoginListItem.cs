using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.Models.Login
{
    public class LoginListItem
    {
        public string Role {get; set;}
        public int Id { get; set; }
        public string Username { get; set; }
    }
}
