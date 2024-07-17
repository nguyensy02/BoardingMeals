using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDAO
    {
        private readonly BoardingMealsContext _context;

        public UserDAO(BoardingMealsContext context)
        {
            _context = context;
        }

        public List<User> GetUserList() => _context.Users.ToList();

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(User u)
        {
            _context.Users.Add(u);
            _context.SaveChanges();
        }

        public void UpdateUser(User u)
        {
            _context.Entry(u).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteUser(User u)
        {
            _context.Users.Remove(u);
            _context.SaveChanges();
        }

        public User GetUserByLogin(string username, string password)
        {
            var user = _context.Users.Include(u => u.Role).FirstOrDefault(u => u.UserName == username && u.Password == password);
            return user;
        }

        public User GetUserInfo(int id)
        {
            return _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Id == id);
        }
    }
}
