using HeThongQuanLyCongTacKhaoThi.Application.Catalog.Contests;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Contests;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
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
    public class ContestsController : ControllerBase
    {
        private readonly IContestService _contestService;

        public ContestsController(IContestService contestService)
        {
            _contestService = contestService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _contestService.GetAll();
            return Ok(result);
        }

        [HttpGet("get-all-by-subject")]
        public async Task<IActionResult> GetAllContestsBySubjectID([FromQuery]string subjectID)
        {
            var result = await _contestService.GetAllContestsBySubjectID(subjectID);
            return Ok(result);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetContestPagingRequest request)
        {
            var result = await _contestService.GetContestPaging(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _contestService.GetByID(id);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ContestCURequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _contestService.Create(request);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContestCURequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var getContest = await _contestService.GetByID(id);
            var contest = getContest.ResultObj;

            if (contest.SubjectID != request.SubjectID)
            {
                var contestWasUsedInExam = await _contestService.ContestWasUsedInExam(id);
                if (contestWasUsedInExam.IsSuccessed)
                {
                    return BadRequest(contestWasUsedInExam.Message);
                }
            }

            var result = await _contestService.Update(id, request);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contestWasUsedInExam = await _contestService.ContestWasUsedInExam(id);
            if (contestWasUsedInExam.IsSuccessed)
            {
                return BadRequest(contestWasUsedInExam.Message);
            }

            var result = await _contestService.Delete(id);
            return Ok(result);
        }

        [HttpGet("{contestID}/subject")]
        public async Task<IActionResult> GetSubjectIDByContestID(int contestID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _contestService.GetSubjectIDByContestID(contestID);
            return Ok(result);
        }
    }
}
