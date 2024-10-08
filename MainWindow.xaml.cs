using DataCommandTest.Check_Validate;
using DataCommandTest.Customs;
using DataCommandTest.Enums;
using DataCommandTest.Manage;
using DataCommandTest.User_Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace DataCommandTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Conditions_Grid? cond_gr;
        readonly List<Grid>? grids = [];
        public MainWindow()
        {
            InitializeComponent();
            cond_gr = new(Button_Generals, Grid_1);
            foreach (var item in CreatePerson.Children)
            {
                if (item is Grid)
                {
                    var item_ = item as Grid;
                    grids!.Add(item_!);
                }
            }
        }
        private void Second_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            Second_Name.Background = Second_Name.Text.Length >= 3 && Check_Fields.CheckOnlyLetters(Second_Name.Text) ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }
        private void First_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            First_Name.Background = First_Name.Text.Length >= 3 && Check_Fields.CheckOnlyLetters(First_Name.Text) ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }
        private void Third_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            Third_Name.Background = Third_Name.Text.Length >= 3 && Check_Fields.CheckOnlyLetters(Third_Name.Text) ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }
        private void PlaceOfBirth_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlaceOfBirth.Background = Check_Fields.CheckOnlyLetters(PlaceOfBirth.Text) || 
                Check_Fields.CheckOnlyNumbers(PlaceOfBirth.Text, ".,-") ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }
        private void SexChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // NOTHING
        }
        private void Date_Year_TextChanged(object sender, TextChangedEventArgs e)
        {
            Check_Date.Check_Date_Valid_Year(Date_Year, Date_Month, Date_Day);
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }
        private void Date_Month_TextChanged(object sender, TextChangedEventArgs e)
        {
            Check_Date.Check_Date_Valid_Month(Date_Month, Date_Day);
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }
        private void Date_Day_TextChanged(object sender, TextChangedEventArgs e)
        {
            Check_Date.Check_Date_Valid_Day(Date_Year, Date_Month, Date_Day);
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }
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
        
        private void Button_Generals_Click(object sender, RoutedEventArgs e)
        {
            cond_gr!.Change_grid(Button_Generals, Grid_1);
        }
        private void Button_Contacts_Click(object sender, RoutedEventArgs e)
        {
            cond_gr!.Change_grid(Button_Contacts, Grid_2);
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
        
        private void Text_Phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Шаблон номера
        }
        private void Text_Address_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            Text_Address.Background = Check_Fields.CheckOnlyLetters(Text_Address.Text) ||
                Check_Fields.CheckOnlyNumbers(Text_Address.Text, ".,- ") ? // ISSUE SPACE IS ERROR!!!
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
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
        private void Button_Work_Click(object sender, RoutedEventArgs e)
        {
            cond_gr!.Change_grid(Button_Work, Grid_3);
        }
        private void Doljnost_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Doljnost_Text.Background = Check_Fields.CheckOnlyLetters(Doljnost_Text.Text) ||
                Check_Fields.CheckOnlyNumbers(Doljnost_Text.Text, ".,- ") ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden; // Для Джейсона надо гриды собирать
        }
        private void Otdel_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Otdel_Text.Background = Check_Fields.CheckOnlyLetters(Otdel_Text.Text) ||
                Check_Fields.CheckOnlyNumbers(Otdel_Text.Text, ".,- ") ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }
        private void Positive_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Positive_Text.Background = Check_Fields.CheckOnlyNumbers(Positive_Text.Text) ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }
        private void Negative_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Negative_Text.Background = Check_Fields.CheckOnlyNumbers(Negative_Text.Text) ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }
        private void Rating_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Шаблон дробного числа
        }
        private void Button_Auto_Click(object sender, RoutedEventArgs e)
        {
            cond_gr!.Change_grid(Button_Auto, Grid_4);
        }
        private void Text_Model_TextChanged(object sender, TextChangedEventArgs e)
        {
            Text_Model.Background = Check_Fields.CheckOnlyLetters(Text_Model.Text) ||
                Check_Fields.CheckOnlyNumbers(Text_Model.Text, "- ") ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }

        private void Text_Marka_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            Text_Marka.Background = Check_Fields.CheckOnlyLetters(Text_Marka.Text) ||
                Check_Fields.CheckOnlyNumbers(Text_Marka.Text, "- ") ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }

        private void Text_Gos_TextChanged(object sender, TextChangedEventArgs e)
        {
            // TEMPLATE
        }

        private void Text_ColorAuto_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            Text_ColorAuto.Background = Check_Fields.CheckOnlyLetters(Text_ColorAuto.Text) ||
                Check_Fields.CheckOnlyNumbers(Text_ColorAuto.Text, "-") ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }
        private void Button_Credits_Click(object sender, RoutedEventArgs e)
        {
            cond_gr!.Change_grid(Button_Credits, Grid_5);
        }
        private void Text_Org_TextChanged(object sender, TextChangedEventArgs e)
        {
            Text_Org.Background = Check_Fields.CheckOnlyLetters(Text_Org.Text) ||
                Check_Fields.CheckOnlyNumbers(Text_Org.Text, "- ") ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }

        private void Text_Type_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            Text_Type.Background = Check_Fields.CheckOnlyLetters(Text_Type.Text) ||
                Check_Fields.CheckOnlyNumbers(Text_Type.Text, "- ") ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }

        private void Text_Summa_TextChanged(object sender, TextChangedEventArgs e)
        {
            // TEMPLATE
        }

        private void Text_Payment_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            // TEMPLATE
        }

        private void Text_Date_Year_TextChanged(object sender, TextChangedEventArgs e)
        {
            Check_Date.Check_Date_Valid_Year(Text_Date_Year, Text_Date_month, Text_Date_Day);
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }

        private void Text_Date_month_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            Check_Date.Check_Date_Valid_Month(Text_Date_month, Text_Date_Day);
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }

        private void Text_Date_Day_TextChanged(object sender, TextChangedEventArgs e)
        {
            Check_Date.Check_Date_Valid_Day(Text_Date_Year, Text_Date_month, Text_Date_Day);
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }
    }
}