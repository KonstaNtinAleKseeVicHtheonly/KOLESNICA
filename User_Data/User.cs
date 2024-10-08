using System.Windows.Controls;

namespace DataCommandTest.User_Data
{
    public abstract class User
    {
        public User() 
        {

        }
        public abstract void SetData(Queue<TextBox> fields);
        public abstract void SetData(Queue<Label> fields);
    }
}
