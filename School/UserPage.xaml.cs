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

namespace School
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private List<Service> _filt = new List<Service>();
        public UserPage()
        {
            InitializeComponent();
            _filt = dbcl.dbP.Service.ToList();
            CBDiscont.SelectedIndex = 0;
        }

        private void AdmBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu admMenu = new AdminMenu();
            MainWindow w=new MainWindow();
            foreach (Window ww in Application.Current.Windows)
            {
                if (ww.GetType() == typeof(MainWindow))
                {
                    w = ww as MainWindow;
                    break;
                }
            }
            admMenu.Owner = w;
            admMenu.Visibility = System.Windows.Visibility.Visible;
            admMenu.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            admMenu.ShowDialog();
            if(LogInAdm.login)
            {
                FrameClass.dobavstr(new AdmMenuPage(),FrameClass.i+1);
                LogInAdm.login = false;
            }
        }

        private void Sort_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void TextBoxTitleFilt_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter(); 
        }

        private void Filter() 
        {
            List<Service> filt = new List<Service>(); //для поиска по названию
            _filt = dbcl.dbP.Service.ToList();
            _filt.Sort((x, y) => x.GetCost.CompareTo(y.GetCost)); //фильтруем по минимальной цене (с учетом скидки)
            if (SortMax.IsChecked == true)
            {
                _filt.Reverse();
            }
            string search = TextBoxTitleFilt.Text.ToLower();
            if (search !="") //поиск по названию
            {
                foreach (Service s in _filt)
                {
                    if (s.Title.ToLower().IndexOf(search) != -1)
                    {
                        filt.Add(s);
                    }
                }
                _filt = filt;
            }
            switch(CBDiscont.SelectedIndex)
            {
                case 1:
                    _filt = _filt.Where(x=>x.Discount>=0&& x.Discount<0.05).ToList();
                    break;
                case 2:
                    _filt = _filt.Where(x => x.Discount >= 0.05 && x.Discount < 0.15).ToList();
                    break;
                case 3:
                    _filt = _filt.Where(x => x.Discount >= 0.15 && x.Discount < 0.30).ToList();
                    break;
                case 4:
                    _filt = _filt.Where(x => x.Discount >= 0.30 && x.Discount < 0.70).ToList();
                    break;
                case 5:
                    _filt = _filt.Where(x => x.Discount >= 0.70 && x.Discount < 1).ToList();
                    break;
                default: break;
            }
            ListViewService.ItemsSource = _filt;
        }

        private void CBDiscont_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
