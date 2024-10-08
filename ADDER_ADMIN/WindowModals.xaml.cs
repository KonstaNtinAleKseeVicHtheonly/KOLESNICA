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
    /// Логика взаимодействия для WindowModals.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
