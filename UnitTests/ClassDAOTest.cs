using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class ClassDAOTest: BaseTest
    {
        [Test]
        public void GetClassListTest() {
            var classes = classDAO.GetClassList();
            Console.WriteLine(classes);
            Assert.IsNotNull(classes);
        }   
    }
}
