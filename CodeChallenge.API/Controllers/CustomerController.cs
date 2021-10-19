using AutoMapper;
using CodeChallenge.Application.Commands.AddCustomer;
using CodeChallenge.Application.Models.Interfaces;
using CodeChallenge.Application.Queries.GetCustomerById;
using CodeChallenge.Domain.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Linq;

namespace CodeChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IServiceProvider _provider;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(IMapper mapper, ICustomerService customerService, IServiceProvider provider)
        {
            _customerService = customerService;
            _mapper = mapper;
            _provider = provider;
        }

        [HttpGet]
        public GetCustomerByIdResponse Get(long id)
        {
            var query = new GetCustomerByIdQuery(id);
            var handler = new GetCustomerByIdHandler(_mapper, _customerService);

            return handler.Handle(query);
        }

        [HttpPut]
        public void Put()
        {
            int numberOfCustomers = 100;

            var result = System.Threading.Tasks.Parallel.ForEach(Enumerable.Range(1, numberOfCustomers), (opts) =>
            {
                var command = new AddCustomerCommand
                {
                    Customer = new Customer
                    {
                        Name = Guid.NewGuid().ToString()
                    }
                };
                Trace.WriteLine("a");

                var handler = new AddCustomerHandler(_provider.GetRequiredService<ICustomerService>());
                var a = handler.Handle(command);
            });
        }
    }
}
