using AutoMapper;
using CodeChallenge.Application.DTOs;
using CodeChallenge.Application.Interfaces.Queries;
using CodeChallenge.Application.Models.Enums;
using CodeChallenge.Application.Models.Interfaces;
using System;
using System.Linq;

namespace CodeChallenge.Application.Queries.GetCustomerList
{
    public class GetCustomerListHandler : IQueryHandler<GetCustomerListResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public GetCustomerListHandler(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        public GetCustomerListResponse Handle()
        {
            try
            {
                var customers = _customerService.GetAllCustomers()
                                               .ToList();

                if (customers == null)
                {
                    throw new Exception($"Could not load customer list.");
                }

                var customersDTOs = customers.Select(c => _mapper.Map<CustomerDTO>(c)).ToList();

                return new GetCustomerListResponse(customersDTOs);
            }
            catch (Exception ex)
            {
                //todo log exception
                return new GetCustomerListResponse(ex.Message, StatusCode.InternalServerError);
            }
        }
    }
}