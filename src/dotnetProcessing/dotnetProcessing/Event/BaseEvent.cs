namespace dotnetProcessing.Event
{
    public enum PEventType  {
        KEY_DOWN = 0, 
        KEY_UP = 1,
        TYPE = 2,
        MOUSE_BUTTON_DOWN =3, 
        MOUSE_BUTTON_UP=4,
        MOUSE_CLICK = 5,
        MOUSE_DRAG = 6,
        MOUSE_MOVE = 7,
        MOUSE_ENTER = 8,
        MOUSE_EXIT = 9,
        MOUSE_WHEEL = 10
    }
    public class BaseEvent
    {
        public const int NONE = 0;
        public const int SHIFT = 1 << 0;
        public const int CTRL = 1 << 1;
        public const int ALT = 1 << 2;

        public PEventType Type { get; protected set; }
        public int Modifiers { get; protected set; }
        public bool IsShiftDown { get { return (Modifiers & SHIFT) != 0; } }
        public bool IsAltDown { get { return (Modifiers & ALT) != 0; } }
        public bool IsCtrlDown { get { return (Modifiers & CTRL) != 0; } }

        public BaseEvent(PEventType type, int modifiers)
        {
            Type = type;
            Modifiers = modifiers;
        }


    }
}
