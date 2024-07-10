using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int ParentId { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public int MealLevel { get; set; }

        public virtual Class Class { get; set; } = null!;
        public virtual User Parent { get; set; } = null!;
    }
}
