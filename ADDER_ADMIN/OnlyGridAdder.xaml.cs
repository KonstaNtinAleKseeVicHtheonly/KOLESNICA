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
    /// Логика взаимодействия для OnlyGridAdder.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
    }
}
