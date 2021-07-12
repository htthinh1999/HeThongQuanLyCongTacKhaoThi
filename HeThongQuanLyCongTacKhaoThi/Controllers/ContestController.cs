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
            var getExamsByContestID = await _examApiClient.GetAllExamsByContestID(contestID);
            if (!getExamsByContestID.IsSuccessed)
            {
                return BadRequest(getExamsByContestID.Message);
            }
            var exam = getExamsByContestID.ResultObj.Skip(new Random()
                                          .Next(getExamsByContestID.ResultObj.Count))
                                          .FirstOrDefault();
            if(exam == null)
            {
                return BadRequest("Kỳ kiểm tra này chưa có đề thi");
            }

            return RedirectToAction("Details", "Exam", new { examID = exam.ID });
        }
    }
}
