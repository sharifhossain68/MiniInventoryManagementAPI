using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MiniInventory.Infrastructure.Data
{
    internal class MiniInventoryDbContextFactory : IDesignTimeDbContextFactory<MiniInventoryDbContext>
    {
        public MiniInventoryDbContext CreateDbContext(string[] args)
        {

            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../MiniInventoryAPI");
            var config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MiniInventoryDbContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("MiniInventoryConnection"));

            return new MiniInventoryDbContext(optionsBuilder.Options);

            
        }
    }
}
