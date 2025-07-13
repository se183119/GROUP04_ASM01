using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepository : ICustomersRepositories
    {
        private readonly ICustomersDAO _customerDao;

        public CustomerRepository()
        {
            _customerDao = new CustomerDao();
        }

        public void CreateCustomer(Customer customer)
        {
            _customerDao.CreateCustomer(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            _customerDao.DeleteCustomer(customerId);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerDao.GetAllCustomers();
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _customerDao.GetCustomerByEmail(email);
        }

        public Customer GetCustomerById(int customerId)
        {
            return _customerDao.GetCustomerById(customerId);
        }

        public Customer GetCustomerByName(string customerName)
        {
            return _customerDao.GetCustomerByName(customerName);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerDao.UpdateCustomer(customer);
        }
    }
}
