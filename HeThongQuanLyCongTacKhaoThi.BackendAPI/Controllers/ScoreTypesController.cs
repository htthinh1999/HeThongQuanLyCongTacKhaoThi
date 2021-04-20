using HeThongQuanLyCongTacKhaoThi.Application.Catalog.ScoreTypes;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
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
    public class ScoreTypesController : ControllerBase
    {
        private readonly IScoreTypeService _scoreTypeService;

        public ScoreTypesController(IScoreTypeService scoreTypeService)
        {
            _scoreTypeService = scoreTypeService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _scoreTypeService.GetAll();
            return Ok(result);
        }

        [HttpGet("get-all/subjects/{subjectID}")]
        public async Task<IActionResult> GetAllBySubjectID(string subjectID)
        {
            var result = await _scoreTypeService.GetAllBySubjectID(subjectID);
            return Ok(result);
        }
    }
}
