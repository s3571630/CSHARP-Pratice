using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            //List<string> DataList = new List<string>();

            //GetDataList(@"C:\Users\An Hsieh\Desktop\新增資料夾 (2)\2222.csv", ref DataList);
            //List<string> aaaa = SplitCsvRow(DataList[0]);
            //foreach (var item in aaaa)
            //{
            //    Console.WriteLine(item + "\n");
            //}

            //string bbb = Base64Encode("z3571630");
            //string aaa = System.Net.WebUtility.UrlEncode(bbb);

            List<string> eCate = new List<string> { "B", "G","Z","A","C", "D", "E" };
            int i = eCate.FindIndex(a => a == "D");

            Console.WriteLine($"{i}");
        }
        public static string NumberingNextInt(string cate)
        {
            // 取英文字和前面幾層數字
            string lastLayers = cate.Substring(0, cate.Length - 2);

            // 取後兩位
            string strNum = cate.Substring(cate.Length - 2, 2);
            // 轉數字
            int num = Convert.ToInt32(strNum);
            // 向下編碼
            num += 1;

            string newStrNum = num.ToString("D2");

            string res = lastLayers + newStrNum;

            return res;
        }
        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="AStr"></param>
        /// <returns></returns>
        public static string Base64Encode(string AStr)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(AStr));
        }
        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="ABase64"></param>
        /// <returns></returns>
        public static string Base64Decode(string ABase64)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(ABase64));
        }
        public static string SHA256Encode(string source)
        {
            string str_string = "";
            try
            {
                //建立一個 SHA256
                SHA256 sha = SHA256.Create();
                //將字串轉為Byte[]
                byte[] bsource = Encoding.UTF8.GetBytes(source);
                //進行 SHA256 加密
                byte[] crypto = sha.ComputeHash(bsource);

                foreach (byte theByte in crypto)
                {
                    str_string += (theByte.ToString("x2"));
                }
            }
            catch (Exception ex)
            {

            }
            return str_string;
        }

        public static void aaaa()
        {
            return;
        }
        public static void GetDataList(string input, ref List<string> DataList)
        {
            FileStream fs = new FileStream(input, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);

            //記錄每次讀取的一行記錄
            string strLine = "";

            // 讀取CSV中的數據塞入List
            while ((strLine = sr.ReadLine()) != null)
            {
                DataList.Add(strLine.Trim());
            }
            sr.Close();
            fs.Close();
        }
    
        public static List<string> SplitCsvRow(string str)
        {
            List<string> res = new List<string>();

            MatchCollection mc = Regex.Matches(str, "(?<=^|,)[^\"]*?(?=,|$)|(?<=^|,\")(?:(\"\")?[^\"]*?)*(?=\",?|$)", RegexOptions.ExplicitCapture);
            foreach (Match m in mc)
            {
                // 正則後 內容中一個雙引號會兩個雙引號，此時還原
                res.Add(m.Value.Replace(@"""""", @""""));
            }
            return res;
        }
        public static bool ValidateDataLength(string vData, int length)
        {
            if (Encoding.UTF8.GetBytes(vData).Length == length)
                return true;
            else
                return false;
        }


        public static bool ValidateDate(string dateString, string dateFormat)
        {
            DateTime parseDate;
            try
            {
                // Logger.Error("SysModule.vb.IAC_ValidateDate.dateString=" & dateString & ".1") 'test
                parseDate = DateTime.ParseExact(dateString, dateFormat, System.Globalization.CultureInfo.CurrentCulture);
                // Logger.Error("SysModule.vb.IAC_ValidateDate.dateString=" & dateString & ".2") 'test
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
       
    }
}
