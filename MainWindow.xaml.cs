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
                if (next == 1 || next == 3 || next == 4)
                {
                    Queue<Label> fields = [];

                    foreach (var item in grids[next].Children)
                    {
                        if (item is Label box)
                            fields.Enqueue(box);
                    }
                    Push_Data.Push_Data_New(fields, userData[next], files[next]);
                }
                else
                {
                    Queue<TextBox> fields = [];

                    foreach (var item in grids[next].Children)
                    {
                        if (item is TextBox box)
                            fields.Enqueue(box);
                    }
                    Push_Data.Push_Data_New(fields, userData[next], files[next]);
                }
            }
            
            MessageBox.Show(
                "Успешно",
                "Данные успешно отправлены!",
                MessageBoxButton.OK,
                MessageBoxImage.Information
                );
        }
        private void Add_Contacts_Click(object sender, RoutedEventArgs e)
        {
            Grid_Block.Visibility = Visibility.Visible;
        }
        private void Button_Generals_Click(object sender, RoutedEventArgs e)
        {
            cond_gr!.Change_grid(Button_Generals, Grid_1);
        }
        private void Button_Contacts_Click(object sender, RoutedEventArgs e)
        {
            cond_gr!.Change_grid(Button_Contacts, Grid_2);
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
        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Grid_Block.Visibility = Visibility.Hidden;
        }
        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Queue<Label> queue = [];
            queue.Enqueue(Record_Number_Text);
            queue.Enqueue(Record_Address_Text);

            foreach (var item in Grid_Contacts.Children)
            {
                if (item is TextBox)
                {
                    var item_ = item as TextBox;
                    if (item_!.Background.ToString() == BackField.ChangeColorHex("#66FFAFAF").ToString())
                        return;
                    else
                        queue.Dequeue().Content = item_.Text;
                }
                    
            }
            Grid_Block.Visibility = Visibility.Hidden;
            Record_contact.Visibility = Visibility.Visible;
            Record_address.Visibility = Visibility.Visible;
            Add_Contacts.Margin = new Thickness(175); // ISSUE! DYNAMIC ADD
            Add_Contacts.IsEnabled = false;
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
        private void Model_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Model_Text.Background = Check_Fields.CheckOnlyLetters(Model_Text.Text) ||
                Check_Fields.CheckOnlyNumbers(Model_Text.Text, "- ") ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }

        private void Marka_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Marka_Text.Background = Check_Fields.CheckOnlyLetters(Marka_Text.Text) ||
                Check_Fields.CheckOnlyNumbers(Marka_Text.Text, "- ") ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }

        private void Gos_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            // TEMPLATE
        }

        private void ColorAuto_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            ColorAuto_Text.Background = Check_Fields.CheckOnlyLetters(ColorAuto_Text.Text) ||
                Check_Fields.CheckOnlyNumbers(ColorAuto_Text.Text, "-") ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }

        private void Button_Data_Auto_Add_Click(object sender, RoutedEventArgs e)
        {
            // NOT REALIZATION
        }

        private void Button_Credits_Click(object sender, RoutedEventArgs e)
        {
            cond_gr!.Change_grid(Button_Credits, Grid_5);
        }

        private void Org_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Org_Text.Background = Check_Fields.CheckOnlyLetters(Org_Text.Text) ||
                Check_Fields.CheckOnlyNumbers(Org_Text.Text, "- ") ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }

        private void Type_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Type_Text.Background = Check_Fields.CheckOnlyLetters(Type_Text.Text) ||
                Check_Fields.CheckOnlyNumbers(Type_Text.Text, "- ") ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }

        private void Summa_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            // TEMPLATE
        }

        private void Payment_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            // TEMPLATE
        }

        private void Date_last_Pay_Year_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Check_Date.Check_Date_Valid_Year(Date_last_Pay_Year_Text, Date_last_Pay_Month_Text, Date_last_Pay_Day_Text);
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }

        private void Date_last_Pay_Month_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Check_Date.Check_Date_Valid_Month(Date_last_Pay_Month_Text, Date_last_Pay_Day_Text);
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }

        private void Date_last_Pay_Day_Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Check_Date.Check_Date_Valid_Day(Date_last_Pay_Year_Text, Date_last_Pay_Month_Text, Date_last_Pay_Day_Text);
            Push.Visibility = CheckErrorsFields.CheckReds(grids!, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }

        private void Button_Data_Credits_Add_Click(object sender, RoutedEventArgs e)
        {
            // NOT REALIZATION
        }
    }
}