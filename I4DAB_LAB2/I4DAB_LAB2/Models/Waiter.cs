using System.Collections.Generic;
namespace I4DAB_LAB2.Models
{
    public class Waiter
    {
        public int Id { get; set; }
        public int Salery { get; set; }
        public ICollection<WaiterTable> WaiterTables { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
    }
}