using System;
using System.Collections;
using System.Collections.Generic;

namespace I4DAB_LAB2.Models
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<RestaurantDish> RestaurantDishes { get; set; }
        public ICollection<Table> Tables { get; set; }
    }
}