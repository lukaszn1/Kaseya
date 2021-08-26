using CodeChallenge.Application.Models.Enums;
using CodeChallenge.Domain.Customers;

namespace CodeChallenge.Application.Commands.AddCustomer
{
    public class AddCustomerResponse
    {
        public Customer Customer { get; set; }

        public string ErrorMessage { get; set; }

        public StatusCode StatusCode { get; set; }

        public AddCustomerResponse()
        {
        }

        public AddCustomerResponse(Customer customer)
        {
            Customer = customer;
        }
    }
}
