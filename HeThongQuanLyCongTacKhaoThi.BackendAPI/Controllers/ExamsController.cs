﻿using HeThongQuanLyCongTacKhaoThi.Application.Catalog.ExamDetails;
using HeThongQuanLyCongTacKhaoThi.Application.Catalog.Exams;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.BackendAPI.Controllers
{
    [Authorize(Policy = Policy.All)]
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamService _examService;
        private readonly IExamDetailService _examDetailService;

        public ExamsController(IExamService examService, IExamDetailService examDetailService)
        {
            _examService = examService;
            _examDetailService = examDetailService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetExamPagingRequest request)
        {
            var result = await _examService.GetExamPaging(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _examService.GetByID(id);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ExamCreateRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _examService.Create(request);

            if (result.IsSuccessed)
            {
                request.ID = result.ResultObj;
                await _examDetailService.CreateAllExamDetailsForExam(request);
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ExamUpdateRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (request.ReRandom)
            {
                await Delete(id);
                var examCreateRequest = new ExamCreateRequest()
                {
                    ID = request.ID,
                    Name = request.Name,
                    MultipleChoiceQuestionCount = request.MultipleChoiceQuestionCount,
                    EssayQuestionCount = request.EssayQuestionCount,
                    ContestID = request.ContestID,
                    SubjectID = request.SubjectID,
                    QuestionGroups = request.QuestionGroups.ToList()
                };

                return await Create(examCreateRequest);
            }

            var result = await _examService.Update(id, request);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Remove all answers of question
            await _examDetailService.DeleteAllQuestionsByExamID(id);

            var result = await _examService.Delete(id);
            return Ok(result);
        }

        [HttpGet("contests/{contestID}")]
        public async Task<IActionResult> GetAllExamsByContestID(int contestID)
        {
            var result = await _examService.GetAllExamsByContestID(contestID);
            return Ok(result);
        }

        [HttpPut("{examID}/add-question-marks")]
        public async Task<IActionResult> AddMaxQuestionMark(int examID, List<ExamDetailCURequest> examDetails)
        {
            var result = await _examDetailService.AddMaxQuestionMark(examID, examDetails);
            return Ok(result);
        }
    }
}