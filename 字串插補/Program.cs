using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 字串插補
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"------------------字串insert----------------------------");
            string a = "201111";
            string b = "20111202";
            string c = "";
            if (a.Length > 1)
            {
                c = a.Insert(0, "YO").Insert(0, "hEY");
            }
            Console.WriteLine($"{c}");
            Console.WriteLine($"------------------字串分割----------------------------");
            // '' char "" string
            string d = "火*影忍者*疾風傳";
            string[] dary = d.Split('*');
            string[] dary2 = d.Split(new char[3] { '影', '者', '傳' });
            string[] dary3 = d.Split(new string[] { "火", "*" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var itm in dary)
            {
                Console.Write(itm + "ccc");
            }
            Console.WriteLine();
            foreach (var itm in dary2)
            {
                Console.Write(itm + "ccc");
            }
            Console.WriteLine();
            foreach (var itm in dary3)
            {
                Console.Write(itm + "ccc");
            }
            Console.WriteLine($"\n------------------字串取代----------------------------\n");
            Console.WriteLine($"           c.Replace(被取代,取代)                \n");
            Console.WriteLine($"------------------字串攝取----------------------------\n");
            Console.WriteLine($"  1. c.Substring(index) 2. c.Substring(從index開始抓,抓幾個)  ");
            Console.WriteLine($"------------------PadLeft----------------------------\n");
            // 傳回新字串，此字串會以指定的 Unicode 字元填補左側至指定的總長度，靠右對齊這個執行個體中的字元。
            string str = "forty-two";
            char pad = '.';
            Console.WriteLine(str.PadLeft(15, pad));
            Console.WriteLine(str.PadLeft(2, pad));
            Console.ReadLine();

        }
    }
}
