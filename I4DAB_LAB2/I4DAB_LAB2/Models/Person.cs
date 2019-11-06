using I4DAB_LAB2.Models;

namespace I4DAB_LAB2
{
    public class Person
    {
        public string Name { get; set; }
        public Guest Guest { get; set; }
        public Waiter Waiter { get; set; }
    }
}