using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParking.Entity.Other
{
    public class CurrentCar
    {
        private static CurrentCar instance;

        public Car Car { get; set; }

        private CurrentCar()
        {

        }

        public static CurrentCar GetInstance()
        {
            if (instance == null)
            {
                instance = new CurrentCar();
            }
            return instance;
        }
    }
}
