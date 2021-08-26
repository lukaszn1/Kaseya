namespace CodeChallenge.Application.Queries.GetCustomersByName
{
    public class GetCustomersByNameQuery
    {       
        public string Name { get; set; }

        public GetCustomersByNameQuery()
        {
        }

        public GetCustomersByNameQuery(string name)
        {
            Name = name;
        }
    }
}
