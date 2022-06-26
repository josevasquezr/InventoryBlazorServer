using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Inventory.Data
{
    public class InventoryContextFactory : IDesignTimeDbContextFactory<InventoryContext>
    {

        public InventoryContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Development.json", false) // Cambiar para ambiente productivo
            .Build();

            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();
            optionsBuilder.UseSqlServer(
                configuration.GetConnectionString("SqlServerConnectionString"),
                b => b.MigrationsAssembly("Inventory")
            );

            return new InventoryContext(optionsBuilder.Options);
        }
    }
}
