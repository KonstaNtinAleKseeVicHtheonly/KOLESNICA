using System.Windows.Controls;

namespace DataCommandTest.User_Data
{
    class UserCredits : User
    {
        public string? Org { get; private set; }
        public string? Type { get; private set; }
        public double? Summa { get; private set; }
        public double? Payment { get; private set; }
        public DateTime? DateLastPayment { get; private set; }
        public UserCredits()
        {
            Org = null;
            Type = null;
            Summa = null;
            Payment = null;
            DateLastPayment = null;
        }
        public override void SetData(Queue<TextBox> fields)
        {
            throw new NotImplementedException();
        }
        public override void SetData(Queue<Label> fields)
        {
            Org = fields.Dequeue().Content.ToString() ?? null;
            Type = fields.Dequeue().Content.ToString() ?? null;

            string? sumString = fields.Dequeue().Content.ToString();
            Summa = sumString == string.Empty ? 0 : Convert.ToDouble(sumString);

            string? payString = fields.Dequeue().Content.ToString();
            Payment = payString == string.Empty ? 0 : Convert.ToDouble(payString);

            string? date = fields.Dequeue().Content.ToString(); //
            DateLastPayment = date == string.Empty ? null : DateTime.ParseExact($"{date}", "yyyy-M-d", null);
            
        }
    }
}
