using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("film_ratings")]
    public class FilmRating: EntityBase
    {
        [Column("filmrating_id")]
        public int FilmRatingId { get; set; }

        [Column("external_id")]
        [Required]
        public string ExternalId { get; set; }

        [Column("rating")]
        [Required]
        public int Rating { get; set; }

        [Column("nickname")]
        public string Nickname { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}
