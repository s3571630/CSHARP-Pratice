using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 字典
{
    class Program
    {
        Dictionary<string, string> MyDic = new Dictionary<string, string>();
        public void CreateDictionary()
        {
            MyDic.Add("Name", "Jack");
            MyDic.Add("Blog", "Jack’s Blog");
            MyDic.Add("Group", "KTV Group");
        }
        // 查字典
        public String FindInDictionary(String FindMe)
        {
            if (true == (MyDic.ContainsKey(FindMe)))
            {
                return MyDic[FindMe];
            }
            else
            {
                return "Not Found";
            }
        }
        static void Main(string[] args)
        {
            // 第一種
            Program a = new Program();
            a.CreateDictionary();

            Console.WriteLine($"查字典:{a.FindInDictionary("Blog")}  查不到:{a.FindInDictionary("nooooo")}");
            // 第二種
            Dictionary<string, int> number = new Dictionary<string, int>()
            {
                { "n1",10},{ "n2",29},{ "n3",15},{ "n4",30}
            };
            Console.WriteLine();
            int count = 0;
            foreach (var dcitm in number)
            {
                Console.Write($"{dcitm.Key}\t");
                count = count + dcitm.Value;
            }
            Console.WriteLine($"值相加是:{count}");
            Console.WriteLine($"n1 + n2 = {number["n1"] + number["n2"]}");
        }
    }
}
