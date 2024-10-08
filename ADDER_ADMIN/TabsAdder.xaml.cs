using DataCommandTest.Check_Validate;
using DataCommandTest.Customs;
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
using System.Windows.Shapes;

namespace DataCommandTest
{
    /// <summary>
    /// Логика взаимодействия для TabsLeader.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void Button_Generals_Click(object sender, RoutedEventArgs e)
        {
            cond_gr!.Change_grid(Button_Generals, Grid_1);
        }
        private void Button_Contacts_Click(object sender, RoutedEventArgs e)
        {
            cond_gr!.Change_grid(Button_Contacts, Grid_2);
        }
        private void Button_Work_Click(object sender, RoutedEventArgs e)
        {
            cond_gr!.Change_grid(Button_Work, Grid_3);
        }
        private void Button_Auto_Click(object sender, RoutedEventArgs e)
        {
            cond_gr!.Change_grid(Button_Auto, Grid_4);
        }
        private void Button_Credits_Click(object sender, RoutedEventArgs e)
        {
            cond_gr!.Change_grid(Button_Credits, Grid_5);
        }
    }
}
