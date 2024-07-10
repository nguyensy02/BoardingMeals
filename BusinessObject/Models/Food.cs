using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Food
    {
        public Food()
        {
            MealFoods = new HashSet<MealFood>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual ICollection<MealFood> MealFoods { get; set; }
    }
}
