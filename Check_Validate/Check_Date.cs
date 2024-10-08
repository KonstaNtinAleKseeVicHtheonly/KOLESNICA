using DataCommandTest.Customs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataCommandTest.Check_Validate
{
    public static class Check_Date
    {
        public static void Check_Date_Valid_Year(TextBox Date_Year, TextBox Date_Month, TextBox Date_Day)
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
        }
        public static void Check_Date_Valid_Month(TextBox Date_Month, TextBox Date_Day)
        {
            if (Date_Month.Text.Length >= 1 && Check_Fields.CheckOnlyNumbers(Date_Month.Text))
                Date_Day.IsEnabled = true;
            else
            {
                Date_Day.IsEnabled = false;
                Date_Day.Text = string.Empty;
            }
        }
        public static void Check_Date_Valid_Day(TextBox Date_Year, TextBox Date_Month, TextBox Date_Day)
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
        }
    }
}
