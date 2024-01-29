using CMS.Model;

namespace CMS.Data
{
    public interface ICustomerRepo
    {
        bool SaveChanges();

        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerId(int id);
        void CreateCustomer(Customer cmd);
        void UpdateCustomer(Customer cmd);
        void DeleteCustomer(Customer cmd);
    }
}
