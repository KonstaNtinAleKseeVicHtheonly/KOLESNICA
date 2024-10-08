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
            Org = fields.Dequeue().Content.ToString() ?? "NULL";
            Type = fields.Dequeue().Content.ToString() ?? "NULL";
            Summa = Convert.ToDouble(fields.Dequeue().Content.ToString());
            Payment = Convert.ToDouble(fields.Dequeue().Content.ToString());
            string DateY = fields.Dequeue().Content.ToString(); //
            string DateM = fields.Dequeue().Content.ToString(); //
            string DateD = fields.Dequeue().Content.ToString(); //
            DateLastPayment = DateY != string.Empty ? DateTime.ParseExact($"{DateY}-{DateM}-{DateD}", "yyyy-M-d", null) : null;
            
        }
    }
}
