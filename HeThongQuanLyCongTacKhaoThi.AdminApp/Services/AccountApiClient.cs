using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Services
{
    public class AccountApiClient : IAccountApiClient
    {
        private IHttpClientFactory _httpClientFactory;
        public AccountApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> Authenticate(LoginRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.PostAsync("/api/accounts/authenticate", httpContent);
            var token = await response.Content.ReadAsStringAsync();

            return token;
        }
    }
}
