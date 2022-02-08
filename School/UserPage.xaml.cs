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
        public UserPage()
        {
            InitializeComponent();
            ListViewService.ItemsSource = dbcl.dbP.Service.ToList();
        }

        private void AdmBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu admMenu = new AdminMenu();
            admMenu.Visibility = System.Windows.Visibility.Visible;
            admMenu.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            admMenu.ShowDialog();
            if(LogInAdm.login)
            {
                FrameClass.dobavstr(new AdmMenuPage(),FrameClass.i+1);
                LogInAdm.login = false;
            }
        }
    }
}
