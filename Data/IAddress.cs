using CMS.Model;

namespace CMS.Data
{
    public interface IAddress
    {
        List<Address> GetAddressesByCustomerId(int id);
        void CreateCustomerAddress(CustomerAddresses customerAddress);
        bool SaveChanges();

    }
}
