using DataCommandTest.Check_Validate;
using DataCommandTest.Customs;
using DataCommandTest.Manage;
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

namespace DataCommandTest.NEW_RECORD_USER
{
    /// <summary>
    /// Логика взаимодействия для AddRecordUser.xaml
    /// </summary>
    public partial class AddRecordUser : Window
    {
        public AddRecordUser()
        {
            InitializeComponent();
        }
        private void SwitcherToMenu()
        {
            Menu window = new();
            SwitchWindows.ActionSwitch(Add_User_Window, window);
        }
        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            SwitcherToMenu();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Manage_User muser = new();
            muser.LoadDataMenu(Login_text.Text, Password_text.Text, false);
            MessageBox.Show(
                "ДОБАВЛЕН НОВЫЙ ПОЛЬЗОВАТЕЛЬ!", 
                "GREAT ROMAN XUEC!",
                MessageBoxButton.OK,
                MessageBoxImage.Information
                );
            SwitcherToMenu();
        }

        private void Login_text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Login_text.Background =
                Login_text.Text != string.Empty &&
                (Check_Fields.CheckOnlyLetters(Login_text.Text) ||
                Check_Fields.CheckOnlyNumbers(Login_text.Text, "-*_")) ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Button_Add.IsEnabled =
                CheckErrorsFields.CheckReds([Grid_Add_User]);
        }

        private void Password_text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Password_text.Background =
                Password_text.Text != string.Empty &&
                (Check_Fields.CheckOnlyLetters(Password_text.Text) ||
                Check_Fields.CheckOnlyNumbers(Password_text.Text, "-*_")) ?
                BackField.ChangeColorHex("#00FFFFFF") :
                BackField.ChangeColorHex("#66FFAFAF");
            Button_Add.IsEnabled =
                CheckErrorsFields.CheckReds([Grid_Add_User]);
        }
    }
}
