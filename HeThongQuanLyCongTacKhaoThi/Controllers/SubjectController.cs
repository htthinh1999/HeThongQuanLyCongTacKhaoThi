using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Contests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            var currentAccountID = new Guid(HttpContext.Session.GetString("UserID"));

            var getContestsDidNotJoin = await _contestApiClient.GetAllContestsDidNotJoin(currentAccountID, subjectID);
            if (!getContestsDidNotJoin.IsSuccessed)
            {
                return BadRequest(getContestsDidNotJoin.Message);
            }

            var getContestsWasJoined = await _contestApiClient.GetAllContestsWasJoined(currentAccountID, subjectID);
            if (!getContestsWasJoined.IsSuccessed)
            {
                return BadRequest(getContestsWasJoined.Message);
            }

            var getSubject = await _subjectApiClient.GetByID(subjectID);
            ViewData["SubjectName"] = getSubject.ResultObj.Name;

            var list2Contests = new Tuple<List<ContestViewModel>, List<ContestViewModel>>(getContestsDidNotJoin.ResultObj, getContestsWasJoined.ResultObj);

            return View(list2Contests);
        }

    }
}
