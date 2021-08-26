using CodeChallenge.Application.Models.Enums;
using CodeChallenge.Domain.Customers;
using System.Collections.Generic;

namespace CodeChallenge.Application.Queries.GetCustomersByName
{
    public class GetCustomersByNameResponse
    {
        public List<Customer> Customers { get; set; }

        public string ErrorMessage { get; set; }

        public StatusCode StatusCode { get; set; }

        public GetCustomersByNameResponse()
        {
        }

        public GetCustomersByNameResponse(List<Customer> customers)
        {
            Customers = customers;
        }
    }
}
