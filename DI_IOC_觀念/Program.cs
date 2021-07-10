using System;
using System.IO;
using System.Linq;

namespace DI_IOC_觀念
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 傳統class功能沒分出來
            //TextOutput output = new TextOutput();
            //output.Write("Hello World");
            #endregion

            #region IOC　使用介面把功能拆開
            //IWriter output;

            //// 使用者選擇要用檔案輸出還是Console輸出
            //if (args.Count() > 0 && args[0] == "text")
            //{
            //    output = new TextOutput();
            //}
            //else
            //{
            //    output = new ConsoleOutput();
            //}

            //output.Write("Hello World");
            #endregion

            #region DI方式用法 Constructor injection

            LibraryWrapper txtoutput = new LibraryWrapper(new TextOutput());
            LibraryWrapper consoleoutput = new LibraryWrapper(new ConsoleOutput());
            consoleoutput.output("sssss");


            #endregion
        }

        #region 傳統class功能沒分出來
        //class TextOutput
        //{
        //    public void Write(string text)
        //    {
        //        File.WriteAllText("Filex.txt", text);
        //    }
        //}
        #endregion

        #region IOC　使用介面把功能拆開
        public interface IWriter
        {
            void Write(string text);
        }
        class TextOutput : IWriter
        {
            public void Write(string text)
            {
                File.WriteAllText("Filex.txt", text);
            }
        }
        class ConsoleOutput : IWriter
        {
            public void Write(string text)
            {
                Console.WriteLine(text);
            }
        }
        #endregion

        #region DI方式用法 Constructor injection
        // 使用一個容器，建構子傳入一個介面，建立一個私有屬性去存介面，
        // 再用其他類別實作這個介面的方法並定義要做什麼，
        // 最後在容器中定義方法去使用介面定義的函式，主程式使用容器中定義的方法輸出。
        public class LibraryWrapper
        {
            private IWriter _writer;
            // 透過建構子注入相依的物件
            public LibraryWrapper(IWriter inWriter)
            {
                _writer = inWriter;
            }
            public void output(string text)
            {
                _writer.Write(text);
            }
        }
        #endregion
    }
}
