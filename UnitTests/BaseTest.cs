using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class BaseTest
    {
        protected ClassDAO classDAO;
        protected UserDAO userDAO;
        protected FoodDAO foodDAO;
        protected MealDAO mealDAO;
        protected StudentDAO studentDAO;
        protected MealFoodDAO mealFoodDAO;
        protected NoteDAO noteDAO;
        protected BoardingMealsContext context;

        public BaseTest() {
            context = new BoardingMealsContext();
            classDAO = new ClassDAO(context);
            userDAO = new UserDAO(context);
            foodDAO = new FoodDAO(context);
            mealFoodDAO = new MealFoodDAO(context);
            studentDAO = new StudentDAO(context);
            mealDAO = new MealDAO(context);
        }
    }
}
