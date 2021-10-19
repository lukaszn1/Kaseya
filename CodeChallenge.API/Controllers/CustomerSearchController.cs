using AutoMapper;
using CodeChallenge.Application.Models.Interfaces;
using CodeChallenge.Application.Queries.GetCustomersByName;
using Microsoft.AspNetCore.Mvc;

namespace DataModelCodeChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerSearchController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService customerService;

        public CustomerSearchController(IMapper mapper, ICustomerService _customerService)
        {
            _mapper = mapper;
            customerService = _customerService;
        }

        [HttpGet]
        public GetCustomersByNameResponse Get(string name)
        {
            var query = new GetCustomersByNameQuery(name);
            var handler = new GetCustomersByNameHandler(_mapper, customerService);

            return handler.Handle(query);
        }
    }
}
