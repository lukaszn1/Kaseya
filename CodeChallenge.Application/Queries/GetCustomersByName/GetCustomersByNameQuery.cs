using CodeChallenge.Application.Interfaces;

namespace CodeChallenge.Application.Queries.GetCustomersByName
{
    public class GetCustomersByNameQuery : IQuery
    {       
        public string Name { get; private set; }

        public GetCustomersByNameQuery(string name)
        {
            Name = name;
        }
    }
}