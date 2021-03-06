﻿using HeThongQuanLyCongTacKhaoThi.Application.Catalog.Results;
using HeThongQuanLyCongTacKhaoThi.BackendAPI.HubServices;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.BackendAPI.Controllers
{
    [Authorize(Policy = Policy.All)]
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IResultService _resultService;
        private readonly INotificationHubService _notificationService;

        public ResultsController(IResultService resultService, INotificationHubService notificationService)
        {
            _resultService = resultService;
            _notificationService = notificationService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ResultCURequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _resultService.Create(request);

            if (result.IsSuccessed)
            {
                await _notificationService.StudentSubmited(request.ContestID, request.StudentAnswerID);
            }

            return Ok(result);
        }

        [HttpGet("get-exam-result-paging")]
        public async Task<IActionResult> GetExamResultPaging([FromQuery] GetExamResultPagingRequest request)
        {
            var result = await _resultService.GetExamResultPaging(request);
            return Ok(result);
        }

        [HttpGet("get-exam-result")]
        public async Task<IActionResult> GetExamResult([FromQuery] Guid accountID, [FromQuery] int contestID)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _resultService.GetExamResult(accountID, contestID);
            return Ok(result);
        }

        [HttpGet("get-exam-result-by-student-answer-id")]
        public async Task<IActionResult> GetExamResult([FromQuery] Guid studentAnswerID, [FromQuery] Guid teacherID)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _resultService.GetExamResult(studentAnswerID, teacherID);
            return Ok(result);
        }

        [HttpGet("get-exam-result-to-mark")]
        public async Task<IActionResult> GetExamResultToMark([FromQuery] Guid studentAnswerID, [FromQuery] Guid teacherID)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _resultService.GetExamResultToMark(studentAnswerID, teacherID);
            return Ok(result);
        }

        [HttpGet("get-teacher-number")]
        public async Task<IActionResult> GetTeacherNumber([FromQuery] Guid studentAnswerID, [FromQuery] Guid teacherID)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _resultService.GetTeacherNumber(studentAnswerID, teacherID);
            return Ok(result);
        }

        [HttpPost("mark-exam")]
        public async Task<IActionResult> MarkExam([FromQuery]Guid teacherID, [FromBody]MarkExamRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _resultService.MarkExam(teacherID, request.StudentAnswerID, request.QuestionMarked, request.QuestionCommented);
            return Ok(result);
        }

        [HttpGet("score-list")]
        public async Task<IActionResult> ScoreList([FromQuery] Guid teacherID)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _resultService.GetScoreList(teacherID);
            return Ok(result);
        }

        [HttpGet("score-list/student-id/{studentID}")]
        public async Task<IActionResult> ScoreListByStudentID(Guid studentID)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _resultService.GetScoreListByStudentID(studentID);
            return Ok(result);
        }
    }
}
