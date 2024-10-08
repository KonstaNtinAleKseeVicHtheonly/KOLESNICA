using System.Windows.Controls;

namespace DataCommandTest.User_Data
{
    class UserAuto : User
    {
        public string? Model { get; private set; }
        public string? Marka { get; private set; }
        public string? Gos { get; private set; }
        public string? ColorAuto { get; private set; }

        public UserAuto()
        {
            Model = null;
            Marka = null;
            Gos = null;
            ColorAuto = null;
        }
        public override void SetData(Queue<TextBox> fields)
        {
            throw new NotImplementedException();
        }
        public override void SetData(Queue<Label> fields)
        {
            Model = fields.Dequeue().Content.ToString() ?? null;
            Marka = fields.Dequeue().Content.ToString() ?? null;
            Gos = fields.Dequeue().Content.ToString() ?? null;
            ColorAuto = fields.Dequeue().Content.ToString() ?? null;
        }
    }
}
