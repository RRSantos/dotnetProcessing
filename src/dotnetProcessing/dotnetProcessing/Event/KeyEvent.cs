using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetProcessing.Event
{
    public class KeyEvent:BaseEvent
    {
        public char Char { get; protected set; }
        public int KeyCode { get; protected set; }
        public KeyEvent(PEventType type, int modifiers, char character, int keyCode)
            :base(type,modifiers)
        {
            Char = character;
            KeyCode = keyCode;
        }
    }
}
