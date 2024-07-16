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
    public class FoodService : IFoodService
    {
        private readonly FoodDAO _dao;
        public FoodService(FoodDAO dao)
        {
            _dao = dao;
        }

        public void AddFood(Food newFood)
        {
            try
            {
                _dao.AddFood(newFood);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Food GetFoodById(int id)
        {
            try
            {
                return _dao.GetFoodById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Food> GetFoodes()
        {
            try
            {
                return _dao.GetFoodList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateFood(Food newFood)
        {
            try
            {
                _dao.UpdateFood(newFood);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
