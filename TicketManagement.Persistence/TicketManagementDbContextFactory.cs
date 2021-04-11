using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TicketManagement.Persistence
{
    public class TicketManagementDbContextFactory : IDesignTimeDbContextFactory<TicketManagementDbContext>
    {
        public TicketManagementDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<TicketManagementDbContext>();
            var connectionString = configuration.GetConnectionString("TicketManagementConnectionString");
            
            builder.UseSqlServer(connectionString);
            
            return new TicketManagementDbContext(builder.Options);
        }
    }
}