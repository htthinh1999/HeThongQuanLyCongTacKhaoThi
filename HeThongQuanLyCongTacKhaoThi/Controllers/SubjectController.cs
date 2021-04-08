using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.WebApp.Controllers
{
    [Authorize(Policy = Policy.Student)]
    public class SubjectController : Controller
    {
        private readonly IExamApiClient _examApiClient;
        private readonly ISubjectApiClient _subjectApiClient;

        public SubjectController(IExamApiClient examApiClient, ISubjectApiClient subjectApiClient)
        {
            _examApiClient = examApiClient;
            _subjectApiClient = subjectApiClient;
        }

        [HttpGet]
        public async Task<IActionResult> Details(string subjectID)
        {
            var getExamsBySubjectID = await _examApiClient.GetAllExamsBySubjectID(subjectID);
            if (!getExamsBySubjectID.IsSuccessed)
            {
                return BadRequest(getExamsBySubjectID.Message);
            }

            var getSubject = await _subjectApiClient.GetByID(subjectID);
            ViewData["SubjectName"] = getSubject.ResultObj.Name;

            return View(getExamsBySubjectID.ResultObj);
        }


    }
}
