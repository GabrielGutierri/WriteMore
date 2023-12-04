using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WriteMoreAPI.Model
{
    [Table("Book")]
    public class Book
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("Name")]
        public string? Name { get; set; }
        
        [Column("Author")]
        public string? Author { get; set; }
        [Column("Year")]
        public string? Year { get; set; }
        [Column("Publisher")]
        public string? Publisher { get; set; }
        [Column("Pages")]
        public int Pages { get; set; }
        [Column("Synopisis")]
        public string? Synopisis { get; set; }
        //public byte[] Image { get; set; }
    }
}
