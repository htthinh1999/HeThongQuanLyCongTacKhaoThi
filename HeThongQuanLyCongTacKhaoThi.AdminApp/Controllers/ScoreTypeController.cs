using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Controllers
{
    public class ScoreTypeController : Controller
    {
        private readonly IScoreTypeApiClient _scoreTypeApiClient;

        public ScoreTypeController(IScoreTypeApiClient scoreTypeApiClient)
        {
            _scoreTypeApiClient = scoreTypeApiClient;
        }

        public async Task<IActionResult> GetAllBySubjectID(string subjectID)
        {
            var scoreTypes = await _scoreTypeApiClient.GetAllBySubjectID(subjectID);
            return PartialView("_ScoreType", scoreTypes.ResultObj);
        }
    }
}
