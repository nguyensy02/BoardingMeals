using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StudentDAO
    {
        private readonly BoardingMealsContext _context;

        public StudentDAO(BoardingMealsContext context)
        {
            _context = context;
        }

        public List<Student> GetStudentList() => _context.Students
            .Include(s => s.Class)
            .Include(s=> s.Parent)
            .ToList();

        public Student GetStudentById(int id)
        {
            return _context.Students
                .Include(s=>s.Class)
                .Include(s=>s.Parent)
                .FirstOrDefault(student => student.Id == id);
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

    }
}
