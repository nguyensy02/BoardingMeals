using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IService
{
    public interface IUserService
    {
       User GetUserByLogin(string username, string password) ;
        List<User> GetUsers() ;

        void UpdateUser(User user) ;

        void AddUser(User user) ;
    }
}
    