using DataCommandTest.Customs;
using System.Windows;
using System.Windows.Controls;

namespace DataCommandTest.Manage
{
    internal class Conditions_Grid(Button btn, Grid grid)
    {
        public Button Button_Cond { get; private set; } = btn;
        public Grid Grid_Cond { get; private set; } = grid;

        public void Change_grid(Button btn_ch, Grid grid_ch)
        {
            Button_Cond.Background = BackField.ChangeColorHex("#FF0DBB24");
            Grid_Cond.Visibility = Visibility.Hidden;
            btn_ch.Background = BackField.ChangeColorHex("#FFB3FF01");
            grid_ch.Visibility = Visibility.Visible;
            Button_Cond = btn_ch;
            Grid_Cond = grid_ch;
        }
    }
}
