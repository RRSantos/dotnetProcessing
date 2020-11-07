using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetProcessing.Core
{
    public abstract partial class Sketch
    {
        protected const byte LEFT = 1;
        protected const byte RIGHT = 2;
        protected const byte CENTER = 3;
        
        protected bool isMousePressed = false;
        protected byte mouseButton;

        protected virtual void mousePressed()
        {

        }

        protected virtual void mouseReleased()
        {

        }
        
    }
}
