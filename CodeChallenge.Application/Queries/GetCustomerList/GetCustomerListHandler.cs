using CodeChallenge.Application.Models.Enums;
using CodeChallenge.Application.Models.Interfaces;
using System;
using System.Linq;

namespace CodeChallenge.Application.Queries.GetCustomerList
{
    public class GetCustomerListHandler
    {
        private readonly ICustomerService customerService;

        public GetCustomerListHandler(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public GetCustomerListResponse Handle()
        {
            try
            {
                var customers = customerService.GetAllCustomers()
                                               .ToList();

                if (customers == null)
                    throw new Exception($"Could not load customer list.");

                return new GetCustomerListResponse(customers);
            }
            catch (Exception ex)
            {
                return new GetCustomerListResponse
                {
                    ErrorMessage = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
