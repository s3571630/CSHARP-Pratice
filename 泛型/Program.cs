using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 泛型
{
    class Program
    {
        static void Main(string[] args)
        {
            // 不同類型用從一個方法
            // 以前解法
            // object 是任何類型的父類別
            // 缺點 性能損失 型別不安全 強制轉型類別沒繼承的話會沒作用
            int a = 100;
            string b = "哈哈哈";
            DateTime c = DateTime.Now;
            Showonobj(a);
            Showonobj(b);
            Showonobj(c);
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine();
            // <> 可省略 由後面自動算型別
            Show<int>(a);
            Show<string>(b);
            Show<DateTime>(c);
            Console.WriteLine("--------------------泛型約束---------------------");
            {
                People people = new People() { 
                    Id = 123,
                    name = "帥哥"
                };
                Chinese chinese = new Chinese
                {
                    Id = 123,
                    name = "晴天"
                };
                Hubei hubei = new Hubei()
                {
                    Id = 345,
                    name = "HCY"
                };
                Japanese japanese = new Japanese()
                {
                    Id = 111,
                    name = "麻倉憂"
                };
                ShowObj(chinese);
                ShowObj(hubei);
            }
            Console.ReadLine();


        }
        // 舊方法
        public static void Showonobj(object oParameter)
        {
            Console.WriteLine($"{oParameter}\t 出現啦!!");
        }

        // 泛型方法
        public static void Show<T>(T tParameter) {

            Console.WriteLine($"{tParameter}\t 出現啦!!");
        }

        // 泛型約束
        // 可以保證T 是people 或people的子類別
        // 也可以用接口 引用類型約束
        // 為啥不用方法 傳類別值People進來? 因為還可以接其他接口
        public static void ShowObj<T>(T tParameter)
            where T :People,ISports
        {
            Console.WriteLine($"ID:{tParameter.Id}\t{tParameter.name} 出現啦!!");
            tParameter.Pinpang();
        }

        // 效能: 泛型 > 重複寫 >>> object

        // 泛型類別
        public class GeneraticClass<T>
        {
            public T _T;
        }

        public class CommonClass
             //   : GeneraticClass<int> 泛型類別繼承要聲明類型
             : IGeneraticInterface<int>
        {
            public int GetT(int t)
            {
                throw new NotImplementedException();
            }
        }
        public class GeneraticClassChild<HI>
            //: GeneraticClass<HI>
            : IGeneraticInterface<HI>
        {
            public HI GetT(HI t)
            {
                throw new NotImplementedException();
            }
        }

        // 泛型接口 接口要用I 開頭
        public interface IGeneraticInterface<T>
        {
            T GetT(T t); // 泛型類型返回值
        }
        // 泛型委託
        public delegate void Sayhi<T>(T t);
    }
}
