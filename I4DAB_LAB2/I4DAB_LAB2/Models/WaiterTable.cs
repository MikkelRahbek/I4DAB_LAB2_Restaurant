
namespace I4DAB_LAB2.Models
{
    public class WaiterTable
    {
        public Waiter Waiter { get; set; }
        public int WaiterId { get; set; }
        public Table Table { get; set; }
        public int TableId { get; set; }
    }
}
