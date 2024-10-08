using DataCommandTest.Manage;
using DataCommandTest.User_Data;
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
    /// Логика взаимодействия для ButtonsAdder.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private async void Push_Click(object sender, RoutedEventArgs e)
        { // ALL GRIDS!!!
            List<User> userData =
                [
                    new UserGeneral(),
                    new UserContacts(),
                    new UserWork(),
                    new UserAuto(),
                    new UserCredits(),
                ];
            List<string> files =
                [
                    "user.json",
                    "user_2.json",
                    "user_3.json",
                    "user_4.json",
                    "user_5.json",
                ];
            for (int next = 0; next < grids!.Count; next++)
            {
                Queue<TextBox> fieldsTB;
                Queue<Label> fieldsLB;
                switch (next)
                {
                    case 0:
                    case 2:
                        fieldsTB = [];
                        foreach (var item in grids[next].Children)
                        {
                            if (item is TextBox box)
                                fieldsTB.Enqueue(box);
                        }
                        Push_Data.Push_Data_New(fieldsTB, userData[next], files[next]);
                        break;
                    case 1:
                        fieldsLB = [];
                        foreach (var item in grids[next].Children.OfType<Grid>().First().Children)
                        {
                            if (item is Label box)
                                fieldsLB.Enqueue(box);
                        }
                        Push_Data.Push_Data_New(fieldsLB, userData[next], files[next]);
                        break;
                    case 3:
                        fieldsLB = [];

                        foreach (var item in grids[next].Children.OfType<Grid>().First().Children)
                        {
                            if (item is Label box)
                                fieldsLB.Enqueue(box);
                        }
                        Push_Data.Push_Data_New(fieldsLB, userData[next], files[next]);
                        break;
                    case 4:
                        fieldsLB = [];

                        foreach (var item in grids[next].Children.OfType<Grid>().First().Children)
                        {
                            if (item is Label box)
                                fieldsLB.Enqueue(box);
                        }
                        Push_Data.Push_Data_New(fieldsLB, userData[next], files[next]);
                        break;
                    default:
                        break;
                }
            }

            MessageBox.Show(
                "Успешно",
                "Данные успешно отправлены!",
                MessageBoxButton.OK,
                MessageBoxImage.Information
                );
        }
        private void Add_WindowData_Click(object sender, RoutedEventArgs e)
        {
            var itemButton = sender as Button;
            Grid? grid = itemButton!.Parent as Grid;
            Grid_Block.Visibility = Visibility.Visible;
            switch (grid!.Name)
            {
                case "Grid_2":
                    Grid_Window_Contacts.Visibility = Visibility.Visible;
                    break;
                case "Grid_4":
                    Grid_Window_Auto.Visibility = Visibility.Visible;
                    break;
                case "Grid_5":
                    Grid_Window_Credits.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }
        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            var itemButton = sender as Button;
            Grid? grid = itemButton!.Parent as Grid;
            switch (grid!.Name)
            {
                case "Grid_Window_Contacts":
                    DataWindow.Add_Data_From_Window(grid, Grid_2.Children.OfType<Grid>().First().Children.OfType<Label>().ToList()[..2]);
                    grid!.Visibility = Visibility.Hidden;
                    Grid_Block.Visibility = Visibility.Hidden;
                    Record_contact.Visibility = Visibility.Visible;
                    Add_Contacts.Visibility = Visibility.Hidden;
                    break;
                case "Grid_Window_Auto":
                    DataWindow.Add_Data_From_Window(grid, Grid_4.Children.OfType<Grid>().First().Children.OfType<Label>().ToList()[..4]);
                    grid!.Visibility = Visibility.Hidden;
                    Grid_Block.Visibility = Visibility.Hidden;
                    Record_Auto.Visibility = Visibility.Visible;
                    Button_Data_Auto_Add.Visibility = Visibility.Hidden;
                    break;
                case "Grid_Window_Credits":
                    DataWindow.Add_Data_From_Window(grid, Grid_5.Children.OfType<Grid>().First().Children.OfType<Label>().ToList()[..5]);
                    grid!.Visibility = Visibility.Hidden;
                    Grid_Block.Visibility = Visibility.Hidden;
                    Record_Credits.Visibility = Visibility.Visible;
                    Button_Data_Credits_Add.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
            grid!.Visibility = Visibility.Hidden;
            Grid_Block.Visibility = Visibility.Hidden;
            Record_contact.Visibility = Visibility.Visible;
            Add_Contacts.Margin = new Thickness(175); // ISSUE! DYNAMIC ADD
            Add_Contacts.IsEnabled = false;
        }
        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            var itemButton = sender as Button;
            Grid? grid = itemButton!.Parent! as Grid;
            grid!.Visibility = Visibility.Hidden;
            Grid_Block.Visibility = Visibility.Hidden;
        }
    }
}
