using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarContents;

namespace 抽象封裝繼承多型
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"------------------------預設建構式寫法--------------------");
            Car car1 = new Car();
            car1.Brand = "Benz";
            car1.Color = "red";
            car1.speednow = 50;
            car1.accelerate(20);
            car1.brake();
            Console.WriteLine($"品牌\t{car1.Brand}\t顏色{car1.Color}\t 目前速度{car1.speednow}");
            Nissan c1 = new Nissan()
            {
                Brand = "Nissan",
                Color = "Black",
                speednow = 100,
                price = 1000000
            };
            c1.accelerate(50);
            c1.accelerate("100");
            c1.accelerate("20");
            c1.brake();

            Console.WriteLine($"品牌\t{c1.Brand}\t顏色{c1.Color}\t 目前速度{c1.speednow}\t價格:{c1.price:#,#}\t油錢:{c1.oilprice(50)}");
            Console.WriteLine($"------------------------使用集合存建構式--------------------");
            // 用集合去存
            List<Car> car = new List<Car>();
            car.Add(new Nissan
            {
                Brand = "Nissan",
                Color = "Green",
                speednow = 50
            });
            car.Add(new Honda
            {
                Brand = "Honda",
                Color = "White",
                speednow = 80
            });
            car.Add(new Toyota
            {
                Brand = "Toyota",
                Color = "Red",
                speednow = 100
            });
            foreach (var c in car)
            {
                c.brake();
                Console.WriteLine($"{c.Brand}\t{c.Color}\t{c.speednow}\n");
            }
            Console.WriteLine($"------------------------集合操作-------------------");
            // 集合用法
            // 操作方法 
            // 新增 
            // Add 添加一個元素 AddRange 一組 Insert(int index, T item); 在index加一個元素
            // 刪除 
            // Remove(T item)  删除一個值 RemoveAt(int index); 刪除index的元素 RemoveRange(int index, int count)
            // 判断某个元素是否在该List中
            // List.Contains(T item)
            string[] test = { "Ha", "Hunter", "Tom", "Lily", "Jay", "Jim", "Kuku", "Locu" };
            List<int> num = new List<int>();
            List<string> name = new List<string>();
            num.Add(10);
            num.Add(20);
            num.Add(30);
            name.AddRange(test);
            foreach (var a in num)
            {
                Console.Write($"{a}\t");
            }
            num.RemoveAt(1);
            foreach (var a in num)
            {
                Console.Write($"{a}\t");
            }
            Console.WriteLine();
            foreach (var b in name)
            {
                Console.Write($"{b}\t");
            }
            Console.WriteLine($"\n------------------------自訂建構式寫法--------------------\n");
            Hamberger hamberger = new Hamberger(true, eSet.WtthChicken, 5);
            Console.WriteLine($"食物資訊 種類:{hamberger.Chatagories}\t生食/熟食:{hamberger.Temperrature}\t套餐:{hamberger.Set}\t起司:{hamberger.Chease}\n");
            Console.WriteLine($"------------------------抽象類別/接口--------------------");
            Products product = new Shoes();
            Shoes shoes = new Shoes() {
                price = 100,
                num = 10
            };
            // 可以用父類別方法
            product.remarks();
            shoes.remarks();
            shoes.Count();
            Console.WriteLine($"商品:{shoes.result}");
            Console.ReadLine();
        }
    }
}
