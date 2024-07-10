using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class UserDAOTest:BaseTest
    {
        [Test]
        public void GetUserByLoginTest()
        {
            var user = userDAO.GetUserByLogin("teacher", "teacher");
            Console.WriteLine($"Username {user.UserName}");
            Console.WriteLine($"Role {user.Role.Name}");
            Assert.IsNotNull(user);
        }
    }
}
