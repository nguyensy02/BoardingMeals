using API.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IService;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [Authorize(Roles = "admin, teacher")]
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var classes = _classService.GetClasses().ToList();
            var result = classes.Select(c => new ClassDTO
            {
                Id=c.Id,
                Name = c.Name,
            });
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("[action]")]
        public IActionResult AddClass([FromBody] ClassDTO newClassDTO) 
        {
            var newClass = new Class()
            {
                Name = newClassDTO.Name,
            };
            _classService.AddClass(newClass);
            return Ok();
        }
        [Authorize(Roles = "admin")]
        [HttpPut("[action]/{classId}")]
        public IActionResult UpdateClass(int classId, [FromBody] ClassDTO newClassDTO)
        {
            var classModel = _classService.GetClassById(classId);
            classModel.Name = newClassDTO.Name;
            _classService.UpdateClass(classModel);
            return Ok();
        }

        [Authorize(Roles = "admin, teacher")]
        [HttpGet("[action]/{id}")]
        public IActionResult GetClass(int id)
        {
            var classModel = _classService.GetClassById(id);
            var result = new ClassDTO
            {
                Name = classModel.Name,
            };
            return Ok(result);
        }

    }
}
