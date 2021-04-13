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
        private readonly IContestApiClient _contestApiClient;
        private readonly ISubjectApiClient _subjectApiClient;

        public SubjectController(IContestApiClient contestApiClient, ISubjectApiClient subjectApiClient)
        {
            _contestApiClient = contestApiClient;
            _subjectApiClient = subjectApiClient;
        }

        [HttpGet]
        public async Task<IActionResult> Details(string subjectID)
        {
            var getContestsBySubjectID = await _contestApiClient.GetAllContestsBySubjectID(subjectID);
            if (!getContestsBySubjectID.IsSuccessed)
            {
                return BadRequest(getContestsBySubjectID.Message);
            }

            var getSubject = await _subjectApiClient.GetByID(subjectID);
            ViewData["SubjectName"] = getSubject.ResultObj.Name;

            return View(getContestsBySubjectID.ResultObj);
        }


    }
}
