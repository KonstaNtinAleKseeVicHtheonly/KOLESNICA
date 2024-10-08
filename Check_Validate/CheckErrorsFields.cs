using DataCommandTest.Customs;
using System.Windows.Controls;

namespace DataCommandTest.Check_Validate
{
    public static class CheckErrorsFields
    {
        public static bool CheckReds(List<Grid> grid, Label lb)
        {
            for (int next_grid = 0; next_grid < grid.Count; next_grid++)
            {
                foreach (var item in grid[next_grid].Children)
                {
                    if (item is TextBox)
                    {
                        var item_ = item as TextBox;
                        if (item_!.Background.ToString() != BackField.ChangeColorHex("#00FFFFFF").ToString())
                        {
                            lb.Content = "Обнаружены невалидные данные. (Поля выделены красным цветом)";
                            lb.Foreground = BackField.ChangeColorHex("#FFFF0000");
                            return false;
                        }
                    }
                }
            }
            lb.Content = "Данные готовы к отправке";
            lb.Foreground = BackField.ChangeColorHex("#FF00FF00");
            return true;
        }
    }
}
