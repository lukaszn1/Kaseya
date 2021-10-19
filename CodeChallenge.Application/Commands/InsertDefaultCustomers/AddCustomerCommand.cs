using CodeChallenge.Application.Interfaces;
using CodeChallenge.Domain.Customers;

namespace CodeChallenge.Application.Commands.AddCustomer
{
    public class AddCustomerCommand : ICommand
    {
        public Customer Customer { get; set; }
    }
}
