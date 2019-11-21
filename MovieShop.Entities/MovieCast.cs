using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.Entities
{
    [Table("MovieCast")]
    public class MovieCast
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CastId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(450)]
        public string Character { get; set; }

        public virtual Cast Cast { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
