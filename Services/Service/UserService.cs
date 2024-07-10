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
    public class UserService : IUserService
    {
        private readonly UserDAO _dao;  
        public UserService(UserDAO dao)
        {
            _dao = dao;
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserByLogin(string username, string password)
        {
            return _dao.GetUserByLogin(username, password);
        }

        public List<User> GetUsers()
        {
            try
            {
                return _dao.GetUserList();

            } catch
            {
                return null;
            }
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
