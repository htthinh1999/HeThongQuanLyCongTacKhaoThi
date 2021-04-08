using HeThongQuanLyCongTacKhaoThi.Application.Catalog.StudentAnswerDetails;
using HeThongQuanLyCongTacKhaoThi.Application.Catalog.StudentAnswers;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.StudentAnswers;
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
    public class StudentAnswersController : ControllerBase
    {
        private readonly IStudentAnswerService _studentAnswerService;
        private readonly IStudentAnswerDetailService _studentAnswerDetailService;

        public StudentAnswersController(IStudentAnswerService studentAnswerService, IStudentAnswerDetailService studentAnswerDetailService)
        {
            _studentAnswerService = studentAnswerService;
            _studentAnswerDetailService = studentAnswerDetailService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] StudentAnswerCreateRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _studentAnswerService.Create(request);

            if (result.IsSuccessed)
            {
                foreach(var studentAnwserDetail in request.studentAnswerDetails)
                {
                    studentAnwserDetail.StudentAnswerID = result.ResultObj;
                    await _studentAnswerDetailService.Create(studentAnwserDetail);
                }
            }

            return Ok(result);
        }

    }
}
