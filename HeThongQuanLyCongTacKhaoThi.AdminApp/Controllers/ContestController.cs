using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Contests;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.TeacherContests;
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
        private readonly IAccountApiClient _accountApiClient;
        private readonly ITeacherContestApiClient _teacherContestApiClient;

        public ContestController(IContestApiClient contestApiClient,
                                ISubjectApiClient subjectApiClient,
                                IScoreTypeApiClient scoreTypeApiClient,
                                IAccountApiClient accountApiClient,
                                ITeacherContestApiClient teacherContestApiClient)
        {
            _contestApiClient = contestApiClient;
            _subjectApiClient = subjectApiClient;
            _scoreTypeApiClient = scoreTypeApiClient;
            _accountApiClient = accountApiClient;
            _teacherContestApiClient = teacherContestApiClient;
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

            // Get all teachers
            var getTeachers = await _accountApiClient.GetAllTeachers();
            var teachers = getTeachers.ResultObj;
            request.Teachers = teachers.ToList();

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContestCURequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var getContestID = await _contestApiClient.Create(request);
            if (getContestID.IsSuccessed)
            {
                await _teacherContestApiClient.Create(new TeacherContestCURequest()
                {
                    TeacherID = request.Teacher1ID,
                    ContestID = getContestID.ResultObj
                });

                if (!request.Teacher2ID.Equals(Guid.Empty))
                {
                    await _teacherContestApiClient.Create(new TeacherContestCURequest()
                    {
                        TeacherID = request.Teacher2ID,
                        ContestID = getContestID.ResultObj
                    });
                }

                TempData["SuccessMsg"] = "Tạo kỳ kiểm tra thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", getContestID.Message); 
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _contestApiClient.GetByID(id);
            if (result.IsSuccessed)
            {
                var contest = result.ResultObj;
                var updateRequest = new ContestCURequest()
                {
                    ID = contest.ID,
                    Name = contest.Name,
                    SubjectID = contest.SubjectID,
                    ScoreTypeID = contest.ScoreTypeID,
                    StartTime = contest.StartTime,
                    Duration = contest.Duration,
                    Description = contest.Description,
                    Teacher1ID = contest.Teacher1ID,
                    Teacher2ID = contest.Teacher2ID
                };

                // Get subjects
                var getSubjects = await _subjectApiClient.GetAll();
                var subjects = getSubjects.ResultObj;
                updateRequest.Subjects = subjects.ToList();

                // Get score types
                var getScoreTypes = await _scoreTypeApiClient.GetAllBySubjectID(updateRequest.SubjectID);
                var scoreTypes = getScoreTypes.ResultObj;
                updateRequest.ScoreTypes = scoreTypes.ToList();

                // Get all teachers
                var getTeachers = await _accountApiClient.GetAllTeachers();
                var teachers = getTeachers.ResultObj;
                updateRequest.Teachers = teachers.ToList();

                return View(updateRequest);
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


            await _teacherContestApiClient.Delete(request.ID);

            await _teacherContestApiClient.Create(new TeacherContestCURequest()
            {
                TeacherID = request.Teacher1ID,
                ContestID = request.ID
            });

            if (!request.Teacher2ID.Equals(Guid.Empty))
            {
                await _teacherContestApiClient.Create(new TeacherContestCURequest()
                {
                    TeacherID = request.Teacher2ID,
                    ContestID = request.ID
                });
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
