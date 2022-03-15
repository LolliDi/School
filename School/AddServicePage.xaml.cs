using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace School
{
    /// <summary>
    /// Логика взаимодействия для AddServicePage.xaml
    /// </summary>
    public partial class AddServicePage : Page
    {
        public AddServicePage()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e) //добавление записей
        {
            try
            {
                string title = TextBlockTitle.Text;
                int cost = Convert.ToInt32(TextBlockCost.Text);
                int duration = Convert.ToInt32(TextBlockDuration.Text);
                string description = TextBlockDescription.Text;
                double discount = Convert.ToDouble(TextBlockDiscount.Text);
                if(discount < 0 && discount >= 1)
                {
                    throw new Exception("Скидка должна быть от 0 до 1\n(например 0,4 = 40%)");
                }
                if (title != "" && description != "")
                {
                    List<Service> service = dbcl.dbP.Service.ToList();
                    if (service.Where(x => x.Title == title).ToList().Count < 1)
                    {
                        dbcl.dbP.Service.Add(new Service() { Title = title, Cost = cost, DurationInSeconds = (duration * 60), Description = description, Discount = discount});
                        dbcl.dbP.SaveChanges();
                        MessageBox.Show("Добавлено", "Успех!");
                    }
                    else
                    {
                        throw new Exception("Такой урок уже существует");
                    }
                }
                else
                {
                    throw new Exception("Введены не все данные");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка");
            }

        }
    }
}
