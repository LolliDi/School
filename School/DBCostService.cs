using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace School
{
    public partial class Service
    {
        public SolidColorBrush DiscountColor
        {
            get
            {
                if (Discount>0) return new SolidColorBrush(Color.FromArgb(50, 4, 160, 191));
                else return new SolidColorBrush(Color.FromArgb(50, 231, 250, 191));
            }
        }
        public string DiscountService
        {
            get
            {
                string cost="";
                if (Discount > 0)
                {
                    cost = ((int)Cost).ToString()+" ";
                }
                return cost;
                
            }
        }
        public string CostService
        {
            get
            {
                string cost = "";
                if (Discount > 0)
                {
                    cost = "" + ((double)Cost * (1-Discount)) + " рублей за " + (DurationInSeconds / 60) + " минут\n*скидка " + (Discount*100) + "%";
                }
                else
                {
                    cost = "" + (int)Cost + " рублей за " + (DurationInSeconds / 60) + " минут";
                }
                return cost;
            }
        }
    }
}
