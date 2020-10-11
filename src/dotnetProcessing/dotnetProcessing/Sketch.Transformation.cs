using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetProcessing
{
    partial class Sketch
    {
        protected void translate(float x, float y, float z)
        {
            transformation.Origin = new Vector3f(x, y, z);
        }

        protected void translate(float x, float y)
        {
            transformation.Origin = new Vector3f(x, y, transformation.Origin.Z);
        }

        protected void rotate(float angleInRadians)
        {
            transformation.Angle = angleInRadians;
        }
    }
}
