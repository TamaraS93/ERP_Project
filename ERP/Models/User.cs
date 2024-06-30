using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
