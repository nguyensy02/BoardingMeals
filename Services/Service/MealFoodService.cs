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
    public class MealFoodService : IMealFoodService
    {
        private MealFoodDAO _dao;

        public MealFoodService(MealFoodDAO dao)
        {
            _dao = dao;
        }

        public void AddMealFood(MealFood mealFood)
        {
            try
            {
                _dao.AddMealFood(mealFood);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteMealFood(MealFood mealFood)
        {
            try
            {
                _dao.DeleteMealFood(mealFood);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MealFood FindMealFood(int mealId, int foodId)
        {
            try
            {
                return _dao.FindMealFood(mealId, foodId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<MealFood> GetByMealId(int mealId)
        {
            try
            {
                return _dao.GetByMealId(mealId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
