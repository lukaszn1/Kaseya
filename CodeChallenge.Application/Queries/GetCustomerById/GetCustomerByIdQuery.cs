using CodeChallenge.Application.Interfaces;

namespace CodeChallenge.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IQuery
    {
        public long Id { get; private set; }

        public GetCustomerByIdQuery(long id)
        {
            Id = id;
        }
    }
}
