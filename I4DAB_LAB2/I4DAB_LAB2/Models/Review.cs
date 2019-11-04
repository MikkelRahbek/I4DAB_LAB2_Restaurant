using System;
using System.Collections;
using System.Collections.Generic;

namespace I4DAB_LAB2
{
    public class Review
    {
        public int Stars { get; set; }
        public string Text { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}