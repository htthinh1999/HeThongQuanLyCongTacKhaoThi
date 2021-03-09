using HeThongQuanLyCongTacKhaoThi.Application.System;
using HeThongQuanLyCongTacKhaoThi.Application.System.Answers;
using HeThongQuanLyCongTacKhaoThi.Application.System.Questions;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Answers;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Questions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;

        public QuestionsController(IQuestionService questionService, IAnswerService answerService)
        {
            _questionService = questionService;
            _answerService = answerService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetQuestionPagingRequest request)
        {
            var result = await _questionService.GetQuestionPaging(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _questionService.GetByID(id);
            return Ok(result);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] QuestionCreateUpdateRequest request, [FromQuery] List<AnswerCreateUpdateRequest> answers)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            request.answerCreateUpdateRequests = answers;
            var result = await _questionService.Create(request);

            if (result.IsSuccessed && request.IsMultipleChoice)
            {
                foreach(var ans in request.answerCreateUpdateRequests)
                {
                    ans.QuestionID = result.ResultObj;
                    await _answerService.Create(ans);
                }
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] QuestionCreateUpdateRequest request, [FromQuery] List<AnswerCreateUpdateRequest> answers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _questionService.Update(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result.Message);
            }

            // Remove all old answers
            await _answerService.DeleteAllAnswersByQuestionID(id);

            if (request.IsMultipleChoice)
            {

                // Create answers was updated
                foreach (var ans in answers)
                {
                    if (!string.IsNullOrEmpty(ans.Content))
                    {
                        ans.QuestionID = id;
                        await _answerService.Create(ans);
                    }
                }
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Remove all answers of question
            await _answerService.DeleteAllAnswersByQuestionID(id);

            var result = await _questionService.Delete(id);
            return Ok(result);
        }

    }
}
