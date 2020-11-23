using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetProcessing.Core
{
    static class PConstants
    {
        public const byte MOUSE_LEFT_BUTTON = LEFT;
        public const byte MOUSE_RIGHT_BUTTON = RIGHT;
        public const byte MOUSE_CENTER_BUTTON = CENTER;

        public const byte CENTER = 3;
        public const byte TOP = 4;
        public const byte BOTTOM = 5;

        public const char BACKSPACE = (char)8;
        public const char TAB = (char)9;
        public const char ENTER = (char)10;
        public const char RETURN = (char)13;
        public const char ESC = (char)27;
        public const char DELETE = (char)127;

        public const char CODED = (char)0xffff;

        public const int UP = (int)ConsoleKey.UpArrow;
        public const int DOWN = (int)ConsoleKey.DownArrow;
        public const int LEFT = (int)ConsoleKey.LeftArrow;
        public const int RIGHT = (int)ConsoleKey.RightArrow;
        

        public const int ALT = 18;
        public const int CONTROL = 17;
        public const int SHIFT = 16;


        public const byte P2D = 1;
        public const byte P3D = 2;

    }
}
