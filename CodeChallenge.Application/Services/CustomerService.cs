using CodeChallenge.Application.Models.Interfaces;
using CodeChallenge.Domain.Customers;
using CodeChallenge.Infrastructure.Persistence;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private const string CACHE_KEY_CUSTOMERS = "Customers";

        private readonly CodeChallengeDbContext dbContext;
        private readonly CodeChallengeMemoryCache memoryCache;

        public CustomerService(CodeChallengeDbContext dbContext, CodeChallengeMemoryCache memoryCache)
        {
            this.dbContext = dbContext;
            this.memoryCache = memoryCache;
        }

        // TODO: Reimplement using Linq
        public Customer GetCustomerById(long id)
        {
            var customers = GetAllCustomers();

            foreach (var customer in customers)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }

            return null;
        }

        // TODO: Reimplement using iterator blocks
        public IEnumerable<Customer> GetCustomersByName(string name)
        {
            var result = new List<Customer>();

            var customers = GetAllCustomers();

            foreach (var customer in customers)
            {
                if (customer.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    result.Add(customer);
                }
            }

            return result;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            if (!memoryCache.Cache.TryGetValue(CACHE_KEY_CUSTOMERS, out List<Customer> customers))
            {
                customers = dbContext.Customers.ToList();

                memoryCache.Cache.Set(CACHE_KEY_CUSTOMERS, customers, new DateTimeOffset());
            }

            return customers;
        }

        public Customer SaveCustomer(Customer customer)
        {
            var customers = GetAllCustomers();
            if (!customers.Any(x => x.Id == customer.Id))
            {
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();

                UpdateCustomersCache(customer);
            }

            return customer;
        }

        private void UpdateCustomersCache(Customer customer)
        {
            var cachedCustomers = memoryCache.Cache.Get(CACHE_KEY_CUSTOMERS) as List<Customer>;
            if (cachedCustomers != null)
            {
                cachedCustomers.Add(customer);
                memoryCache.Cache.Set(CACHE_KEY_CUSTOMERS, cachedCustomers, new DateTimeOffset());
            }
        }
    }
}
