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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dbcl.dbP = new SchoolBD();
            FrameClass.fr = FrameMain;
            FrameClass.dobavstr(new UserPage(),0);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e) //кнопка возврата на предыдущую страницу
        {
            if(FrameClass.i>0)
            {
                FrameClass.I--;
            }
        }
    }
}
