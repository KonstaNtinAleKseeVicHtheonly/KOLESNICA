using System.Diagnostics.Metrics;
using System.Windows.Controls;
using System.Windows.Media;

namespace DataCommandTest.Customs
{
    internal class BackField
    {
        // #00 AF 12 B3
        public static SolidColorBrush ChangeColorHex(string hex)
        {
            if (hex[0] == '#' && hex.Length == 9)
            {
                hex = hex[1..];
                return new SolidColorBrush(Color.FromArgb(
                    Convert.ToByte(hex[..2], 16), 
                    Convert.ToByte(hex[2..4], 16), 
                    Convert.ToByte(hex[4..6], 16), 
                    Convert.ToByte(hex[6..8], 16)));
            }
            else
                throw new ArgumentException("Указан невалидный хеш - код");
        }
        public static void DateChangeBack(Queue<TextBox> textBox, SolidColorBrush brushes)
        {
            int counter = textBox.Count;
            for (int i = 0; i < counter; i++) 
                textBox.Dequeue().Background = brushes;
        }
    }
}
