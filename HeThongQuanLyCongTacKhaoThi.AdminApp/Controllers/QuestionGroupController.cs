using HeThongQuanLyCongTacKhaoThi.AdminApp.Services;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.QuestionGroups;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Controllers
{
    public class QuestionGroupController : Controller
    {
        private readonly IQuestionGroupApiClient _questionGroupApiClient;
        public QuestionGroupController(IQuestionGroupApiClient questionGroupApiClient)
        {
            _questionGroupApiClient = questionGroupApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GetAllQuestionGroup(int id)
        {
            var getQuestionGroups = await _questionGroupApiClient.GetAll();
            var questionGroups = getQuestionGroups.ResultObj;

            ViewData["QuestionGroups"] = new SelectList(questionGroups, "ID", "Name");
            return PartialView("_QuestionGroup", id);
        }
    }
}
