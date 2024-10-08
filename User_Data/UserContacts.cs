using DataCommandTest.Enums;
using System.Windows.Controls;

namespace DataCommandTest.User_Data
{
    class UserContacts : User
    {
        public string? NumberPhone { get; private set; }
        public string? Address { get; private set; }
        //public List<string> Addresses { get; private set; }
        //public List<string> TeleNumbers { get; private set; }
        public UserContacts() 
        {
            NumberPhone = null;
            Address = null;
        }
        public override void SetData(Queue<TextBox> fields)
        {
            throw new NotImplementedException();
        }
        public override void SetData(Queue<Label> fields)
        {
            NumberPhone = fields.Dequeue().Content.ToString() ?? "NULL";
            Address = fields.Dequeue().Content.ToString() ?? "NULL";
        }
    }
}
