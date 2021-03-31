using HeThongQuanLyCongTacKhaoThi.Application.Catalog.Answers;
using HeThongQuanLyCongTacKhaoThi.Application.Catalog.Questions;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Questions;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Create([FromBody] QuestionCURequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _questionService.Create(request);

            if (result.IsSuccessed && request.IsMultipleChoice)
            {
                foreach (var ans in request.Answers)
                {
                    ans.QuestionID = result.ResultObj;
                    await _answerService.Create(ans);
                }
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] QuestionCURequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Cannot update question when it was existed in an exam
            // Only allow update when it's same old question's type and group id
            // (do NOT change type: multiple choice question <-/-> essay question)
            // (do NOT change group id)
            var existQuestionInExam = _questionService.ExistQuestionInExam(id);
            if (existQuestionInExam.ResultObj)
            {
                var getQuestion = await _questionService.GetByID(id);
                var question = getQuestion.ResultObj;
                if (question.IsMultipleChoice != request.IsMultipleChoice
                    || question.GroupID != request.GroupID)
                {
                    existQuestionInExam.Message = "Không thể thay đổi loại câu hỏi hoặc nhóm câu hỏi! Câu hỏi này đã được sử dụng trong đề thi!";
                    return Ok(existQuestionInExam);
                }
            }

            var result = await _questionService.Update(id, request);
            if (!result.IsSuccessed)
            {
                return Ok(result);
            }

            // Remove all old answers
            await _answerService.DeleteAllAnswersByQuestionID(id);

            if (request.IsMultipleChoice)
            {
                // Create answers was updated
                foreach (var ans in request.Answers)
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
            var existQuestionInExam = _questionService.ExistQuestionInExam(id);

            // Cannot delete question when it was existed in an exam
            if (!existQuestionInExam.ResultObj)
            {
                // Remove all answers of question
                await _answerService.DeleteAllAnswersByQuestionID(id);

                var result = await _questionService.Delete(id);
                return Ok(result);
            }

            existQuestionInExam.Message = "Không thể xoá câu hỏi! Câu hỏi đã được sử dụng trong đề thi!";
            return Ok(existQuestionInExam);
        }
    }
}