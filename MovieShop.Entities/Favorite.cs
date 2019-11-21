using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.Entities
{
    [Table("Favorite")]
    public class Favorite
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public int UserId { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual User User { get; set; }
    }
}
