using CodeChallenge.Application.Queries.GetCustomerById;

namespace CodeChallenge.Application.Interfaces.Queries
{
    public interface IQueryHandler<TResult>
    {
    }

    public interface IQueryHandler<TQuery, TResult> : IQueryHandler<TResult> where TQuery : IQuery
    {
        TResult Handle(TQuery query);
    }
}
