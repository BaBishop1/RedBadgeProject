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
        public int Id { get; set; }
        public string Username { get; set; }
    }
}
