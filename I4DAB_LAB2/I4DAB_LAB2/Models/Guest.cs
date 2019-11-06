using System.Collections.Generic;

namespace I4DAB_LAB2.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public int Time { get; set; }   // time in seconds 
        public Review Review { get; set; }
        public string ReviewId { get; set; }
        public ICollection<GuestDish> GuestDishes { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public Table Table { get; set; }
        public int TableId { get; set; }
    }
}