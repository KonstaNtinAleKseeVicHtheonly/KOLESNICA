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

        private void Exit_Add_Click(object sender, RoutedEventArgs e)
        {
            Menu window = new()
            {
                Owner = this
            };
            SwitchWindows.ActionSwitch(Window_Adder, window);
        }
    }
}