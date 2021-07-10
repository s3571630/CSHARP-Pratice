using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 遞迴練習
{
    class Program
    {
        // 遞迴 1+3+...+n
        public static int Count(int num)
        {
            if (num < 1)
            {
                return 0;
            }
            else
            {
                return num + Count(num - 2);
            }
        }

        // 河內塔範例
        public void Towers(int n, char A, char B, char C)
        {
            if (n == 1)
                Console.WriteLine("移動盤子" + n + "由" + A + "到" + B);
            else
            {
                //先將較小的盤子移到輔助木棒
                Towers(n - 1, A, C, B);

                //移最大的盤子到目的
                Console.WriteLine("移動盤子" + n + "由" + A + "到" + B);

                //將較小的盤子移到目的
                Towers(n - 1, C, B, A);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"{Count(13)}");
            Console.ReadLine();
        }
    }
}
