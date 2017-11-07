
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JBC.FacebookStuff
{
    public interface IFacebookClient
    {
        Task<T> GetAsync<T>(string accessToken, string endpoint, string args = null);
        //Task PostAsync(string accessToken, string endpoint, object data, string args = null);
    }

    public class FacebookClient : IFacebookClient
    {
        private readonly HttpClient _httpClient;
        private FacebookClient facebookClient;

        public FacebookClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://graph.facebook.com/v2.8")
            };
            _httpClient.DefaultRequestHeaders
                .Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public FacebookClient(FacebookClient facebookClient)
        {
            this.facebookClient = facebookClient;
        }

        public async Task<T> GetAsync<T>(string accessToken, string endpoint, string args = null)
        {
            var response = await _httpClient.GetAsync($"{endpoint}?access_token={accessToken}&{args}");
            if (!response.IsSuccessStatusCode)
                return default(T);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }

        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}