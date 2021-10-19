using CodeChallenge.Application.DTOs;
using CodeChallenge.Application.Models.Enums;
using CodeChallenge.Domain.Customers;
using System.Collections.Generic;

namespace CodeChallenge.Application.Queries.GetCustomersByName
{
    public class GetCustomersByNameResponse : BaseResponse
    {
        public IList<CustomerDTO> Customers { get; set; }

        public GetCustomersByNameResponse(IList<CustomerDTO> customers)
        {
            Customers = customers;
        }
        public GetCustomersByNameResponse(string errorMessage, StatusCode statusCode)
            : base(errorMessage, statusCode) { }
    }
}