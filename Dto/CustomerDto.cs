using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CMS.Dto
{
    public class CustomerDto
    {
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
        public string PaymentMethodCode { get; set; }
        [Required]
        //[MaxLength(250)]
        public string OtherPaymentDetail { get; set; }
    }
}
