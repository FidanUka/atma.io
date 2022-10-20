using Microsoft.Extensions.DependencyInjection;
using Ms.Inventory.BusinessLogic.Contracts.Inventory;
using Ms.Inventory.BusinessLogic.Contracts.Product;
using Ms.Inventory.BusinessLogic.Inventory;
using Ms.Inventory.BusinessLogic.Product;
using Ms.Inventory.Database.Contracts.Repositories;
using Ms.Inventory.Database.Repositories;

namespace Ms.Inventory.Configurations.Dependency
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IRepository, Repository>();
            services.AddTransient<IInventoryDataService, InventoryDataService>();
            services.AddTransient<IProductService, ProductService>();

            return services;
        }
    }
}