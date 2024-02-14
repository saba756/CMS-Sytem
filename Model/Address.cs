using System.ComponentModel.DataAnnotations;

namespace CMS.Model
{
    public class Address
    {
          
        [Key]
        public int address_id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        /*       [Required]
               public string AppUserId { get; set; }*/
        /*        public AppUser AppUser { get; set; }
        */
        public List<CustomerAddresses> customerAddresses { get; set; }


    }
}
