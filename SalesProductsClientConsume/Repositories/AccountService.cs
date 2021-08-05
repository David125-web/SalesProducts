using SalesProductsClientConsume.Entities;
using SalesProductsClientConsume.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SalesProductsClientConsume.Repositories
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetToken(string clientId, string clientScret)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "token");
            request.Headers.Authorization = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientScret}")));
            //request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            //{
            //    {"grant_type","client-credentials"}
            //});
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseStream = await response.Content.ReadAsStreamAsync();
            var authResult = await JsonSerializer.DeserializeAsync<TokenEntity>(responseStream);


            return authResult.access_token;

        }
    }
}
