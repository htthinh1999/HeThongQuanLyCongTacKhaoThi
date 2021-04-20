using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Contests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Controllers
{
    [Authorize(Policy = Policy.Manager)]
    public class ContestController : Controller
    {
        private readonly IContestApiClient _contestApiClient;
        private readonly ISubjectApiClient _subjectApiClient;
        private readonly IScoreTypeApiClient _scoreTypeApiClient;

        public ContestController(IContestApiClient contestApiClient, ISubjectApiClient subjectApiClient, IScoreTypeApiClient scoreTypeApiClient)
        {
            _contestApiClient = contestApiClient;
            _subjectApiClient = subjectApiClient;
            _scoreTypeApiClient = scoreTypeApiClient;
        }

        public async Task<IActionResult> Index(string keyword = " ", int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetContestPagingRequest
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _contestApiClient.GetContestPaging(request);

            ViewBag.SuccessMsg = TempData["SuccessMsg"];
            return View(data.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var request = new ContestCURequest();
            // Get subjects
            var getSubjects = await _subjectApiClient.GetAll();
            var subjects = getSubjects.ResultObj;
            request.Subjects = subjects.ToList();

            // Get score types
            var getScoreTypes = await _scoreTypeApiClient.GetAllBySubjectID(subjects[0].ID);
            var scoreTypes = getScoreTypes.ResultObj;
            request.ScoreTypes = scoreTypes.ToList();

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContestCURequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var result = await _contestApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["SuccessMsg"] = "Tạo kỳ kiểm tra thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message); 
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _contestApiClient.GetByID(id);
            if (result.IsSuccessed)
            {
                var contest = result.ResultObj;
                var updateResquest = new ContestCURequest()
                {
                    ID = contest.ID,
                    Name = contest.Name,
                    SubjectID = contest.SubjectID,
                    ScoreTypeID = contest.ScoreTypeID
                };

                // Get subjects
                var getSubjects = await _subjectApiClient.GetAll();
                var subjects = getSubjects.ResultObj;
                updateResquest.Subjects = subjects.ToList();

                // Get score types
                var getScoreTypes = await _scoreTypeApiClient.GetAllBySubjectID(updateResquest.SubjectID);
                var scoreTypes = getScoreTypes.ResultObj;
                updateResquest.ScoreTypes = scoreTypes.ToList();

                return View(updateResquest);
            }

            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContestCURequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _contestApiClient.Update(request.ID, request);

            if (!result.IsSuccessed)
            {
                ModelState.AddModelError("", result.Message);
                return View(request);
            }

            TempData["SuccessMsg"] = "Cập nhật kỳ kiểm tra thành công";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _contestApiClient.GetByID(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result.Message);
            }
            return View(result.ResultObj);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _contestApiClient.GetByID(id);
            if (!result.IsSuccessed)
            {
                return BadRequest(result.Message);
            }
            return View(result.ResultObj);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ContestViewModel request)
        {
            var result = await _contestApiClient.Delete(request.ID);
            if (!result.IsSuccessed)
            {
                return BadRequest(result.Message);
            }

            TempData["SuccessMsg"] = "Xoá kỳ kiểm tra thành công";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetSubjectIDByContestID(int contestID)
        {
            var getSubjectID = await _contestApiClient.GetSubjectIDByContestID(contestID);

            return Json(new
            {
                success = true,
                SubjectID = getSubjectID.ResultObj
            });
        }
    }
}
