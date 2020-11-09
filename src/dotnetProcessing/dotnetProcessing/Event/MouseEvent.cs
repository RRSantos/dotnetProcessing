
namespace dotnetProcessing.Event
{
    public class MouseEvent:BaseEvent
    {

        public int Count { get; protected set; }
        public byte Button { get; protected set; }
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public MouseEvent(PEventType type, int modifiers, byte button, int x, int y, int count)
            :base(type, modifiers)
        {
            Button = button;
            X = x;
            Y = y;
            Count = count;
        }
    }
}
