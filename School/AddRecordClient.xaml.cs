using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace School
{
    /// <summary>
    /// Логика взаимодействия для AddRecordClient.xaml
    /// </summary>
    public partial class AddRecordClient : Page
    {
        Service service = new Service();
        List<Clients> client = new List<Clients>();
        public AddRecordClient(int id)
        {
            InitializeComponent();
            service = dbcl.dbP.Service.FirstOrDefault(x => x.ID == id);
            TextBlockNameService.Text = service.Title;
            TextBlockTimeService.Text = service.DurationInSeconds / 60 + "мин.";
            foreach (Client c in dbcl.dbP.Client.ToList())
            {
                client.Add(new Clients(c.ID, c.FirstName, c.LastName, c.Patronymic));
                ComboBoxNameClient.Items.Add(client[client.Count-1].name);
            }
        }

        struct Clients
        {
            public int id;
            public string name;

            public Clients(int i, string nam, string fam, string patr)
            {
                id = i;
                name = nam + " " + fam + " " + patr;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string message = "";
                Regex dateForm = new Regex(@"\d\d?:\d\d? \d\d?\.\d\d?\.\d\d\d\d");
                if (!dateForm.IsMatch(TBDateSeans.Text))
                {
                    message += "Введите дату в формате 12:00 23.01.2022\n";
                }
                if(ComboBoxNameClient.SelectedIndex==-1)
                {
                    message += "Выберите Ваше имя в списке\n";
                }
                if(message.Length>0)
                {
                    throw new Exception(message);
                }
                DateTime time = new DateTime();
                time = DateTime.ParseExact(TBDateSeans.Text, "H:m d.M.yyyy", null);
                if(time<= DateTime.Now)
                {
                    throw new Exception("Нельзя назначить сеанс на прошедшее время");
                }
                List<ClientService> records = dbcl.dbP.ClientService.Where(x => x.ServiceID == service.ID).ToList();
                List<ClientService> thisTime = new List<ClientService>();
                if (records.Count>0)
                {
                    thisTime = records.Where(x => Math.Abs((x.StartTime - time).TotalSeconds) <= service.DurationInSeconds).ToList();
                }
                if(thisTime.Count>0)
                {
                    message += "В данное время уже есть записи! Вот список ближайших записей:\n";
                    foreach(ClientService c in thisTime)
                    {
                        message += c.StartTime+"\n";
                    }
                    throw new Exception(message);
                }
                dbcl.dbP.ClientService.Add(new ClientService() { ClientID = client[ComboBoxNameClient.SelectedIndex].id, ServiceID = service.ID, StartTime = time });
                dbcl.dbP.SaveChanges();
                MessageBox.Show("Вы успешно записались!");
                FrameClass.I--;
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            
        }

        private void DPDateSeansChanged(object sender, TextChangedEventArgs e)
        {
            Regex form = new Regex(@"\d\d:\d\d \d\d?\.\d\d?\.\d\d\d\d");
            string text = TBDateSeans.Text;
            if (text == "" || !form.IsMatch(text)) //сохраняем ранее введенное время, если формат ввода верный
                text = "00:00 ";
            else
                text = TBDateSeans.Text.Substring(0, 6);
            TBDateSeans.Text = text + DPDateSeans.Text;
        }
    }
}
