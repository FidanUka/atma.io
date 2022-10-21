using Microsoft.Extensions.DependencyInjection;
using Ms.Inventory.Database.Contracts.Repositories;
using Ms.Inventory.IntegrationTests.Context;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Ms.Inventory.IntegrationTests.Common
{
    public class TestBaseSetup
    {

        [OneTimeSetUp]
        public async Task OneTimeInit()
        {
            HostingContext.StartupHost();
        }

        [SetUp]
        public async Task Setup()
        {
            var repository = GetService<IRepository>();
            repository.ClearData();
        }

        protected static T GetService<T>()
        {
            return HostingContext.Factory.Services.GetRequiredService<T>();
        }
    }
}