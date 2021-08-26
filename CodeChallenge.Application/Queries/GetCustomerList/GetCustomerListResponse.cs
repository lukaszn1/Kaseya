using CodeChallenge.Application.Models.Enums;
using CodeChallenge.Domain.Customers;
using System.Collections.Generic;

namespace CodeChallenge.Application.Queries.GetCustomerList
{
    public class GetCustomerListResponse
    {
        public List<Customer> Customers { get; set; }

        public string ErrorMessage { get; set; }

        public StatusCode StatusCode { get; set; }

        public GetCustomerListResponse()
        {
        }

        public GetCustomerListResponse(List<Customer> customers)
        {
            Customers = customers;
        }
    }
}
