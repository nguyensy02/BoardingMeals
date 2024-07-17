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
            try
            {

                _dao.AddUser(user);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occurred while adding user: {user.Id}", e);
                throw new ApplicationException("An error occurred while adding the user. Please try again later.", e);
            }
        }

        public User GetById(int id)
        {
            try
            {
                return _dao.GetUserById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occurred while getting user", e);
                throw;
            }
        }

        public User GetUserByLogin(string username, string password)
        {
            return _dao.GetUserByLogin(username, password);
        }

        public User GetUserInfo(int id)
        {
            try
            {
                return _dao.GetUserInfo(id);
            }
            catch (Exception)
            {

                throw;
            }
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
            try
            {
                _dao.UpdateUser(user);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
