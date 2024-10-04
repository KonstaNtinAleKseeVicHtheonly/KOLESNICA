using DataCommandTest.Check_Validate;
using DataCommandTest.Customs;
using DataCommandTest.Enums;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // NOTHING
        }

        private void Delete_Button_Копировать_Click(object sender, RoutedEventArgs e)
        {
            // NOTHING
        }

        private void Second_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            Second_Name.Background = Second_Name.Text.Length >= 3 && Check_Fields.CheckOnlyLetters(Second_Name.Text) ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(Grid_1, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }

        private void First_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            First_Name.Background = First_Name.Text.Length >= 3 && Check_Fields.CheckOnlyLetters(First_Name.Text) ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(Grid_1, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }

        private void Third_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            Third_Name.Background = Third_Name.Text.Length >= 3 && Check_Fields.CheckOnlyLetters(Third_Name.Text) ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(Grid_1, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }

        private void PlaceOfBirth_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlaceOfBirth.Background = Check_Fields.CheckOnlyLetters(PlaceOfBirth.Text) || 
                Check_Fields.CheckOnlyNumbers(PlaceOfBirth.Text, ".,-") ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Push.Visibility = CheckErrorsFields.CheckReds(Grid_1, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }

        private void SexChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // NOTHING
        }

        private void Date_Year_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Date_Year.Text.Length == 4 && Check_Fields.CheckOnlyNumbers(Date_Year.Text))
                Date_Month.IsEnabled = true;
            else if (Date_Year.Text.Length == 0)
                BackField.DateChangeBack(new Queue<TextBox>([Date_Year, Date_Month, Date_Day]), BackField.ChangeColorHex("#00FFFFFF"));
            else
            {
                Date_Day.Background = BackField.ChangeColorHex("#66FFAFAF");
                Date_Month.Background = BackField.ChangeColorHex("#66FFAFAF");
                Date_Year.Background = BackField.ChangeColorHex("#66FFAFAF");
                Date_Month.IsEnabled = false;
                Date_Day.IsEnabled = false;
                Date_Month.Text = string.Empty;
                Date_Day.Text = string.Empty;
            }
            Push.Visibility = CheckErrorsFields.CheckReds(Grid_1, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }
        private void Date_Month_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Date_Month.Text.Length >= 1 && Check_Fields.CheckOnlyNumbers(Date_Month.Text))
                Date_Day.IsEnabled = true;
            else
            {
                Date_Day.IsEnabled = false;
                Date_Day.Text = string.Empty;
            }
            Push.Visibility = CheckErrorsFields.CheckReds(Grid_1, PlaceHoldPush) ? Visibility : Visibility.Hidden;
        }
        private void Date_Day_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (DateTime.ParseExact($"{Date_Year.Text}-{Date_Month.Text}-{Date_Day.Text}", "yyyy-M-d", null) < DateTime.Now)
                    BackField.DateChangeBack(new Queue<TextBox>([Date_Year, Date_Month, Date_Day]), BackField.ChangeColorHex("#00FFFFFF"));
            }
            catch (FormatException)
            {
                Date_Day.Background = BackField.ChangeColorHex("#66FFAFAF");
                Date_Month.Background = BackField.ChangeColorHex("#66FFAFAF");
                Date_Year.Background = BackField.ChangeColorHex("#66FFAFAF");
            }
            finally
            {
                Push.Visibility = CheckErrorsFields.CheckReds(Grid_1, PlaceHoldPush) ? Visibility : Visibility.Hidden;
            }
        }
        private async void Push_Click(object sender, RoutedEventArgs e)
        {
            UserGeneral user = new();
            Queue<TextBox> fields = [];

            foreach (var item in Grid_1.Children)
            {
                if (item is TextBox box)
                    fields.Enqueue(box);
            }
            user.SetData(fields, SexChoice.Text == "Не выбрано" ? Sex.NULL : (Sex)Enum.Parse(typeof(Sex), SexChoice.Text, true));
            if (File.Exists("user.json"))
                File.Delete("user.json");
            using (FileStream fs = new("user.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<UserGeneral>(fs, user);
            }
            MessageBox.Show(
                "Успешно",
                "Данные успешно отправлены!",
                MessageBoxButton.OK,
                MessageBoxImage.Information
                );
        }
    }
}