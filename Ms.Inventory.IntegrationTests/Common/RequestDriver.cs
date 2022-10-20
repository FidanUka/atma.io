using Ms.Inventory.IntegrationTests.Context;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ms.Inventory.IntegrationTests.Common
{
    public static class RequestDriver
    {
        public static async Task<R> PostAsync<T, R>(string url, T payload, bool returnsException = false, bool emptyResponse = false)
        {
            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var response = await HostingContext.Client.PostAsync(url, content);
            var responseString = await response.Content.ReadAsStringAsync();

            try
            {
                if (!returnsException)
                {
                    response.EnsureSuccessStatusCode();
                }

                if (emptyResponse && responseString.Length == 0)
                {
                    return default(R);
                }

                return JsonSerializer.Deserialize<R>(responseString);
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        public static async Task<T> GetAsync<T>(string url)
        {
            var response = await HostingContext.Client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            try
            {
                response.EnsureSuccessStatusCode();
                if (string.IsNullOrEmpty(content) || content == "null") // Yes, it's plain text
                {
                    return default;
                }

                var result = JsonSerializer.Deserialize<T>(content);
                return result;
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }
    }
}
