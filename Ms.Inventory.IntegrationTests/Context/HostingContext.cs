using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace Ms.Inventory.IntegrationTests.Context
{
    public static class HostingContext
    {
        public static HttpClient Client { get; private set; }
        public static WebApplicationFactory<Startup> Factory;

        public static void StartupHost()
        {
            Factory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder => builder
                        .UseEnvironment("Development")
                        .ConfigureTestServices(services =>
                        {
                            //Add external mocked services
                        }));

            // Create an HttpClient which is setup for the test host
            Client = Factory.CreateClient();
        }
    }
}