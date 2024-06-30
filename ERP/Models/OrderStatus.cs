using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    [Table("OrderStatus")]
    public class OrderStatus
    {
        [Key]
        public int Order_status_ID {  get; set; }
        
        [Required, MaxLength(40)]
        public string StatusName { get; set; } = "";

    }
}
