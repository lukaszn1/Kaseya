using CodeChallenge.Infrastructure.Persistence;
using CodeChallenge.Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CodeChallenge.Application.Models.Interfaces;
using System;
using CodeChallenge.Domain.Customers;
using System.Collections.Generic;

namespace DataModelCodeChallenge.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CodeChallengeDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"), ServiceLifetime.Transient);

            services.AddOptions();
            services.AddControllers();
            services.AddAuthorization();

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddSingleton<CodeChallengeMemoryCache>(); 
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var options = new DbContextOptionsBuilder<CodeChallengeDbContext>().UseInMemoryDatabase(databaseName: "InMemoryDb").Options;
            //Seed(options);
        }

        private void Seed(DbContextOptions<CodeChallengeDbContext> options)
        {
            using (var context = new CodeChallengeDbContext(options))
            {
                context.Customers.AddRange(new List<Customer>
            {
                    new Customer { Id = 1, Name = "John", LastName = "Doyle", IsActive = true, CreatedDate = new DateTime(2021, 01, 01), LastModifiedDate = new DateTime(2021, 01, 02) },
                new Customer { Id = 2, Name = "John", LastName = "Peterson", IsActive = true, CreatedDate = new DateTime(2021, 02, 01), LastModifiedDate = new DateTime(2021, 01, 03) },
                new Customer { Id = 3, Name = "John", LastName = "Adams", IsActive = true, CreatedDate = new DateTime(2021, 03, 01), LastModifiedDate = new DateTime(2021, 01, 04) },
                new Customer { Id = 4, Name = "John", LastName = "Taylor", IsActive = true, CreatedDate = new DateTime(2021, 04, 01), LastModifiedDate = new DateTime(2021, 01, 05) },
                new Customer { Id = 5, Name = "Mark", LastName = "Hamilton", IsActive = false, CreatedDate = new DateTime(2021, 05, 01), LastModifiedDate = new DateTime(2021, 02, 06) },
                new Customer { Id = 6, Name = "Jane", LastName = "Burr", IsActive = true, CreatedDate = new DateTime(2021, 06, 01), LastModifiedDate = new DateTime(2021, 03, 07) },
                new Customer { Id = 7, Name = "Sarah", LastName = "Collins", IsActive = false, CreatedDate = new DateTime(2021, 07, 01), LastModifiedDate = new DateTime(2021, 04, 08) },
                new Customer { Id = 8, Name = "Peter", LastName = "Johnson", IsActive = true, CreatedDate = new DateTime(2021, 08, 01), LastModifiedDate = new DateTime(2021, 05, 09) },
                new Customer { Id = 9, Name = "Peter", LastName = "James", IsActive = true, CreatedDate = new DateTime(2021, 09, 01), LastModifiedDate = new DateTime(2021, 05, 10) },
                new Customer { Id = 10, Name = "Peter", LastName = "Moore", IsActive = true, CreatedDate = new DateTime(2021, 10, 01), LastModifiedDate = new DateTime(2021, 05, 11) }
                });

                context.SaveChanges();
            }
        }
    }
}
