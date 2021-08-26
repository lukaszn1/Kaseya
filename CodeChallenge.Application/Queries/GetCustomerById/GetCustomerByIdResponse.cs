using CodeChallenge.Application.Models.Enums;
using CodeChallenge.Domain.Customers;

namespace CodeChallenge.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdResponse
    {
        public Customer Customer { get; set; }

        public string ErrorMessage { get; set; }

        public StatusCode StatusCode { get; set; }

        public GetCustomerByIdResponse()
        {
        }

        public GetCustomerByIdResponse(Customer customer)
        {
            Customer = customer;
        }
    }
}
