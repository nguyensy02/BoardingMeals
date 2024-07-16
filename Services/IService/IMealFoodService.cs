using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IService
{
    public interface IMealFoodService
    {
        void AddMealFood(MealFood mealFood);

        void DeleteMealFood(MealFood mealFood);

        MealFood FindMealFood(int mealId, int foodId);

        List<MealFood> GetByMealId(int mealId);
    }
}
