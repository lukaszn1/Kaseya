using AutoMapper;
using CodeChallenge.Application.DTOs;
using CodeChallenge.Application.Interfaces.Queries;
using CodeChallenge.Application.Models.Enums;
using CodeChallenge.Application.Models.Interfaces;
using System;

namespace CodeChallenge.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdHandler : IQueryHandler<GetCustomerByIdQuery, GetCustomerByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public GetCustomerByIdHandler(IMapper mapper, ICustomerService customerService)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public GetCustomerByIdResponse Handle(GetCustomerByIdQuery query)
        {
            try
            {
                if (query.Id <= 0)
                {
                    throw new Exception("Customer Id must be greater than zero.");
                }

                var customer = _customerService.GetCustomerById(query.Id);
                if (customer == null) 
                { 
                    throw new Exception($"Could not find Customer with Id '{query.Id}'."); 
                }

                return new GetCustomerByIdResponse(_mapper.Map<CustomerDTO>(customer)); 
            }
            catch (Exception ex)
            {
                //todo log exception
                return new GetCustomerByIdResponse(ex.Message, StatusCode.InternalServerError);
            }
        }
    }
}
