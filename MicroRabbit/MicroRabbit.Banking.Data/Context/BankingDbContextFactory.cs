using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.IO;

namespace MicroRabbit.Banking.Data.Context
{
    public class BankingDbContextFactory : IDesignTimeDbContextFactory<BankingDbContext>
    {
        public BankingDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(@"E:\test\RabbitMQ\MicroRabbit\MicroRabbit.Banking.Api")
                .AddJsonFile("appsettings.json")
                .Build();


            var builder = new DbContextOptionsBuilder<BankingDbContext>();
          
           var connetcionString = configuration.GetConnectionString("BankingDbConnection");// "Server=DESKTOP-MP6CI30;Database=BankingDb;Integrated Security=true;MultipleActiveResultSets=true;User Id=sa;Password=saadmin;";
            builder.UseSqlServer(connetcionString);
            return new BankingDbContext(builder.Options);
        }
    }
}
