﻿using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Answers;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Questions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Services
{
    public class QuestionApiClient : IQuestionApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private IHttpContextAccessor _httpContextAccessor;

        public QuestionApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult<PagedResult<QuestionViewModel>>> GetQuestionPaging(GetQuestionPagingRequest request)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/questions/paging?pageIndex={request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}");
            var body = await response.Content.ReadAsStringAsync();
            var questions = JsonConvert.DeserializeObject<ApiSuccessResult<PagedResult<QuestionViewModel>>>(body);

            return questions;
        }

        public async Task<ApiResult<QuestionViewModel>> GetByID(int id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/questions/{id}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<QuestionViewModel>>(body);
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<QuestionViewModel>>(body);
        }

        public async Task<ApiResult<int>> Create(QuestionCreateUpdateRequest request, List<AnswerCreateUpdateRequest> answerCreateUpdateRequests)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            string subUri = "";
            if (request.IsMultipleChoice)
            {
                if (answerCreateUpdateRequests.Count > 0)
                {
                    subUri += $"?answers[{0}].Content={answerCreateUpdateRequests[0].Content}";
                    subUri += $"&answers[{0}].IsCorrect={answerCreateUpdateRequests[0].IsCorrect}";
                }

                for (int i = 1; i < answerCreateUpdateRequests.Count; i++)
                {
                    subUri += $"&answers[{i}].Content={answerCreateUpdateRequests[i].Content}";
                    subUri += $"&answers[{i}].IsCorrect={answerCreateUpdateRequests[i].IsCorrect}";
                }
            }

            var response = await client.PostAsync("/api/questions/create" + subUri, httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<int>>(result);
            }
            return JsonConvert.DeserializeObject<ApiErrorResult<int>>(result);
        }

        public async Task<ApiResult<bool>> Update(int id, QuestionCreateUpdateRequest request, List<AnswerCreateUpdateRequest> answerCreateUpdateRequests)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            string subUri = "";
            if (request.IsMultipleChoice)
            {
                if (answerCreateUpdateRequests.Count > 0)
                {
                    subUri += $"?answers[{0}].Content={answerCreateUpdateRequests[0].Content}";
                    subUri += $"&answers[{0}].IsCorrect={answerCreateUpdateRequests[0].IsCorrect}";
                }

                for (int i = 1; i < answerCreateUpdateRequests.Count; i++)
                {
                    subUri += $"&answers[{i}].Content={answerCreateUpdateRequests[i].Content}";
                    subUri += $"&answers[{i}].IsCorrect={answerCreateUpdateRequests[i].IsCorrect}";
                }
            }

            var response = await client.PutAsync($"/api/questions/{id}" + subUri, httpContent);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);
            }
            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.DeleteAsync($"/api/questions/{id}");
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
        }
    }
}
