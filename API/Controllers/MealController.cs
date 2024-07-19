using API.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IService;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private IMealFoodService _mealFoodService;
        private IMealService _mealService;
        private BoardingMealsContext _context;
        private IUserService _userService;

        public MealController(IMealFoodService mealFoodService, IMealService mealService, BoardingMealsContext context, IUserService userService)
        {
            _mealFoodService = mealFoodService;
            _mealService = mealService;
            _context = context;
            _userService = userService;
        }

        [Authorize(Roles = "admin, chef, teacher, parent")]
        [HttpGet("[action]/{fromDate}/{toDate}")]
        public ActionResult GetMealByDate(DateTime fromDate, DateTime toDate)
        {
            var meals = _mealService.GetMealsByDate(fromDate, toDate);
            var result = meals.Select(m =>
            {
                var mealFoods = m.MealFoods.ToList();
                var foods = mealFoods.Select(mf => new FoodDTO
                {
                    Id = mf.Food.Id,
                    Description = mf.Food.Description,
                    Name  = mf.Food.Name,
                }).ToList();
                return new MealDTO
                {
                    Id = m.Id,
                    ChefId = m.ChefId,
                    ChefName = _userService.GetById(m.ChefId).FullName,
                    Day = m.Day,
                    Slot = m.Slot,
                    Foods =foods
                };
            });
            return Ok(result);
        }

        [Authorize(Roles = "admin, chef")]
        [HttpPost]
        public ActionResult AddMeal([FromBody] MealDTO mealDTO)
        {
            try
            {
                var foods = mealDTO.Foods.ToList();
                var meal = new Meal
                {
                    ChefId = mealDTO.ChefId,
                    Day = mealDTO.Day,
                    Slot = mealDTO.Slot,
                };
                var mealId = _mealService.AddMeal(meal);
                var mealFoods = foods.Select(m => 
                    new MealFood
                    {
                        FoodId = m.Id,
                        MeadId = mealId
                    });
                foreach(var mealFood in mealFoods)
                {
                    _mealFoodService.AddMealFood(mealFood);
                }
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(400, "Error");
            }
        }

        [Authorize(Roles = "admin, chef")]
        [HttpPut]
        public ActionResult EditMeal([FromBody] MealDTO mealDTO)
        {
            try
            {
                var foods = mealDTO.Foods;
                var meadFoodsInDBs = _mealFoodService.GetByMealId(mealDTO.Id);
                foreach (var mfDB in meadFoodsInDBs)
                {
                    _mealFoodService.DeleteMealFood(mfDB);
                }
                foreach (var foodDTO in foods)
                {
                    var mealFood = new MealFood
                    {
                        FoodId = foodDTO.Id,
                        MeadId = mealDTO.Id,
                    };
                    _mealFoodService.AddMealFood(mealFood);
                }
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }

        }
    }
}
