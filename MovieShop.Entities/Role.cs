using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.Entities
{
    [Table("Role")]
    public class Role
    {
       public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
