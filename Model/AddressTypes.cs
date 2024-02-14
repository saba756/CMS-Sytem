using System.ComponentModel.DataAnnotations;

namespace CMS.Model
{
    public class AddressTypes
    {
        [Key]
        public int address_type_code { get; set; }
        public string address_type_description { get; set; }
        public ICollection<CustomerAddresses> CustomerAddresses { get; set; }

    }
}
