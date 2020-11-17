using dotnetProcessing.Core;
using dotnetProcessing.Event;
using SFML.Graphics;
using SFML.Window;
using System;

namespace dotnetProcessing.SFML
{
    class PSurfaceSFML : IPSurface
    {
        private int width = IPSurface.MIN_WINDOW_WIDTH; 
        private int height = IPSurface.MIN_WINDOW_HEIGHT;
        private uint framerate = IPSurface.DEFAULT_FRAME_RATE;
        private string title = IPSurface.DEFAULT_WINDOW_TITLE;

        private bool isThreadStopped = true;
        private bool refreshPending = false;

        private RenderWindow window;
        
        private Sketch internalSketch;
        private readonly PGraphicsSFML graphicsSFML;

        private int getKeyboardModifiers()
        {
            int modifiers = BaseEvent.NONE;
            if (Keyboard.IsKeyPressed(Keyboard.Key.LShift) || Keyboard.IsKeyPressed(Keyboard.Key.RShift))
            {
                modifiers |= BaseEvent.SHIFT;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.LAlt) || Keyboard.IsKeyPressed(Keyboard.Key.RAlt))
            {
                modifiers |= BaseEvent.ALT;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.LControl) || Keyboard.IsKeyPressed(Keyboard.Key.RControl))
            {
                modifiers |= BaseEvent.CTRL;
            }

            return modifiers;
        }

        private int getKeyboardModifiers(KeyEventArgs e)
        {
            int modifiers = BaseEvent.NONE;
            if (e.Shift)
            {
                modifiers |= BaseEvent.SHIFT;
            }

            if (e.Alt)
            {
                modifiers |= BaseEvent.ALT;
            }

            if (e.Control)
            {
                modifiers |= BaseEvent.CTRL;
            }

            return modifiers;
        }

        private MouseEvent newMouseEvent(MouseButtonEventArgs e, PEventType eventType)
        {
            byte button;
            if (e.Button == Mouse.Button.Left)
            {
                button = PConstants.MOUSE_LEFT_BUTTON;
            }
            else if (e.Button == Mouse.Button.Right)
            {
                button = PConstants.MOUSE_RIGHT_BUTTON;
            }
            else
            {
                button = PConstants.MOUSE_CENTER_BUTTON;
            }

            int modifiers = getKeyboardModifiers();

            MouseEvent newEvent = new MouseEvent(
                eventType,
                modifiers, button,
                e.X,
                e.Y,
                1);

            return newEvent;
        }

        private Event.KeyEvent newKeyEvent(KeyEventArgs e, PEventType eventType)
        {
            int modifiers = getKeyboardModifiers(e);
            char keyChar = getKeyChar(e);

            int keyCode = keyChar == PConstants.CODED ? getKeyCode(e.Code) : keyChar;

            Event.KeyEvent newEvent = new Event.KeyEvent(
                eventType,
                modifiers,
                keyChar,
                keyCode
                );

            return newEvent;
        }

        private int getKeyCode(Keyboard.Key keyCode)
        {
            int result = 0;

            switch (keyCode)
            {   
                case Keyboard.Key.LControl:
                    result = PConstants.CONTROL;
                    break;
                case Keyboard.Key.LShift:
                    result = PConstants.SHIFT;
                    break;
                case Keyboard.Key.LAlt:
                    result = PConstants.ALT;
                    break;
                case Keyboard.Key.RControl:
                    result = PConstants.CONTROL;
                    break;
                case Keyboard.Key.RShift:
                    result = PConstants.SHIFT;
                    break;
                case Keyboard.Key.RAlt:
                    result = PConstants.ALT;
                    break;                
                case Keyboard.Key.Left:
                    result = PConstants.LEFT;
                    break;
                case Keyboard.Key.Right:
                    result = PConstants.RIGHT;
                    break;
                case Keyboard.Key.Up:
                    result = PConstants.UP;
                    break;
                case Keyboard.Key.Down:
                    result = PConstants.DOWN;
                    break;                
                default:
                    break;
            }

            return result;
        }

        private char getKeyChar(KeyEventArgs keyEvent)
        {
            char keyChar = '\0';
            switch (keyEvent.Code)
            {
                case Keyboard.Key.Unknown:
                    break;
                case Keyboard.Key.A:
                    keyChar = keyEvent.Shift ? 'A' : 'a';
                    break;
                case Keyboard.Key.B:
                    keyChar = keyEvent.Shift ? 'B' : 'b';
                    break;
                case Keyboard.Key.C:
                    keyChar = keyEvent.Shift ? 'C' : 'c';
                    break;
                case Keyboard.Key.D:
                    keyChar = keyEvent.Shift ? 'D' : 'd';
                    break;
                case Keyboard.Key.E:
                    keyChar = keyEvent.Shift ? 'E' : 'e';
                    break;
                case Keyboard.Key.F:
                    keyChar = keyEvent.Shift ? 'F' : 'f';
                    break;
                case Keyboard.Key.G:
                    keyChar = keyEvent.Shift ? 'G' : 'g';
                    break;
                case Keyboard.Key.H:
                    keyChar = keyEvent.Shift ? 'H' : 'h';
                    break;
                case Keyboard.Key.I:
                    keyChar = keyEvent.Shift ? 'I' : 'i';
                    break;
                case Keyboard.Key.J:
                    keyChar = keyEvent.Shift ? 'J' : 'j';
                    break;
                case Keyboard.Key.K:
                    keyChar = keyEvent.Shift ? 'K' : 'k';
                    break;
                case Keyboard.Key.L:
                    keyChar = keyEvent.Shift ? 'L' : 'l';
                    break;
                case Keyboard.Key.M:
                    keyChar = keyEvent.Shift ? 'M' : 'm';
                    break;
                case Keyboard.Key.N:
                    keyChar = keyEvent.Shift ? 'N' : 'n';
                    break;
                case Keyboard.Key.O:
                    keyChar = keyEvent.Shift ? 'O' : 'o';
                    break;
                case Keyboard.Key.P:
                    keyChar = keyEvent.Shift ? 'P' : 'p';
                    break;
                case Keyboard.Key.Q:
                    keyChar = keyEvent.Shift ? 'Q' : 'q';
                    break;
                case Keyboard.Key.R:
                    keyChar = keyEvent.Shift ? 'R' : 'r';
                    break;
                case Keyboard.Key.S:
                    keyChar = keyEvent.Shift ? 'S' : 's';
                    break;
                case Keyboard.Key.T:
                    keyChar = keyEvent.Shift ? 'T' : 't';
                    break;
                case Keyboard.Key.U:
                    keyChar = keyEvent.Shift ? 'U' : 'u';
                    break;
                case Keyboard.Key.V:
                    keyChar = keyEvent.Shift ? 'V' : 'v';
                    break;
                case Keyboard.Key.W:
                    keyChar = keyEvent.Shift ? 'W' : 'w';
                    break;
                case Keyboard.Key.X:
                    keyChar = keyEvent.Shift ? 'X' : 'x';
                    break;
                case Keyboard.Key.Y:
                    keyChar = keyEvent.Shift ? 'Y' : 'y';
                    break;
                case Keyboard.Key.Z:
                    keyChar = keyEvent.Shift ? 'Z' : 'z';
                    break;
                case Keyboard.Key.Num0:
                    keyChar = keyEvent.Shift ? ')' : '0';
                    break;
                case Keyboard.Key.Num1:
                    keyChar = keyEvent.Shift ? '!' : '1';
                    break;
                case Keyboard.Key.Num2:
                    keyChar = keyEvent.Shift ? '@' : '2';
                    break;
                case Keyboard.Key.Num3:
                    keyChar = keyEvent.Shift ? '#' : '3';
                    break;
                case Keyboard.Key.Num4:
                    keyChar = keyEvent.Shift ? '$' : '4';
                    break;
                case Keyboard.Key.Num5:
                    keyChar = keyEvent.Shift ? '%' : '5';
                    break;
                case Keyboard.Key.Num6:
                    keyChar = keyEvent.Shift ? '¨' : '6';
                    break;
                case Keyboard.Key.Num7:
                    keyChar = keyEvent.Shift ? '&' : '7';
                    break;
                case Keyboard.Key.Num8:
                    keyChar = keyEvent.Shift ? '*' : '8';
                    break;
                case Keyboard.Key.Num9:
                    keyChar = keyEvent.Shift ? '(' : '9';
                    break;
                case Keyboard.Key.Escape:
                    keyChar = PConstants.ESC;
                    break;
                case Keyboard.Key.LBracket:
                    keyChar = keyEvent.Shift ? '{' : '[';
                    break;
                case Keyboard.Key.RBracket:
                    keyChar = keyEvent.Shift ? '}' : ']';
                    break;
                case Keyboard.Key.Semicolon:
                    keyChar = keyEvent.Shift ? ':' : ';';
                    break;
                case Keyboard.Key.Comma:
                    keyChar = keyEvent.Shift ? '<' : ',';
                    break;
                case Keyboard.Key.Period:
                    keyChar = keyEvent.Shift ? '>' : '.';
                    break;
                case Keyboard.Key.Quote:
                    keyChar = keyEvent.Shift ? '"' : '\'';
                    break;
                case Keyboard.Key.Slash:
                    keyChar = keyEvent.Shift ? '?' : '/';
                    break;
                case Keyboard.Key.Backslash:
                    keyChar = keyEvent.Shift ? '|' : '\\';
                    break;
                case Keyboard.Key.Tilde:
                    keyChar = keyEvent.Shift ? '^' : '~';
                    break;
                case Keyboard.Key.Equal:
                    keyChar = keyEvent.Shift ? '+' : '=';
                    break;
                case Keyboard.Key.Hyphen:
                    keyChar = keyEvent.Shift ? '_' : '-';
                    break;
                case Keyboard.Key.Space:
                    keyChar = ' ';
                    break;
                case Keyboard.Key.Enter:
                    keyChar = PConstants.ENTER;
                    break;
                case Keyboard.Key.Backspace:
                    keyChar = PConstants.BACKSPACE;
                    break;
                case Keyboard.Key.Tab:
                    keyChar = PConstants.TAB;
                    break;
                case Keyboard.Key.Delete:
                    keyChar = PConstants.DELETE;
                    break;
                case Keyboard.Key.Add:
                    keyChar = '+';
                    break;
                case Keyboard.Key.Subtract:
                    keyChar = '-';
                    break;
                case Keyboard.Key.Multiply:
                    keyChar = '*';
                    break;
                case Keyboard.Key.Divide:
                    keyChar = '/';
                    break;
                case Keyboard.Key.Numpad0:
                    keyChar = '0';
                    break;
                case Keyboard.Key.Numpad1:
                    keyChar = '1';
                    break;
                case Keyboard.Key.Numpad2:
                    keyChar = '2';
                    break;
                case Keyboard.Key.Numpad3:
                    keyChar = '3';
                    break;
                case Keyboard.Key.Numpad4:
                    keyChar = '4';
                    break;
                case Keyboard.Key.Numpad5:
                    keyChar = '5';
                    break;
                case Keyboard.Key.Numpad6:
                    keyChar = '6';
                    break;
                case Keyboard.Key.Numpad7:
                    keyChar = '7';
                    break;
                case Keyboard.Key.Numpad8:
                    keyChar = '8';
                    break;
                case Keyboard.Key.Numpad9:
                    keyChar = '9';
                    break;
                case Keyboard.Key.LControl:
                    keyChar = PConstants.CODED;
                    break;
                case Keyboard.Key.LShift:
                    keyChar = PConstants.CODED;
                    break;
                case Keyboard.Key.LAlt:
                    keyChar = PConstants.CODED;
                    break;
                case Keyboard.Key.RControl:
                    keyChar = PConstants.CODED;
                    break;
                case Keyboard.Key.RShift:
                    keyChar = PConstants.CODED;
                    break;
                case Keyboard.Key.RAlt:
                    keyChar = PConstants.CODED;
                    break;                
                case Keyboard.Key.Left:
                    keyChar = PConstants.CODED;
                    break;
                case Keyboard.Key.Right:
                    keyChar = PConstants.CODED;
                    break;
                case Keyboard.Key.Up:
                    keyChar = PConstants.CODED;
                    break;
                case Keyboard.Key.Down:
                    keyChar = PConstants.CODED;
                    break;
                default:
                    break;
            }

            return keyChar;
        }


        private void attachEventsToWindow()
        {
            window.Closed += Window_Closed;

            window.MouseButtonPressed += Window_MouseButtonPressed;
            window.MouseButtonReleased += Window_MouseButtonReleased;
            window.MouseMoved += Window_MouseMoved;
            window.KeyPressed += Window_KeyPressed;
            window.KeyReleased += Window_KeyReleased;
            window.TextEntered += Window_TextEntered;
            
        }

        private void Window_KeyReleased(object sender, KeyEventArgs e)
        {
            Event.KeyEvent newEvent = newKeyEvent(e, PEventType.KEY_UP);
            internalSketch.PostEvent(newEvent);
        }

        private void Window_TextEntered(object sender, TextEventArgs e)
        {
            //typedEvent? e.Unicode
            
        }        

        private void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            Event.KeyEvent newEvent = newKeyEvent(e, PEventType.KEY_DOWN);
            internalSketch.PostEvent(newEvent);
            
        }
        

        private void Window_MouseMoved(object sender, MouseMoveEventArgs e)
        {
            byte button;
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                button = PConstants.MOUSE_LEFT_BUTTON;
            }
            else if (Mouse.IsButtonPressed(Mouse.Button.Right))
            {
                button = PConstants.MOUSE_RIGHT_BUTTON;
            }
            else if (Mouse.IsButtonPressed(Mouse.Button.Middle))
            {
                button = PConstants.MOUSE_CENTER_BUTTON;
            }
            else
            {
                button = 0;
            }

            PEventType eventType;
            if (button > 0)
            {
                eventType = PEventType.MOUSE_DRAG;
            }
            else
            {
                eventType = PEventType.MOUSE_MOVE;
            }

            int modifiers = getKeyboardModifiers();
            MouseEvent newEvent = new MouseEvent(
                eventType,
                modifiers, 
                button,
                e.X,
                e.Y,
                1);

            internalSketch.PostEvent(newEvent);

        }

        private void Window_MouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            MouseEvent newEvent = newMouseEvent(e, PEventType.MOUSE_BUTTON_UP);
            internalSketch.PostEvent(newEvent);

            MouseEvent newClickEvent = newMouseEvent(e, PEventType.MOUSE_CLICK);
            internalSketch.PostEvent(newClickEvent);
        }

        private void Window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            MouseEvent newEvent = newMouseEvent(e, PEventType.MOUSE_BUTTON_DOWN);
            internalSketch.PostEvent(newEvent);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }

        private void createWindow()
        {
            VideoMode video = new VideoMode((uint)width, (uint)height);
            window = new RenderWindow(video, title, Styles.Default);
            attachEventsToWindow();
            graphicsSFML.SetWindow(window);
            window.SetFramerateLimit(framerate);
        }

        public PSurfaceSFML(PGraphicsSFML graphicsSFML)
        {
            this.graphicsSFML = graphicsSFML;
            width = this.graphicsSFML.Width;
            height = this.graphicsSFML.Height;
            createWindow();
        }
        public object GetNative()
        {
            return window;
        }

        public void HideCursor()
        {
            throw new NotImplementedException();
        }

        public void InitFrame(Sketch sketch)
        {
            internalSketch = sketch;
        }

        public void InitOffscreen(Sketch sketch)
        {
            internalSketch = sketch;
        }

        public bool IsStopped()
        {
            return isThreadStopped;
        }

        public void PauseThread()
        {
            throw new NotImplementedException();
        }

        public void PlacePresent(int stopColor)
        {
            throw new NotImplementedException();
        }

        public void PlaceWindow(int[] location, int[] editorLocation)
        {
            throw new NotImplementedException();
        }

        public void ResumeThread()
        {
            throw new NotImplementedException();
        }

        public void SetAlwaysOnTop(bool alwaysOnTop)
        {
            throw new NotImplementedException();
        }

        public void SetCursor(int kind)
        {
            throw new NotImplementedException();
        }

        public void SetCursor(PImage image, int hotspotX, int hotspotY)
        {
            throw new NotImplementedException();
        }

        public void SetFrameRate(float fps)
        {
            framerate = (uint)fps;
            window.SetFramerateLimit(framerate);
        }

        public void SetIcon(PImage icon)
        {
            throw new NotImplementedException();
        }

        public void SetLocation(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void SetResizable(bool resizable)
        {
            throw new NotImplementedException();
        }

        public void SetSize(int width, int height)
        {
            this.width = width;
            this.height = height;

            if (window != null)
            {
                window.Dispose();
            }

            createWindow();
            
        }

        public void SetTitle(string title)
        {
            this.title = title;
            if (window != null)
            {
                window.SetTitle(this.title);
            }
        }

        public void SetupExternalMessages()
        {
            throw new NotImplementedException();
        }

        public void SetVisible(bool visible)
        {
            window.SetVisible(visible);
        }

        public void ShowCursor()
        {   
            throw new NotImplementedException();
        }

        public void StartThread()
        {
            //internalSketch.Setup();
            isThreadStopped = false;            

            while (!isThreadStopped && window.IsOpen)
            {
                window.DispatchEvents();
                internalSketch.HandleDraw();
                if (refreshPending)
                {
                    window.Display();
                    refreshPending = false;                    
                }
                
            }

        }

        public bool StopThread()
        {            
            isThreadStopped = true;
            return isThreadStopped;
        }

        public void RefreshNeeded()
        {
            refreshPending = true;
        }

        
    }
}
