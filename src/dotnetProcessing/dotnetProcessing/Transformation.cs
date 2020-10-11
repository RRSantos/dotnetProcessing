using SFML.System;
using System;

namespace dotnetProcessing
{
    class Transformation
    {
        public float Angle { get; set; }
        public Vector3f Origin { get; set; }

        public Transformation()
        {
            Origin = new Vector3f(0, 0, 0);
            Angle = 0;
        }
        public Vector2f GetTransformedVector(float x , float y)
        {
            double newX = Origin.X + x * Math.Cos(Angle) - y * Math.Sin(Angle);
            double newY = Origin.Y + x * Math.Sin(Angle) + y * Math.Cos(Angle);

            return new Vector2f((float)newX, (float)newY);
        }
    }
}
