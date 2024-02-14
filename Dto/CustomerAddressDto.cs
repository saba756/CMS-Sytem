using CMS.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CMS.Dto
{
    public class CustomerAddressDto
    {
        public TimeSpan date_from { get; set; } 
        public int customerId { get; set; }
       public int address_id { get; set; }

        public int address_type_code { get; set; }

        public TimeSpan date_to { get; set; }
        public AddressDto addresses { get; set; }
        public AddressTypesDto addressTypes { get; set; }

    }
}
