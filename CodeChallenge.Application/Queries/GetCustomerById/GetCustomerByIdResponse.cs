using CodeChallenge.Application.DTOs;
using CodeChallenge.Application.Models.Enums;

namespace CodeChallenge.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdResponse : BaseResponse
    {
        public CustomerDTO Customer { get; private set; }

        public GetCustomerByIdResponse(CustomerDTO customer)
        {
            Customer = customer;
        }

        public GetCustomerByIdResponse(string errorMessage, StatusCode statusCode)
            : base(errorMessage, statusCode) { }
    }
}
