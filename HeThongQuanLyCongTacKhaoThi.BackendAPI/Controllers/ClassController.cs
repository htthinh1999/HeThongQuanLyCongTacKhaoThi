using System.Threading.Tasks;
using HeThongQuanLyCongTacKhaoThi.Application.Catalog.Classes;
using Microsoft.AspNetCore.Mvc;

namespace HeThongQuanLyCongTacKhaoThi.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var classes = await _classService.GetAllPaging(new ViewModels.Catalog.Classes.ClassPagingRequest() { Keyword = "Đại học công nghệ", PageIndex = 1, PageSize = 20 });
            return Ok(classes);
        }
    }
}
