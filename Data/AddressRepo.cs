using CMS.Model;
using Microsoft.EntityFrameworkCore;

namespace CMS.Data
{
    public class AddressRepo : IAddress


    {
        private readonly CustomerContext _context;
        public AddressRepo(CustomerContext context)
        {
            _context = context;
        }
       
        public List<Address> GetAddressesByCustomerId(int id)
        {
            var customerAddresses = _context.CustomerAddresses.Where(p => p.customerId == id);
            var addressIds = new List<int>();
            foreach (var cus in customerAddresses)
            {
                addressIds.Add(cus.address_id);
            }
            return _context.Address.Where(p => addressIds.Contains(p.address_id)).ToList();
        }
        public void CreateCustomerAddress(CustomerAddresses customerAddress)
        {
                        // check if customer exists
            var customer = _context.Customer.FirstOrDefault(customer => customer.CustomerId == customerAddress.customerId);
            if (customer == null) {
                throw new ArgumentNullException(nameof(customer));
            }
            // check if address exists 
            var address =  _context.Address.FirstOrDefault(address => address.address_id == customerAddress.address_id);
           if (address == null)
            {
                // going to create new address 
              var tmpAddress = _context.Address.Add(customerAddress.addresses);
              _context.SaveChanges();
               customerAddress.address_id = tmpAddress.Entity.address_id;
            }
            _context.CustomerAddresses.Add(customerAddress);
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }


    }
}
