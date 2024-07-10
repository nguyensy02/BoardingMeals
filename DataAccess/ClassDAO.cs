using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ClassDAO
    {
        private readonly BoardingMealsContext _context;

        public ClassDAO(BoardingMealsContext context)
        {
            _context = context;
        }

        public List<Class> GetClassList() => _context.Classes.ToList();

        public Class GetClassById(int id)
        {
            return _context.Classes.FirstOrDefault(c => c.Id == id);
        }

        public void AddClass(Class c)
        {
            _context.Classes.Add(c);
            _context.SaveChanges();
        }

        public void UpdateClass(Class c) { 
            _context.Entry(c).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Class GetClassByName(string name) {
            return _context.Classes.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
        }
    }
}
