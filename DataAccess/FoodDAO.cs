using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FoodDAO
    {
        private readonly BoardingMealsContext _context;

        public FoodDAO(BoardingMealsContext context)
        {
            _context = context;
        }

        public List<Food> GetFoodList() => _context.Foods.ToList();

        public Food GetFoodById(int id)
        {
            return _context.Foods.FirstOrDefault(u => u.Id == id);
        }

        public void AddFood(Food food)
        {
            _context.Foods.Add(food);
            _context.SaveChanges();
        }

        public void UpdateFood(Food food)
        {
            _context.Entry(food).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteFood(Food food)
        {
            _context.Foods.Remove(food);
            _context.SaveChanges();
        }
    }
}
