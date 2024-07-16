namespace API.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string? ClassName { get; set; }
        public int ParentId { get; set; }
        public string? ParentName { get; set; }  
        public string FullName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public int MealLevel { get; set; }
    }
}
