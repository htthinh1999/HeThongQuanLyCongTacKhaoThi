using HeThongQuanLyCongTacKhaoThi.Application.Catalog.Results;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public ResultsController(IResultService resultService)
        {
            _resultService = resultService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ResultCURequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _resultService.Create(request);
            return Ok(result);
        }

        [HttpGet("get-exam-result")]
        public async Task<IActionResult> GetExamResult([FromQuery] Guid accountID, [FromQuery] int contestID)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _resultService.GetExamResult(accountID, contestID);
            return Ok(result);
        }
    }
}
