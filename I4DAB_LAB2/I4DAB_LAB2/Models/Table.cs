using System.Collections.Generic;

namespace I4DAB_LAB2.Models
{
    public class Table
    {
        public int Number { get; set; }
        public Restaurant Restaurant { get; set; }
        public string RestaurantId { get; set; }
        public ICollection<Guest> Guests { get; set; }
        public ICollection<WaiterTable> WaiterTables { get; set; }
    }
}