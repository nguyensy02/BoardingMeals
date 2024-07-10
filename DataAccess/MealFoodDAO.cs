using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MealFoodDAO
    {
        private readonly BoardingMealsContext _context;

        public MealFoodDAO(BoardingMealsContext context)
        {
            _context = context;
        }

        public List<MealFood> GetMealFoodList() => _context.MealFoods.ToList();

        public MealFood GetMealFoodById(int id)
        {
            return _context.MealFoods.FirstOrDefault(mealFood => mealFood.Id == id);
        }

        public void AddMealFood(MealFood mealFood)
        {
            _context.MealFoods.Add(mealFood);
            _context.SaveChanges();
        }

        public void UpdateMealFood(MealFood mealFood)
        {
            _context.Entry(mealFood).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteMealFood(MealFood mealFood)
        {
            _context.MealFoods.Remove(mealFood);
            _context.SaveChanges();
        }
    }
}
