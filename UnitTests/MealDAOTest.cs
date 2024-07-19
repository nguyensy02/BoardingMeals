using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class MealDAOTest : BaseTest
    {
        [Test]
        public void IsExistMealTest()
        {
            int chefId = 2;
            DateTime day = DateTime.Parse("2024-07-16");
            int slot = 1;
            var classes = mealDAO.IsExistMeal(chefId, day, slot);
            Console.WriteLine(classes);
        }
    }
}
