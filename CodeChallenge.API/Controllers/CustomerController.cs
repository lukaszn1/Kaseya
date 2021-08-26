using CodeChallenge.Application.Commands.AddCustomer;
using CodeChallenge.Application.Models.Interfaces;
using CodeChallenge.Application.Queries.GetCustomerById;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CodeChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public GetCustomerByIdResponse Get(long id)
        {
            var query = new GetCustomerByIdQuery(id);
            var handler = new GetCustomerByIdHandler(customerService);

            return handler.Handle(query);
        }

        [HttpPut]
        public void Put()
        {
            int numberOfCustomers = 100;

            System.Threading.Tasks.Parallel.ForEach(Enumerable.Range(1, numberOfCustomers), (opts) =>
            {
                var command = new AddCustomerCommand
                {
                    Customer = new Domain.Customers.Customer
                    {
                        Name = Guid.NewGuid().ToString()
                    }
                };

                var handler = new AddCustomerHandler(customerService);
                handler.Handle(command);
            });
        }
    }
}
