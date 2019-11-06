using System.Collections.Generic;

namespace I4DAB_LAB2.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public string Type { get; set; }
        public ICollection<RestaurantDish> RestaurantDishes { get; set; }
        public Review Review { get; set; }
        public string ReviewId { get; set; }
        public ICollection<GuestDish> GuestDishes { get; set; }
    }
}