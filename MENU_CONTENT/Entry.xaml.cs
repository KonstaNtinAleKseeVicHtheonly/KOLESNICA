using DataCommandTest.Check_Validate;
using DataCommandTest.Customs;
using DataCommandTest.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
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
    /// Логика взаимодействия для Entry.xaml
    /// </summary>
    public partial class Entry : Window
    {
        public Entry()
        {
            InitializeComponent();
        }
        private void Login_text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Login_text.Background = 
                Login_text.Text != string.Empty &&
                (Check_Fields.CheckOnlyLetters(Login_text.Text) ||
                Check_Fields.CheckOnlyNumbers(Login_text.Text, "-*_")) ? 
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Button_Enter.IsEnabled = 
                CheckErrorsFields.CheckReds([Grid_Enter], Enter_Label);
        }
        private void Password_text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Password_text.Background =
                Password_text.Text != string.Empty && 
                (Check_Fields.CheckOnlyLetters(Password_text.Text) ||
                Check_Fields.CheckOnlyNumbers(Password_text.Text, "-*_")) ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Button_Enter.IsEnabled = 
                CheckErrorsFields.CheckReds([Grid_Enter], Enter_Label);
        }
        private void Button_Entry_Click(object sender, RoutedEventArgs e)
        {
            Manage_User user = new();
            user.LoadDataMenu(Login_text.Text, Password_text.Text, true);
            if (user.IsGood)
            {
                Menu window = new();
                SwitchWindows.ActionSwitch(Menu_Window, window);
            }  
        }
    }
}
