using System;
using dotnetProcessing.Core;

namespace dotnetProcessing
{
    public class Transformation
    {
        public float Angle { get; protected set; }
        
        protected PVector origin;

        private PVector getRotatedVector(PVector vector)
        {
            float newX = (float)(vector.X * Math.Cos(Angle) - vector.Y * Math.Sin(Angle));
            float newY = (float)(vector.X * Math.Sin(Angle) + vector.Y * Math.Cos(Angle));

            return new PVector(newX, newY);
        }

        public void SetAngle(float newAngle)
        {
            Angle = newAngle;            
        }

        public Transformation()
        {
            origin = new PVector(0, 0, 0);
            Angle = 0;
        }
        public PVector GetTransformedVector(float x , float y)
        {
            PVector originalVector = new PVector(x, y);
            PVector rotatedVector = getRotatedVector(originalVector);           

            rotatedVector.Add(origin);

            return rotatedVector;
        }

        public void Clear()
        {
            origin.Set(0, 0, 0);
            Angle = 0;
        }

        public void Translate(float x, float y, float z)
        {
            PVector originalVector = new PVector(x, y, z);
            PVector rotatedVector = getRotatedVector(originalVector);
            origin.Add(rotatedVector);
        }

        public Transformation Copy()
        {
            Transformation transformationCopy = new Transformation
            {
                Angle = Angle,
                origin = origin.Copy()
            };
            return transformationCopy;

        }
    }
}
