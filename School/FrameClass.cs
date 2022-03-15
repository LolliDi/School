using System.Collections.Generic;
using System.Windows.Controls;

namespace School
{
    public static class FrameClass
    {
        public static Frame fr = new Frame();
        public static int i = 0; //страница сейчас
        public static int ii = 0; //страниц всего
        public static List<object> stranpereh = new List<object>();

        public static void dobavstr(object ss, int ind)
        {
            if (ind < ii - 1) //если после вставленной страницы есть ещё - их удаляем
            {
                int iii = ind;
                while (iii < ii)
                {
                    stranpereh[iii] = null;
                    stranpereh.RemoveAt(iii);
                    ii--;
                }
            }
            stranpereh.Insert(ind, ss); //вставляем по индексу
            fr.Navigate(stranpereh[ind]); //переходим
            i = ind;
            ii = ind + 1;
        }

        public static int I //изменяем при переходе
        {
            set
            {
                if(value>=0&&value<ii)
                {
                    i = value;
                    fr.Navigate(stranpereh[i]);
                }
            }
            get => i;
        }
    }
}
