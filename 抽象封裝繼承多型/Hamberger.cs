using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 抽象封裝繼承多型
{
    class Food
    {
        public string Chatagories { get; set; }
        public string Temperrature { get; set; }
        public eSet Set { get; set; }

        public Food(){
            Chatagories = "Unknown";
            Temperrature = "Raw";
            Set = eSet.WithAll;
        }

    }
    class Hamberger : Food
    {
        public string Bread { get; set; }
        public int Num { get; set; }
        public bool IsChease { get; set; }
        public string Chease
        {
            get
            {
                return (IsChease) ? "有起司" : "沒起司";
            }
        }

        public Hamberger(bool ischease,eSet set,int num)
        {
            Bread = "circle";
            Num = num;
            IsChease = ischease;
            Chatagories = "漢堡";
            Temperrature = "Hot";
            Set = set;
        }
        
    }

    public enum eSet
    {
        /// <summary>
        /// 有可樂
        /// </summary>
        WithCoke = 1,
        /// <summary>
        /// 有炸雞
        /// </summary>
        WtthChicken = 2,
        /// <summary>
        /// 都有
        /// </summary>
        WithAll = 3

    }
}
