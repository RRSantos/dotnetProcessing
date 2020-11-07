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
            transformation.Translate(x, y, z);
        }

        protected void translate(float x, float y)
        {
            translate(x, y, 0);
        }

        protected void rotate(float angleInRadians)
        {
            float newAngle = transformation.Angle + angleInRadians;
            transformation.SetAngle(newAngle);            
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
