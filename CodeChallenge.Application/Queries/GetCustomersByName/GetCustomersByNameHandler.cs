using AutoMapper;
using CodeChallenge.Application.DTOs;
using CodeChallenge.Application.Interfaces.Queries;
using CodeChallenge.Application.Models.Enums;
using CodeChallenge.Application.Models.Interfaces;
using System;
using System.Linq;

namespace CodeChallenge.Application.Queries.GetCustomersByName
{
    public class GetCustomersByNameHandler : IQueryHandler<GetCustomersByNameQuery, GetCustomersByNameResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public GetCustomersByNameHandler(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        public GetCustomersByNameResponse Handle(GetCustomersByNameQuery query)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(query.Name))
                {
                    throw new Exception($"Customer name is required.");
                }

                var customers = _customerService.GetCustomersByName(query.Name)
                                               .ToList();

                if (customers == null)
                {
                    throw new Exception($"Could not load customer list.");
                }

                var customersDTOs = customers
                    .Select(c => _mapper.Map<CustomerDTO>(c))
                    .ToList();
                
                return new GetCustomersByNameResponse(customersDTOs);
            }
            catch (Exception ex)
            {
                //todo log exception
                return new GetCustomersByNameResponse(ex.Message, StatusCode.InternalServerError);
            }
        }
    }
}