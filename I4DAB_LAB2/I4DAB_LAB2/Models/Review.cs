using System;
using System.Collections;
using System.Collections.Generic;

namespace I4DAB_LAB2.Models
{
    public class Review
    {
        public int Stars { get; set; }
        public string Text { get; set; }
        public Restaurant Restaurant { get; set; }
        public string RestaurantId { get; set; }
        public ICollection<Dish> Dishes { get; set; }
        public ICollection<Guest> Guests { get; set; }
    }
}