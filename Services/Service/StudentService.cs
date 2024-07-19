using BusinessObject.Models;
using DataAccess;
using Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class StudentService : IStudentService
    {
        private readonly StudentDAO _dao;
        public StudentService(StudentDAO dao)
        {
            _dao = dao;
        }
        public void AddStudent(Student student)
        {
            try
            {
                _dao.AddStudent(student);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Student GetStudent(int id)
        {
            try
            {
                return _dao.GetStudentById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Student> GetStudents()
        {
            try
            {
                return _dao.GetStudentList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Student> GetStudentsByClassId(int classId)
        {
            try
            {
                return _dao.GetStudentsByClassId(classId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Student> GetStudentsByParentId(int parentId)
        {
            try
            {
                return _dao.GetStudentsByParentId(parentId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateStudent(Student student)
        {
            try
            {
                _dao.UpdateStudent(student);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
