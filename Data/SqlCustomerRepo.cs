using CMS.Model;
using Microsoft.EntityFrameworkCore;

namespace CMS.Data
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly CustomerContext _context;

        public CustomerRepo(CustomerContext context)
        {
            _context = context;
        }

        public void CreateCustomer(Customer customer)
        {
            // get payment method on basis of payment method code
           var paymentMethod= _context.PaymentMethods.FirstOrDefault(p => p.PaymentMethodCode == customer.PaymentMethodCode);

            if (customer == null || paymentMethod == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            _context.Customer.Add(customer);
        }

        public void DeleteCustomer(Customer cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            var addresses = GetCustomerAddressesByCustomerId(cmd.CustomerId).Select(x => x as object).ToArray();
            _context.CustomerAddresses.RemoveRange(addresses.Cast<CustomerAddresses>().ToArray());
            _context.Customer.Remove(cmd);
        }
        public List<CustomerAddresses> GetCustomerAddressesByCustomerId(int id)
        {
            return _context.CustomerAddresses.Where(p => p.customerId == id).ToList();
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            var customersList = _context.Customer
                .Include(c => c.customerAddresses)
                .Include(c => c.PaymentMethod)
                .Include("customerAddresses.addresses")
                .Include("customerAddresses.addresses")
                .ToList();
/*                 .SelectMany(x => x.customerAddresses.Select(xa => xa.addresses)).ToList();
*/            return customersList;
        }

        public Customer GetCustomerId(int id)
        {
            var cus=_context.Customer
                .Include(c => c.customerAddresses)
                .Include(c => c.PaymentMethod)
                .Include("customerAddresses.addresses")
                .Include("customerAddresses.addresses").FirstOrDefault(p => p.CustomerId == id);
            return cus;
            // return _context.Customer.FirstOrDefault(p => p.CustomerId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCustomer(Customer cmd)
        {
            //Nothing
        }
    }
}
