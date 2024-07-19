using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IService
{
    public interface IStudentService
    {
        List<Student> GetStudents();

        Student GetStudent(int id);

        void AddStudent(Student student);

        void UpdateStudent(Student student); 

        List<Student> GetStudentsByClassId(int classId);
    }
}
