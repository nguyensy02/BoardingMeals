using API.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IService;
using Services.Service;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Authorize(Roles = "admin, teacher")]
        [HttpGet("[action]")]
        public ActionResult GetAll() 
        {
            var students = _studentService.GetStudents();
            var result = students.Select(s => new StudentDTO
            {
                ClassId = s.ClassId,
                ClassName = s.Class.Name,
                ParentId = s.ParentId,
                ParentName = s.Parent.FullName,
                Dob = s.Dob,
                FullName = s.FullName,
                MealLevel = s.MealLevel
            }) ;
            return Ok(result);
        }


        [Authorize(Roles = "admin")]
        [HttpPost("[action]")]
        public IActionResult AddStudent(StudentDTO newStudentDTO)
        {
            var newStudent = new Student()
            {
                FullName = newStudentDTO.FullName,
                Dob = newStudentDTO.Dob,
                MealLevel = newStudentDTO.MealLevel,
                ClassId = newStudentDTO.ClassId,
                ParentId = newStudentDTO.ParentId,
            };
            _studentService.AddStudent(newStudent);
            return Ok();
        }
        [Authorize(Roles = "admin")]
        [HttpPut("[action]/{studentId}")]
        public IActionResult UpdateStudent(int studentId,[FromBody] StudentDTO newStudentDTO)
        {
            var student = _studentService.GetStudent(studentId);
            student.FullName = newStudentDTO.FullName;
            student.Dob = newStudentDTO.Dob;
            student.MealLevel = newStudentDTO.MealLevel;
            student.ClassId = newStudentDTO.ClassId;
            student.ParentId = newStudentDTO.ParentId;
            _studentService.UpdateStudent(student);
            return Ok();
        }

        [Authorize(Roles = "admin, teacher")]
        [HttpGet("[action]/{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _studentService.GetStudent(id);
            var result = new StudentDTO
            {
                ClassId = student.ClassId,
                ClassName = student.Class.Name,
                ParentId = student.ParentId,
                ParentName = student.Parent.FullName,
                Dob = student.Dob,
                FullName = student.FullName,
                MealLevel = student.MealLevel
            };
            return Ok(result);
        }
    }
}
