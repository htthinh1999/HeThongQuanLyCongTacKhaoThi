using System.Threading.Tasks;
using HeThongQuanLyCongTacKhaoThi.Application.Catalog.Classes;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Classes;
using Microsoft.AspNetCore.Mvc;

namespace HeThongQuanLyCongTacKhaoThi.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPaging([FromQuery]ClassPagingRequest request)
        {
            var classes = await _classService.GetAllPaging(request);
            return Ok(classes);
        }

        [HttpGet("{classID}")]
        public async Task<IActionResult> GetByID(string classID)
        {
            var _class = await _classService.GetByID(classID);
            if(_class == null)
            {
                return BadRequest("Cannot find product");
            }
            return Ok(_class);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ClassCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classID = await _classService.Create(request);
            if (classID == null)
            {
                return BadRequest();
            }

            var _class = await _classService.GetByID(classID);
            return CreatedAtAction(nameof(GetByID), new { classID = classID }, _class);
        }

        [HttpPatch("name/{classID}/{name}")]
        public async Task<IActionResult> UpdateName(string classID, string name)
        {
            var result = await _classService.UpdateName(classID, name);
            if (!result)
            {
                return BadRequest();
            }
            var _class = await _classService.GetByID(classID);
            return CreatedAtAction(nameof(GetByID), new { classID = classID }, _class);
        }

        [HttpPatch("increase")]
        public async Task<IActionResult> IncreaseStudentCount([FromQuery] string classID, int count)
        {
            var result = await _classService.IncreaseStudentCount(classID, count);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPatch("decrease")]
        public async Task<IActionResult> DecreaseStudentCount([FromQuery] string classID, int count)
        {
            var result = await _classService.DecreaseStudentCount(classID, count);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }



        [HttpDelete("{classID}")]
        public async Task<IActionResult> Delete(string classID)
        {
            var result = await _classService.Delete(classID);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
