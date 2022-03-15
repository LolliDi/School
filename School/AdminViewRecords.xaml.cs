using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace School
{
    /// <summary>
    /// Логика взаимодействия для AdminViewRecords.xaml
    /// </summary>
    public partial class AdminViewRecords : Page
    {

        List<ClientService> dB = new List<ClientService>();
        public AdminViewRecords()
        {
            InitializeComponent();
            update();
            DispatcherTimer t = new DispatcherTimer();
            t.Tick += new EventHandler(upd);
            t.Interval = new TimeSpan(0, 0, 30);
            t.Start();
        }
        public void upd(object sender, EventArgs e)
        {
            update();
        }
        public void update()
        {
            
            DateTime thisTime = DateTime.Now;
            dB.Clear();
            foreach (ClientService c in dbcl.dbP.ClientService.ToList())
            {
                double days = (c.StartTime - thisTime).TotalDays;
                if (days < 2 && (c.StartTime - thisTime).TotalSeconds > 0)
                {
                    dB.Add(c);
                    
                }
            }
            ListViewRecords.Items.Clear();
            dB.Sort((x,y) => x.StartTime.CompareTo(y.StartTime));
            foreach(ClientService c in dB)
            {
                ListViewRecords.Items.Add(c);
            }    
        }
    }
}
