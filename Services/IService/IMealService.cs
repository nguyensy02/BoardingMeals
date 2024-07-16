using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IService
{
    public interface IMealService
    {
        List<Meal> GetMealsByDate(DateTime fromDate, DateTime toDate);

        int AddMeal(Meal meal);

        void UpdateMeal(Meal meal);


    }
}
