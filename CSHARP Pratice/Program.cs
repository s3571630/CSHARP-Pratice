using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARP_Pratice
{
    class Program
    {
        struct Hunted
        {
            public string name;
            public int money;
        }

        static void Main(string[] args)
        {
            Hunted[] a = new Hunted[4];
            a[0].name = "魯夫"; a[0].money = 123;
            a[1].name = "香吉士"; a[1].money = 1213;
            a[2].name = "娜美"; a[2].money = 12113;
            a[3].name = "騙人布"; a[3].money = 1213;
            Console.WriteLine("姓名\t選賞金額");
            Console.WriteLine("..............");
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine($"{a[i].name}\t{a[i].money.ToString("#,#")}");
            }
            Console.ReadLine();
        }
    }
}
