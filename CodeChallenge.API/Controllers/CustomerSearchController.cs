using CodeChallenge.Application.Models.Interfaces;
using CodeChallenge.Application.Queries.GetCustomersByName;
using Microsoft.AspNetCore.Mvc;

namespace DataModelCodeChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerSearchController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerSearchController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public GetCustomersByNameResponse Get(string name)
        {
            var query = new GetCustomersByNameQuery(name);
            var handler = new GetCustomersByNameHandler(customerService);

            return handler.Handle(query);
        }
    }
}
