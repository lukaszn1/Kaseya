using AutoMapper;
using CodeChallenge.Application.DTOs;
using CodeChallenge.Domain.Customers;

namespace CodeChallenge.API.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerDTO>()
                .ReverseMap();
        }
    }
}