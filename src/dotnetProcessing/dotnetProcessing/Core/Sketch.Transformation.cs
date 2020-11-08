using SFML.System;
using System.Collections.Generic;

namespace dotnetProcessing.Core
{
    partial class Sketch
    {

        protected void translate(float x, float y, float z)
        {
            graphics.Translate(x, y, z);
        }

        protected void translate(float x, float y)
        {
            graphics.Translate(x, y);
        }

        protected void rotate(float angleInRadians)
        {   
            graphics.Rotate(angleInRadians);
        }

        protected void push()
        {
            graphics.PushMatrix();
        }

        protected void pop()
        {
            graphics.PopMatrix();
        }
        protected void pushMatrix()
        {
            graphics.PushMatrix();
        }

        protected void popMatrix()
        {
            graphics.PopMatrix();
        }
    }
}
