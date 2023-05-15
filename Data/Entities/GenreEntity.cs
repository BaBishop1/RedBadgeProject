using System.ComponentModel.DataAnnotations;

namespace webapi.Data.Entities
{
    public class GenreEntity
    {
        [Key]
        public int GenreId { get; set; }
        [Required]
        public string GenreName { get; set; }
        [Required]
        public string GenreDescription { get; set; }
    }
}
