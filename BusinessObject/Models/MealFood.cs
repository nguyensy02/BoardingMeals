using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class MealFood
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public int MeadId { get; set; }

        public virtual Food Food { get; set; } = null!;
        public virtual Meal Mead { get; set; } = null!;
    }
}
