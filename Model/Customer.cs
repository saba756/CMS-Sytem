using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Model
{
    public class Customer
    {
        [Key]
        public int customerId { get; set; }
        [Required]
        //[MaxLength(250)]
        public string customer_name { get; set; }
        [Required]
        //[MaxLength(250)]
        public int customer_phone { get; set; }
        [Required]
        //[MaxLength(250)]
        public string customer_email { get; set; }
        [Required]
        //[MaxLength(250)]
        public string payment_detail { get; set; }
        [ForeignKey("payment_method_code")]
        public string payment_method_code { get; set; }
        [Required]
        //[MaxLength(250)]
        public string other_payment_detail { get; set; }

        public DateTime date_became_customer { get; set;}

    }
}
