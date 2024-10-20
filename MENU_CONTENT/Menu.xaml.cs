using DataCommandTest.Manage;
using DataCommandTest.NEW_RECORD_USER;
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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Button_Setting_Click(object sender, RoutedEventArgs e)
        {
            // Вызов БАЗОВЫХ и ПРОДВИНУТЫХ настроек
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Entry window = new();
            SwitchWindows.ActionSwitch(Select_Menu, window);
        }

        private void Button_Adder_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new();
            SwitchWindows.ActionSwitch(Select_Menu, window);
        }

        private void Button_Searching_Click(object sender, RoutedEventArgs e)
        {
            // Поиск данных из БД
        }

        private void Button_GenDoc_Click(object sender, RoutedEventArgs e)
        {
            // Генерация документов Ворд
        }

        private void Button_GenTable_Click(object sender, RoutedEventArgs e)
        {
            // Генерация таблиц Эксель
        }

        private void Button_ADMIN_AddRecord_Click(object sender, RoutedEventArgs e)
        {
            AddRecordUser window = new();
            SwitchWindows.ActionSwitch(Select_Menu, window);
        }
    }
}
