using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public interface ICustomersDAO
    {
        Customer GetCustomerByEmail(string email);

        public List<Customer> GetAllCustomers();

        public void CreateCustomer(Customer customer);

        public void UpdateCustomer(Customer customer);

        public void DeleteCustomer(int customerId);

        Customer GetCustomerById(int customerId);

        Customer GetCustomerByName(string customerName);
    }
}
