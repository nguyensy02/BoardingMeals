using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Note
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MealId { get; set; }
        public DateTime Time { get; set; }
        public string Content { get; set; } = null!;

        public virtual Meal Meal { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
