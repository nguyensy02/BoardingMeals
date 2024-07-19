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
    public class ChildrenController : ControllerBase
    {
        private IStudentService _studentService;

        public ChildrenController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        //children
        [Authorize(Roles = "parent")]
        [HttpGet("[action]/{parentId}")]
        public IActionResult GetByParentId(int parentId) 
        {
            var childrens = _studentService.GetStudentsByParentId(parentId);
            var result = childrens.Select(s => new StudentDTO
            {
                Id = s.Id,
                ClassId = s.ClassId,
                ClassName = s.Class.Name,
                ParentId = s.ParentId,
                ParentName = s.Parent.FullName,
                Dob = s.Dob,
                FullName = s.FullName,
                MealLevel = s.MealLevel
            });
            return Ok(result);
        }
    }
}
