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
    public class FoodController : ControllerBase
    {
        private IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [Authorize(Roles = "admin, chef")]
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var classes = _foodService.GetFoodes().ToList();
            var result = classes.Select(f => new FoodDTO
            {
                Id = f.Id,
                Name = f.Name,
                Description = f.Description,
            });
            return Ok(result);
        }

        [Authorize(Roles = "admin, chef")]
        [HttpPost("[action]")]
        public IActionResult AddFood([FromBody] FoodDTO newFoodDTO)
        {
            var newFood = new Food()
            {
                Name = newFoodDTO.Name,
                Description = newFoodDTO.Description,
            };
            _foodService.AddFood(newFood);
            return Ok();
        }
        [Authorize(Roles = "admin, chef")]
        [HttpPut("[action]/{foodId}")]
        public IActionResult UpdateFood(int foodId, [FromBody] FoodDTO newFoodDTO)
        {
            var food = _foodService.GetFoodById(foodId);
            food.Name = newFoodDTO.Name;
            food.Description = newFoodDTO.Description;
            _foodService.UpdateFood(food);
            return Ok();
        }

        [Authorize(Roles = "admin, chef")]
        [HttpGet("[action]/{id}")]
        public IActionResult GetFood(int id)
        {
            var food = _foodService.GetFoodById(id);
            var result = new FoodDTO
            {
                Name = food.Name,
                Description = food.Description,
            };
            return Ok(result);
        }

    }
}
