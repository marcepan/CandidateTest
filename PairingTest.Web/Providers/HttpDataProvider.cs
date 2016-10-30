using System.Net.Http;
using System.Threading.Tasks;
using PairingTest.Web.Interfaces;

namespace PairingTest.Web.Providers {
   public class HttpDataProvider : IHttpDataProvider {
      private readonly HttpClient _httpClient;

      public HttpDataProvider(HttpClient client) {
         _httpClient = client;
      }

      public async Task<T> Get<T>(string requestUri) where T : class {
         var response = await _httpClient.GetAsync(requestUri);
         var content = await response.Content.ReadAsAsync<T>();

         return content;
      }
   }
}