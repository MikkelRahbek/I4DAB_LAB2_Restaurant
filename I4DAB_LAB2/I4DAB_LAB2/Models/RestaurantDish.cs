using System.Collections.Generic;

namespace I4DAB_LAB2.Models
{
    public class RestaurantDish
    {
        public string RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
