using CodeChallenge.Application.Models.Interfaces;
using CodeChallenge.Application.Queries.GetCustomerList;
using Microsoft.AspNetCore.Mvc;

namespace DataModelCodeChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerListController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerListController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public GetCustomerListResponse GetAllCustomers()
        {
            var handler = new GetCustomerListHandler(customerService);
            return handler.Handle();
        }
    }
}
