using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Meal
    {
        public Meal()
        {
            MealFoods = new HashSet<MealFood>();
            Notes = new HashSet<Note>();
        }

        public int Id { get; set; }
        public int ChefId { get; set; }
        public DateTime Day { get; set; }
        public int Slot { get; set; }

        public virtual User Chef { get; set; } = null!;
        public virtual ICollection<MealFood> MealFoods { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
