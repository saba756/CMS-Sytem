using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        //[MaxLength(250)]
        public string CustomerName { get; set; }
        [Required]
        //[MaxLength(250)]
        public int CustomerPhone { get; set; }
        [Required]
        //[MaxLength(250)]
        public string CustomerEmail { get; set; }
        [Required]
        //[MaxLength(250)]
        public string PaymentDetail { get; set; }
        [ForeignKey("PaymentMethod")]
        public string PaymentMethodCode { get; set; }
        
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        //[MaxLength(250)]
        public string OtherPaymentDetail { get; set; }

        public DateTime DateBecameCustomer { get; set;}
        

    }
}
