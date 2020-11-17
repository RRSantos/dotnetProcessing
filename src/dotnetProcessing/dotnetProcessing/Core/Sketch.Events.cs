using dotnetProcessing.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetProcessing.Core
{
    public abstract partial class Sketch
    {

        private readonly Queue<BaseEvent> eventQueue = new Queue<BaseEvent>();
        
        protected const byte CENTER = PConstants.MOUSE_CENTER_BUTTON;

        protected const char CODED = PConstants.CODED;
        protected const char BACKSPACE = PConstants.BACKSPACE;
        protected const char TAB = PConstants.TAB;
        protected const char ENTER = PConstants.ENTER;
        protected const char ESC = PConstants.ESC;
        protected const char DELETE = PConstants.DELETE;

        protected const int UP = PConstants.UP;
        protected const int DOWN = PConstants.DOWN;
        protected const int LEFT = PConstants.LEFT;
        protected const int RIGHT = PConstants.RIGHT;
        protected const int ALT = PConstants.ALT;
        protected const int CONTROL = PConstants.CONTROL;
        protected const int SHIFT = PConstants.SHIFT;


        

        protected bool isKeyPressed = false;
        protected char key = '\0';
        protected int keyCode = 0;

        protected bool isMousePressed = false;
        protected byte mouseButton;
        protected int mouseX;
        protected int mouseY;
        protected int pmouseX;
        protected int pmouseY;

        private void dequeueEvents()
        {
            while (eventQueue.TryDequeue(out BaseEvent evnt))
            {
                processEvent(evnt);
            }
        }

        private void processEvent(BaseEvent receivedEvent)
        {
            if (receivedEvent is MouseEvent)
            {
                processMouseEvent((MouseEvent)receivedEvent);
            }
            else if (receivedEvent is KeyEvent)
            {
                processKeyEvent((KeyEvent)receivedEvent);
            }
            else
            {
                throw new NotImplementedException($"Handle for event class '{receivedEvent.GetType()}' not implemented");
            }
        }

        private void processMouseEvent(MouseEvent receivedEvent)
        {
            mouseButton = receivedEvent.Button;
            pmouseX = mouseX;
            pmouseY = mouseY;
            mouseX = receivedEvent.X;
            mouseY = receivedEvent.Y;

            switch (receivedEvent.Type)
            {
                
                case PEventType.MOUSE_BUTTON_DOWN:
                    isMousePressed = true;
                    mousePressed();
                    break;
                case PEventType.MOUSE_BUTTON_UP:
                    isMousePressed = false;
                    mouseReleased();
                    break;
                case PEventType.MOUSE_CLICK:
                    mouseClicked();
                    break;
                case PEventType.MOUSE_DRAG:
                    isMousePressed = true;
                    mouseDragged();
                    break;
                case PEventType.MOUSE_MOVE:
                    isMousePressed = false;
                    mouseMoved();
                    break;
                case PEventType.MOUSE_ENTER:
                    
                    break;
                case PEventType.MOUSE_EXIT:
                    
                    break;
                case PEventType.MOUSE_WHEEL:
                    mouseWheel(receivedEvent);
                    break;
                default:
                    throw new NotImplementedException($"Event type not expected: '{receivedEvent.Type}'");
            }            
        }

        private void processKeyEvent(KeyEvent receivedEvent)
        {
            key = receivedEvent.Char;
            keyCode = receivedEvent.KeyCode;

            switch (receivedEvent.Type)
            {
                case PEventType.KEY_DOWN:
                    isKeyPressed = true;
                    keyPressed();
                    break;
                case PEventType.KEY_UP:
                    isKeyPressed = false;
                    keyReleased();
                    break;
                case PEventType.TYPE:
                    keyTyped();
                    break;                
                default:
                    break;
            }
        }

        public void PostEvent(BaseEvent receivedEvent)
        {
            eventQueue.Enqueue(receivedEvent);

            if (isNoLoop)
            {
                dequeueEvents();
            }
            
        }

        

        protected virtual void mousePressed()
        {
            
        }

        protected virtual void mouseReleased()
        {

        }

        protected virtual void mouseClicked()
        {

        }

        protected virtual void mouseDragged()
        {

        }

        protected virtual void mouseMoved()
        {

        }

        protected virtual void mouseWheel(MouseEvent mouseEvent)
        {

        }

        protected virtual void keyPressed()
        {

        }

        protected virtual void keyReleased()
        {

        }

        protected virtual void keyTyped()
        {

        }


    }
}
