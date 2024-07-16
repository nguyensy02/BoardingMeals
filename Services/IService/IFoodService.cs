using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IService
{
    public interface IFoodService
    {
        List<Food> GetFoodes();

        void AddFood(Food newFood);

        void UpdateFood(Food newFood);

        Food GetFoodById(int id);
    }
}
