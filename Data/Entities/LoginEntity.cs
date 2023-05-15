
using System.ComponentModel.DataAnnotations;

namespace webapi.Data.Entities
{
    public class LoginEntity
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
