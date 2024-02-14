using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Model
{
    [PrimaryKey(nameof(date_from), nameof(customerId), nameof(address_id))]

    public class CustomerAddresses
    {
        [Key]
        public TimeSpan date_from { get; set; }

        [Column(Order = 0), Key,ForeignKey("Customer")]
        public int customerId { get; set; }
        [Column(Order = 1), Key, ForeignKey("Address")]
        public int address_id { get; set; }

        public int address_type_code { get; set; }

        public TimeSpan date_to { get; set; }
        [ForeignKey("address_type_code")]
        public AddressTypes AddressTypes { get; set; }
        public Customer customers { get; set; }
        public Address addresses { get; set; }

    }
}
