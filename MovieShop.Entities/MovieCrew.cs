using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.Entities
{
    [Table("MovieCrew")]
    public class MovieCrew
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CrewId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Department { get; set; }

        [Key]
        [Column(Order = 3)]
        public string Job { get; set; }

        public virtual Crew Crew { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
