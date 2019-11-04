using System;
using System.Collections;
using System.Collections.Generic;

namespace I4DAB_LAB2
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}