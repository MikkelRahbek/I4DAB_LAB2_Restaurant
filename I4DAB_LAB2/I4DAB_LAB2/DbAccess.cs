using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using I4DAB_LAB2.Models;

namespace I4DAB_LAB2
{
    public class DbAccess
    {
        private static Restaurant InputRestaurant(string _Name, string _Address, string _Type)
        {
            return new Restaurant()
            {
                Name = _Name,
                Address = _Address,
                Type = _Type
            };
        }

        private static Waiter InputWaiter(int _Salery)
        {
            return new Waiter()
            {
                Salery = _Salery
            };

        }

        private static Table InputTable(int _number)
        {
            return new Table()
            {
                Number = _number
            };
        }

        private static Dish InputDish(int _Price, string _Type)
        {
            return new Dish()
            {
                Price = _Price,
                Type =  _Type
            };
        }

        private static Guest InputGuest(int _Time)
        {
            return new Guest()
            {
                Time = _Time
            };

        }

        private static Review InputReview(int _Stars, string _Text)
        {
            return new Review()
            {
                Stars = _Stars,
                Text = _Text
            };
        } 




    }
}
