using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ERP.Models
{
    public class OrderShow
    {
        [Key]
        public int OrderId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Datum narudžbe")]
        public DateTime OrderDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Ukupna cena")]
        public decimal TotalPrice { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
