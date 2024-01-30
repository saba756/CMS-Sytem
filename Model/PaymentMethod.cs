using System.ComponentModel.DataAnnotations;

namespace CMS.Model
{
    public class PaymentMethod
    {
        [Key]
        public string PaymentMethodCode { get; set; }
        [Required]
        [MaxLength(250)]
        public string PayMethodDescription { get; set; }

        public ICollection<Customer> Customers { get; set; }

    }
}
