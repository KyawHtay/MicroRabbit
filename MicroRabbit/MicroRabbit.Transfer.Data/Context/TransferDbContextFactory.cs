using MicroRabbit.Transfer.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MicroRabbit.Banking.Data.Context
{
    public class TransferDbContextFactory : IDesignTimeDbContextFactory<TransferDbContext>
    {
        public TransferDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(@"E:\test\RabbitMQ\MicroRabbit\MicroRabbit.Trasnfer.Api")
                .AddJsonFile("appsettings.json")
                .Build();


            var builder = new DbContextOptionsBuilder<TransferDbContext>();
          
           var connetcionString = configuration.GetConnectionString("TransferDbConnection");// "Server=DESKTOP-MP6CI30;Database=BankingDb;Integrated Security=true;MultipleActiveResultSets=true;User Id=sa;Password=saadmin;";
            builder.UseSqlServer(connetcionString);
            return new TransferDbContext(builder.Options);
        }
    }
}
