using System;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using TicketManagement.Persistence;

namespace TicketManagement.Api.IntegrationTests.Base
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddHttpContextAccessor();

                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<TicketManagementDbContext>));

                services.Remove(descriptor);

                services.AddHttpsRedirection(options =>
                {
                    options.HttpsPort = 5001;
                });

                services.AddDbContext<TicketManagementDbContext>(options =>
                {
                    options.UseInMemoryDatabase("TicketManagementDbContextInMemoryTest");
                });
                
                var sp = services.BuildServiceProvider();
                
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<TicketManagementDbContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    context.Database.EnsureCreated();
                    Console.WriteLine(context);
                    
                    try
                    {
                        Utilities.InitializeDbForTests(context);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occured seeding the database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }

        public HttpClient GetAnonymousClient()
        {
            return CreateClient();
        }
    }
}