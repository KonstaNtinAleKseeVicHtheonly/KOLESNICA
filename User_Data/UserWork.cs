using System.Windows.Controls;

namespace DataCommandTest.User_Data
{
    class UserWork : User
    {
        public string? Doljnost { get; private set; }
        public string? Otdel { get; private set; }
        public double? Positive { get; private set; }
        public double? Negative { get; private set; }
        public double? Rating { get; private set; }

        public UserWork()
        {
            Doljnost = null;
            Otdel = null;
            Positive = null;
            Negative = null;
            Rating = null;
        }
        public override void SetData(Queue<Label> fields)
        {
            throw new NotImplementedException();
        }
        public override void SetData(Queue<TextBox> fields)
        {
            Doljnost = fields.Dequeue().Text ?? "NULL";
            Otdel = fields.Dequeue().Text ?? "NULL";

            string? posString = fields.Dequeue().Text;
            Positive = posString == string.Empty ? 0 : Convert.ToDouble(posString);

            string? negString = fields.Dequeue().Text;
            Negative = negString == string.Empty ? 0 : Convert.ToDouble(negString);

            string? ratString = fields.Dequeue().Text;
            Rating = ratString == string.Empty ? 0 : Convert.ToDouble(ratString);


        }
    }
}
