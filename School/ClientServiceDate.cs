using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace School
{
    public partial class ClientService
    {
        public string GetFIO
        {
            get=>Client.LastName + " " + Client.FirstName + " " + Client.Patronymic;
        }

        public string GetTimeRemained
        {
            
            get=> (StartTime - DateTime.Now).Days + "д. " + (StartTime - DateTime.Now).Hours+"ч. "+ (StartTime - DateTime.Now).Minutes+"мин.";
        }

        public SolidColorBrush GetColorRemained
        {
            get
            {
                if ((StartTime - DateTime.Now).TotalHours <= 1)
                {
                    return new SolidColorBrush(Color.FromRgb(255, 0, 0));
                }
                else
                {
                    return new SolidColorBrush(Color.FromRgb(0, 0, 0));
                }
            }
        }
    }
}
