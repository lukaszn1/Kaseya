using CodeChallenge.Application.DTOs;
using CodeChallenge.Application.Models.Enums;
using System.Collections.Generic;

namespace CodeChallenge.Application.Queries.GetCustomerList
{
    public class GetCustomerListResponse : BaseResponse
    {
        public IList<CustomerDTO> Customers { get; set; }

        public GetCustomerListResponse(IList<CustomerDTO> customers)
        {
            Customers = customers;
        }
        public GetCustomerListResponse(string errorMessage, StatusCode statusCode)
            : base(errorMessage, statusCode) { }
    }
}