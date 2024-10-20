using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataCommandTest.Manage
{
    public static class SwitchWindows
    {
        public static void ActionSwitch(Window alt_win, Window new_win)
        {
            new_win.Show();
            Application.Current.MainWindow = new_win;
            alt_win.Close();
        }
    }
}
