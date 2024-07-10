using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class User
    {
        public User()
        {
            Meals = new HashSet<Meal>();
            Notes = new HashSet<Note>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public int RoleId { get; set; }
        public string FullName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Meal> Meals { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
