using HeThongQuanLyCongTacKhaoThi.Application.System.Answers;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Answers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswersController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetAnswerPagingRequest request)
        {
            var result = await _answerService.GetAnswerPaging(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _answerService.GetByID(id);
            return Ok(result);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AnswerCreateUpdateRequest request, [FromQuery] List<AnswerCreateUpdateRequest> answers)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _answerService.Create(request);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AnswerCreateUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _answerService.Update(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _answerService.Delete(id);
            return Ok(result);
        }

    }
}
