using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Controllers
{
    [Authorize(Policy = Policy.Manager)]
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