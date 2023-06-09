﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Data.Entities
{
    public class GameEntity
    {
        [Key]
        public int GameId { get; set; }
        [Required]
        [ForeignKey("Creator")]
        public int CreatorId { get; set; }
        [Required]
        public virtual CreatorEntity Creator { get; set; }
        [Required]
        public string GameTitle { get; set; }
        [Required]
        public string GameDescription { get; set; }
        [Required]
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        [Required]
        public virtual GenreEntity Genre { get; set; }
        [Required]
        public virtual List<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();
        [Required]
        public DateTimeOffset DateUploaded { get; set; }
    }
}
