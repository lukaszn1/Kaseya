using CodeChallenge.Domain.Customers;
using System.Collections.Generic;

namespace CodeChallenge.Application.Models.Interfaces
{
    public interface ICustomerService
    {
        Customer GetCustomerById(long id);

        IEnumerable<Customer> GetCustomersByName(string name);

        IEnumerable<Customer> GetAllCustomers();

        Customer SaveCustomer(Customer customer);
    }
}
