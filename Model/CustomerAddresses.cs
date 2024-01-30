using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Model
{
    public class CustomerAddresses
    {
        [ForeignKey("customer_id")]
        public int customerId { get; set; }
        [ForeignKey("address_id")]
        public int address_id { get; set; }
        [Key]
        public TimeSpan date_from { get; set; }
        [ForeignKey("address_type_code")]
        public int address_type_code { get; set; }
    }
}
