using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace 同步非同步
{


    /// <summary>
    /// 1. 程序 - 執行緒 - 多執行緒 同步和異步
    /// 2. 委託啟動異步調用
    /// 
    /// 觀念:
    /// 
    /// 以電腦角度來說
    /// 程序(進程): 一個程序運行時占所有資源的總和
    /// 執行緒(線程): 程序執行流的最小單位，任何操作都是由執行緒去完成，
    ///               執行緒是依託應用程序存在，一個應用程序可包含多執行緒
    ///               執行緒也可以有自己的計算資源
    /// 控制代碼(句柄): 有多少個東西是系統在管理的
    /// 多執行緒: 多個執行流同時運行
    ///           1. CPU太快了一下算完，分時間片(1s 算1w次 => 1s 算1000次 10個) 
    ///               -- 每個時間片: 上下文切換 (加載環境 - 計算 - 保存環境)
    ///              微觀: 一個核同一時刻只能執行一個執行緒，宏觀來說是多執行緒併發(切片)
    ///           2. CPU多核 可以獨立工作
    ///              4核8線程 核是物理的核 線程是虛擬核 
    ///              4cpu 每個cpu有2個尾核(虛擬核) 每個核可以單執行緒 也可以切片多執行緒
    ///              
    ///  Thread是c#對執行緒對象的封裝 開發說的執行緒是指對Thread,Task ...等操作
    ///  
    /// 對方法執行的描述
    /// 同步: 完成計算再進入下一行
    /// 異步(非同步): 不等待方法完成，直接進入下一行
    /// 
    /// C# 異步和多執行緒有什麼差別
    /// 多執行緒是利用多個thread併發:
    /// 異步是硬體式的異步
    /// 異步多執行緒 -- thread pool task
    /// 
    /// Thread.Sleep(0) 讓目前執行緒休眠 以利其他執行緒執行 設定0也會等
    /// Task.Delay(1000) 控制新執行緒的時間
    /// 
    /// 
    /// </summary>
    #region 沒有await的main方法
    class Program
    {

        static void Main(string[] args)
        {
            // 同步呼叫
            string content = MyDownloadPage("http://huan-lin.blogspot.com");

            Console.WriteLine("網頁內容總共為 {0} 個字元。", content.Length);


            // 非同步呼叫 (舊)
            Task<string> task = MyDownloadPageAsync("https://www.huanlintalk.com/");
            string content2 = task.Result; // 取得非同步工作的結果。

            Console.WriteLine("網頁內容總共為 {0} 個字元。", content2.Length);

            // 同步效能
            TimerAndEfficacy NoAsync = new TimerAndEfficacy();
            NoAsync.ShowNoAsync();

            // 非同步效能
            TimerAndEfficacy WithAsync = new TimerAndEfficacy();
            NoAsync.ShowWithAsync();

            Console.ReadKey();
        }

        static string MyDownloadPage(string url)
        {
            var webClient = new WebClient();  // 須引用 System.Net 命名空間。
            string content = webClient.DownloadString(url);
            return content;
        }

        static async Task<string> MyDownloadPageAsync(string url)
        {
            using (var webClient = new WebClient())
            {
                // 一行寫法
                 string content = await webClient.DownloadStringTaskAsync(url);
                // 兩行
                //Task<string> task = webClient.DownloadStringTaskAsync(url);
                //string content = await task;
                return content;
            }
        }
    }
    #endregion

    #region 在main 方法中加入await
    //static class Program
    //{
    //    static async Task Main()
    //    {
    //        var url = "https://www.huanlintalk.com";
    //        var content = await MyDownloadPageAsync(url);
    //        Console.WriteLine("網頁內容總共為 {0} 個字元。", content.Length);
    //        Console.ReadLine();
    //    }

    //    static async Task<string> MyDownloadPageAsync(string url)
    //    {
    //        using (var wc = new WebClient())
    //        {
    //            return await wc.DownloadStringTaskAsync(url);
    //        }
    //    }
    //}
    #endregion
}
