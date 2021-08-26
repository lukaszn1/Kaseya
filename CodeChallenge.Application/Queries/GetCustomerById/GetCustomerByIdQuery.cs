namespace CodeChallenge.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery
    {
        public long Id { get; set; }

        public GetCustomerByIdQuery()
        {
        }

        public GetCustomerByIdQuery(long id)
        {
            Id = id;
        }
    }
}
