
namespace I4DAB_LAB2.Models
{
    public class GuestDish
    {
        public Dish Dish { get; set; }
        public int DishId { get; set; }
        public Guest Guest { get; set; }
        public int GuestId { get; set; }
    }
}
