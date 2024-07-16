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
    public class MealService : IMealService
    {
		private MealDAO _dao;

        public MealService(MealDAO dao)
        {
            _dao = dao;
        }

        public int AddMeal(Meal meal)
        {
            try
            {
                return _dao.AddMeal(meal);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Meal> GetMealsByDate(DateTime fromDate, DateTime toDate)
        {
			try
			{
				return _dao.GetMealByDate(fromDate, toDate);
			}
			catch (Exception)
			{

				throw;
			}
        }

        public void UpdateMeal(Meal meal)
        {
            throw new NotImplementedException();
        }
    }
}
