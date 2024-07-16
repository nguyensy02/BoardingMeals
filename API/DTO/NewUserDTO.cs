namespace API.DTO
{
    public class NewUserDTO
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string FullName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Phone { get; set; } = null!;
    }
}
