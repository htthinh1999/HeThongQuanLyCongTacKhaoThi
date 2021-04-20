using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.ScoreType;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.ApiIntegration
{
    public class ScoreTypeApiClient : IScoreTypeApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ScoreTypeApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult<List<ScoreTypeViewModel>>> GetAll()
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/scoretypes/get-all");
            var body = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ApiSuccessResult<List<ScoreTypeViewModel>>>(body);
        }

        public async Task<ApiResult<List<ScoreTypeViewModel>>> GetAllBySubjectID(string subjectID)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/scoretypes/get-all/subjects/{subjectID}");
            var body = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ApiErrorResult<List<ScoreTypeViewModel>>>(body);
        }
    }
}
