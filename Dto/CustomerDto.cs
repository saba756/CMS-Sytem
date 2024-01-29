using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CMS.Dto
{
    public class CustomerDto
    {
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
        public string payment_method_code { get; set; }
        [Required]
        //[MaxLength(250)]
        public string other_payment_detail { get; set; }
    }
}
