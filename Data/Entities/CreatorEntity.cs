using System.ComponentModel.DataAnnotations;

namespace webapi.Data.Entities
{
    public class CreatorEntity
    {
        [Key]
        public int CreatorId { get; set; }
        [Required]
        public string DisplayName { get; set; }
        public virtual List<GameEntity> CreatedGames { get; set; } = new List<GameEntity>();
    }
}
