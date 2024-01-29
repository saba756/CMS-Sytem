using CMS.Model;

namespace CMS.Data
{
    public class SqlCustomerRepo : ICustomerRepo
    {
        private readonly CustomerContext _context;

        public SqlCustomerRepo(CustomerContext context)
        {
            _context = context;
        }

        public void CreateCustomer(Customer cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Customer.Add(cmd);
        }

        public void DeleteCustomer(Customer cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Customer.Remove(cmd);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customer.ToList();
        }

        public Customer GetCustomerId(int id)
        {
            return _context.Customer.FirstOrDefault(p => p.customerId == id);
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
