namespace API.DTO
{
    public class MealDTO
    {
        public int Id { get; set; }
        public int ChefId { get; set; }
        public string ChefName { get; set; }
        public DateTime Day { get; set; }
        public int Slot { get; set; }
        public List<FoodDTO> Foods { get; set; }
    }
}
