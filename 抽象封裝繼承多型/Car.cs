using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarContents
{
    class Car
    {
        public string Brand { get; set; }

        public int speednow { get; set; }


        private string color = "";
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public int accelerate(int speed)
        {
            speednow += speed;
            return speednow;
        }

        // 多載
        public int accelerate(string speed)
        {
           int speeedtrans =int.Parse(speed);
           return speednow += speeedtrans;
        }
        public string oilprice(int distance) {
            distance *= 100;
            return $"{distance:#,#}";
        } 
        public virtual void brake()
        {
            speednow -= 10;
        }
    }

    class Nissan : Car
    {
        public int price { get; set; }
        public override void brake()
        {
            speednow -= 50;
        }
    }

    class Toyota : Car
    {

    }
    class Honda : Car
    {

    }
}
