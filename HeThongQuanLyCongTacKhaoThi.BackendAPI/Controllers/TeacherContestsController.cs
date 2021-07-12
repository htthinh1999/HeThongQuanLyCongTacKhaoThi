using HeThongQuanLyCongTacKhaoThi.Application.Catalog.TeacherContests;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.TeacherContests;
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
    public class TeacherContestsController : ControllerBase
    {
        private readonly ITeacherContestService _teacherContestService;

        public TeacherContestsController(ITeacherContestService teacherContestService)
        {
            _teacherContestService = teacherContestService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] TeacherContestCURequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _teacherContestService.Create(request);
            return Ok(result);
        }

        [HttpDelete("{contestID}")]
        public async Task<IActionResult> Delete(int contestID)
        {
            var result = await _teacherContestService.Delete(contestID);
            return Ok(result);
        }
    }
}
