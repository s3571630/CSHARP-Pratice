using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象封裝繼承多型
{
    abstract class Products
    {
        public abstract void remarks();
    }

    interface ICountprice
    {
        int price { get; set; }
        int num { get; set; }
        int result { get; set; }
        void Count();
    }
    class Shoes : Products,ICountprice
    {
        public int price { get; set; }
        public int num { get; set; }
        public int result { get; set; }
        public override void remarks()
        {
            Console.WriteLine($"我是鞋");
        }

        public void Count() {
            result = price * num;
        }
    }
}
