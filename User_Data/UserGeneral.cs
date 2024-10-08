using DataCommandTest.Enums;
using System.Windows.Controls;

namespace DataCommandTest.User_Data
{
    class UserGeneral : User
    {
        public string? SecondName { get; private set; }
        public string? FirstName { get; private set; }
        public string? ThirdName { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public string? PlaceOfBirth { get; private set; }
        public Sex? Sex { get; private set; }
        public UserGeneral() 
        {
            SecondName = null;
            FirstName = null;
            ThirdName = null;
            DateOfBirth = null;
            PlaceOfBirth = null;
            Sex = null; // ISSUE
        }
        public override void SetData(Queue<TextBox> fields)
        {
            SecondName = fields.Dequeue().Text;
            FirstName = fields.Dequeue().Text;
            ThirdName = fields.Dequeue().Text;
            string DateY = fields.Dequeue().Text;
            string DateM = fields.Dequeue().Text;
            string DateD = fields.Dequeue().Text;
            DateOfBirth = DateY != string.Empty ? DateTime.ParseExact($"{DateY}-{DateM}-{DateD}", "yyyy-M-d", null) : null;
            PlaceOfBirth = fields.Dequeue().Text ?? null;
        }
        public override void SetData(Queue<Label> fields)
        {
            throw new NotImplementedException();
        }
    }
}
