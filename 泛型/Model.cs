using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 泛型
{
    public interface ISports
    {
        void Pinpang();
    }

    public interface IWork
    {
        void Work();
    }

    public class People
    {
        public int Id { get; set; }
        public string name { get; set; }

        public void Hi()
        {
            Console.WriteLine($"Hi");
        }
    }
    public class Chinese : People, ISports, IWork
    {
        public void Tradition()
        {
            Console.WriteLine($"貪生怕死");
        }

        public void SayHi()
        {
            Console.WriteLine($"安安泥豪");
        }
        public void Work()
        {
            throw new NotImplementedException();
        }

        public void Pinpang()
        {
            Console.WriteLine($"打乒乓");
        }
    }

    public class Hubei : Chinese
    {
        public string drytnooodles { get; set; }
        public void majiang()
        {
            Console.WriteLine($"打麻將");
        }
    }

    public class Japanese : ISports
    {
        public int Id { get; set; }
        public string name { get; set; }
        public void Pinpang()
        {
            Console.WriteLine($"打乒乓");
        }
    }
}
