using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Data.Entities
{
    public class ReviewEntity
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        [ForeignKey("Game")]
        public int GameId { get; set; }
        public virtual GameEntity Game { get; set; }
        [Required]
        public double GameScore { get; set; }
        [Required]
        public string ReviewText { get; set; }
    }
}
