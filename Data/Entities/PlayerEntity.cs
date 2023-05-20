using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Data.Entities
{
    public class PlayerEntity
    {
        [Key]
        public int PlayerId { get; set; }
        [Required]
        public string DisplayName { get; set; }
        //Ideas for future iteration
        //[Required]
        //public bool HasVipAccount { get; set; }
        //public virtual List<GameEntity> FavoriteGames { get; set; } = new List<GameEntity>();
    }
}
