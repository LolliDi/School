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
        public SolidColorBrush DiscountColor //цвет фона, зависит от наличия скидки
        {
            get
            {
                if (Discount>0) return new SolidColorBrush(Color.FromArgb(50, 4, 160, 191));
                else return new SolidColorBrush(Color.FromArgb(50, 231, 250, 191));
            }
        }
        public string DiscountService //для перечеркнутой цены
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
        public string CostService //строка с ценой
        {
            get
            {
                string cost = "";
                if (Discount > 0) //если есть скидка
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
        public double GetCost //возврат цены с учетом скидки
        {
            get
            {
                double cost = (double)Cost;
                if (Discount > 0)
                {
                    cost = (double)(Convert.ToInt32(Cost) * (1 - Discount));
                }

                return cost;
            }
        }
    }
}
