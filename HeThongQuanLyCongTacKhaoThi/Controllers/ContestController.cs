using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.WebApp.Controllers
{
    public class ContestController : Controller
    {
        private readonly IExamApiClient _examApiClient;

        public ContestController(IExamApiClient examApiClient)
        {
            _examApiClient = examApiClient;
        }

        public async Task<IActionResult> RandomExamFollowContestID(int contestID)
        {
            var getExamsBySubjectID = await _examApiClient.GetAllExamsByContestID(contestID);
            if (!getExamsBySubjectID.IsSuccessed)
            {
                return BadRequest(getExamsBySubjectID.Message);
            }
            var exam = getExamsBySubjectID.ResultObj.Skip(new Random()
                                          .Next(getExamsBySubjectID.ResultObj.Count))
                                          .FirstOrDefault();
            return RedirectToAction("Details", "Exam", new { examID = exam.ID });
        }
    }
}
