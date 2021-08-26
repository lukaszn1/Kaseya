using CodeChallenge.Application.Models.Enums;
using CodeChallenge.Application.Models.Interfaces;
using System;

namespace CodeChallenge.Application.Commands.AddCustomer
{
    public class AddCustomerHandler
    {
        private readonly ICustomerService customerService;

        public AddCustomerHandler(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public AddCustomerResponse Handle(AddCustomerCommand command)
        {
            try
            {
                if (command.Customer == null)
                    throw new Exception("Customer is required.");

                var customer = customerService.SaveCustomer(command.Customer);

                return new AddCustomerResponse(customer);
            }
            catch (Exception ex)
            {
                return new AddCustomerResponse
                {
                    ErrorMessage = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
