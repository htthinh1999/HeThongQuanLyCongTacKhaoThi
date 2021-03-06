﻿using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Answers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Controllers
{
    [Authorize(Policy = Policy.Manager)]
    public class AnswerController : Controller
    {
        private readonly IAnswerApiClient _answerApiClient;

        public AnswerController(IAnswerApiClient answerApiClient)
        {
            _answerApiClient = answerApiClient;
        }

        public async Task<IActionResult> Index(string keyword = " ", int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetAnswerPagingRequest
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _answerApiClient.GetAnswerPaging(request);

            ViewBag.SuccessMsg = TempData["SuccessMsg"];
            return View(data.ResultObj);
        }
    }
}