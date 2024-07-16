using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MealDAO
    {
        private readonly BoardingMealsContext _context;

        public MealDAO(BoardingMealsContext context)
        {
            _context = context;
        }

        public List<Meal> GetMealList() => _context.Meals.ToList();

        public Meal GetMealById(int id)
        {
            return _context.Meals.FirstOrDefault(meal => meal.Id == id);
        }

        public int AddMeal(Meal meal)
        {
            _context.Meals.Add(meal);
            _context.SaveChanges();
            return meal.Id;
        }

        public void UpdateMeal(Meal meal)
        {
            _context.Entry(meal).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteMeal(Meal meal)
        {
            _context.Meals.Remove(meal);
            _context.SaveChanges();
        }

        public List<Meal> GetMealByDate(DateTime fromDate, DateTime toDate)
        {
            return _context.Meals
                .Include(m => m.MealFoods)
                .ThenInclude(mf => mf.Food)
                .Where(m => m.Day >= fromDate && m.Day <= toDate)
                .ToList();
        }
    }
}
