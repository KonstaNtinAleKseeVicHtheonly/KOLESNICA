using DataCommandTest.Customs;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DataCommandTest.Manage
{
    public static class DataWindow
    {
        public static void Add_Data_From_Window(Grid windowGrid, List<Label> labelGridCurrent)
        {
            Queue<Label> queue = [];
            switch (windowGrid.Name)
            {
                case "Grid_Window_Contacts":
                    for (int iter = 0; iter < labelGridCurrent.Count; iter++)
                    {
                        queue.Enqueue(labelGridCurrent[iter]);
                    }
                    foreach (var item in windowGrid!.Children)
                    {
                        if (item is TextBox)
                        {
                            var item_ = item as TextBox;
                            if (item_!.Background.ToString() == BackField.ChangeColorHex("#66FFAFAF").ToString())
                                return;
                            else
                                queue.Dequeue().Content = item_.Text;
                        }

                    }
                    break;
                case "Grid_Window_Auto":
                    for (int iter = 0; iter < labelGridCurrent.Count; iter++)
                    {
                        queue.Enqueue(labelGridCurrent[iter]);
                    }
                    foreach (var item in windowGrid!.Children)
                    {
                        if (item is TextBox)
                        {
                            var item_ = item as TextBox;
                            if (item_!.Background.ToString() == BackField.ChangeColorHex("#66FFAFAF").ToString())
                                return;
                            else
                                queue.Dequeue().Content = item_.Text;
                        }

                    }
                    break;
                case "Grid_Window_Credits":
                    for (int iter = 0; iter < labelGridCurrent.Count; iter++)
                    {
                        if (iter != labelGridCurrent.Count - 1)
                        {
                            var item = windowGrid!.Children[iter] as TextBox;
                            if (item!.Background.ToString() == BackField.ChangeColorHex("#66FFAFAF").ToString())
                                return;
                            else
                                labelGridCurrent[iter].Content = item.Text;
                        }
                        else
                        {
                            string pushDataContent = string.Empty;
                            for (int iter_inner = iter; iter_inner < 7; iter_inner++)
                            {
                                var item = windowGrid!.Children[iter_inner] as TextBox;
                                if (item!.Background.ToString() == BackField.ChangeColorHex("#66FFAFAF").ToString())
                                    return;
                                else
                                    pushDataContent += $"{item.Text}-";
                            }
                            labelGridCurrent[iter].Content = pushDataContent == "---" ? string.Empty : pushDataContent[..^1];
                        }
                    }
                    break;
                default:
                    break;
            }

           
        }
    }
}
