using SFML.System;
using System.Collections.Generic;

namespace dotnetProcessing.Core
{
    partial class Sketch
    {
        private readonly Stack<Transformation> transformationStack = new Stack<Transformation>();
        private Transformation transformation = new Transformation();


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
            float newAngle = transformation.Angle + angleInRadians;
            graphics.Rotate(newAngle);
        }

        protected void push()
        {   
            transformationStack.Push(transformation.Copy());
        }

        protected void pop()
        {
            transformation = transformationStack.Pop();
            //drawing.SetTransformation(transformation);
        }
    }
}
