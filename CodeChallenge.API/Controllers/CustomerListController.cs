using AutoMapper;
using CodeChallenge.Application.Models.Interfaces;
using CodeChallenge.Application.Queries.GetCustomerList;
using Microsoft.AspNetCore.Mvc;

namespace DataModelCodeChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerListController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService customerService;

        public CustomerListController(IMapper mapper, ICustomerService _customerService)
        {
            _mapper = mapper;
            customerService = _customerService;
        }

        [HttpGet]
        public GetCustomerListResponse GetAllCustomers()
        {
            var handler = new GetCustomerListHandler(_mapper, customerService);
            return handler.Handle();
        }
    }
}