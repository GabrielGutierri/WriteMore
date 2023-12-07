using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WriteMore.Domain.Models
{
    [Table("Movie")]
    public class Movie
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("Title")]
        public string? Title { get; set; }
        [Column("Director")]
        public string? Director { get; set; }
        [Column("Year")]
        public int Year { get; set; }
        [Column("Duration")]
        public string? Duration { get; set; }
        [Column("Cast")]
        public string? Cast { get; set; }
        [Column("Synopisis")]
        public string? Synopisis { get; set; }
        [Column("IMDBRating")]
        public double IMDBRating { get; set; }
    }
}
