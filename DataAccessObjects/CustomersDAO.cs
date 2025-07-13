using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class CustomerDao : ICustomersDAO
    {
        public void CreateCustomer(Customer customer)
        {
            using var context = new SmokingCessationContext();
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void DeleteCustomer(int customerId)
        {
            using var context = new SmokingCessationContext();
            var customer = context.Customers.FirstOrDefault(x => x.CustomerId == customerId);
            customer.CustomerStatus = 0;
            context.Customers.Update(customer);
            context.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            using var db = new SmokingCessationContext();
            List<Customer> customerList = db.Customers
                .Where(c => c.CustomerStatus == 1)
                .ToList();
            return customerList;
        }

        public Customer GetCustomerByEmail(string email)
        {
            using var db = new SmokingCessationContext();
            return db.Customers.FirstOrDefault(c => c.EmailAddress == email);
        }

        public Customer GetCustomerById(int customerId)
        {
            using var db = new SmokingCessationContext();
            return db.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        public Customer GetCustomerByName(string customerName)
        {
            using var db = new SmokingCessationContext();
            return db.Customers.FirstOrDefault(c => c.CustomerFullName == customerName);
        }

        public void UpdateCustomer(Customer customer)
        {
            using var context = new SmokingCessationContext();
            context.Customers.Update(customer);
            context.SaveChanges();
        }
    }
}
