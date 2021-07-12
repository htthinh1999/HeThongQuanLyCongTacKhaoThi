using HeThongQuanLyCongTacKhaoThi.Application.Catalog.QuestionGroups;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.BackendAPI.Controllers
{
    [Authorize(Policy = Policy.All)]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionGroupsController : ControllerBase
    {
        private readonly IQuestionGroupService _questionGroupService;

        public QuestionGroupsController(IQuestionGroupService questionGroupService)
        {
            _questionGroupService = questionGroupService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _questionGroupService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _questionGroupService.GetByID(id);
            return Ok(result);
        }
    }
}