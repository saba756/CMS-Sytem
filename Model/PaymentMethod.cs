using System.ComponentModel.DataAnnotations;

namespace CMS.Model
{
    public class PaymentMethod
    {
        [Key]
        public string payment_method_code { get; set; }
        [Required]
        [MaxLength(250)]
        public string pay_method_description { get; set; }

        public List<Customer> customers { get; set; }

    }
}
