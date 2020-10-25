using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace dotnetProcessing
{
    public class PVector
    {
        public float X { get; protected set; }
        public float Y { get; protected set; }
        public float Z { get; protected set; }

        public PVector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public PVector(float x, float y) : this(x, y, 0)
        { 
        }

        public PVector() : this(0, 0, 0)
        {
        }

        public PVector Set(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;

            return this;
        }

        public PVector Set(float x, float y)
        {
            return Set(x, y, Z);            
        }

        public PVector Set(PVector v)
        {
            return Set(v.X, v.Y, v.Z);
        }

        public PVector Set(IList<float> source)
        {
            if (source.Count < 1 || source.Count > 3)
            {
                throw new ArgumentException("The size of 'source' must be between 1 and 3", "source");
            }
            if (source.Count > 0)
            {
                X = source[0];                
            }
            if (source.Count > 1)
            {
                Y = source[1];
            }
            if (source.Count > 2)
            {
                Z = source[2];
            }

            return this;
        }

        public PVector Copy()
        {
            return new PVector(X, Y, Z);
        }

        public PVector Sub(PVector vectorToSubtract)
        {
            X -= vectorToSubtract.X;
            Y -= vectorToSubtract.Y;
            Z -= vectorToSubtract.Z;

            return this;
        }

        public PVector Sub(float x, float y)
        {
            return Sub(x,y,0);
        }

        public PVector Sub(float x, float y, float z)
        {
            X -= x;
            Y -= y;
            Z -= z;

            return this;
        }
        public static PVector Sub(PVector vectorA, PVector vectorB)
        {   
            return Sub(vectorA, vectorB, null);
        }

        public static PVector Sub(PVector vectorA, PVector vectorB, PVector target)
        {
            PVector resultVector; 
            if (target == null)
            {
                resultVector = vectorA.Copy();
                
            }
            else
            {
                target.X = vectorA.X;
                target.Y = vectorA.Y;
                target.Z = vectorA.Z;

                resultVector = target;
            }

            return resultVector.Sub(vectorB); 
        }

        public PVector Add(PVector vectorToAdd)
        {
            X += vectorToAdd.X;
            Y += vectorToAdd.Y;
            Z += vectorToAdd.Z;

            return this;
        }

        public PVector Add(float x, float y)
        {
            return Add(x,y,0);
        }

        public PVector Add(float x, float y, float z)
        {
            X += x;
            Y += y;
            Z += z;

            return this;
        }

        public static PVector Add(PVector vectorA, PVector vectorB)
        {
            return Add(vectorA, vectorB, null);
        }

        public static PVector Add(PVector vectorA, PVector vectorB, PVector target)
        {
            PVector resultVector;
            if (target == null)
            {
                resultVector = vectorA.Copy();

            }
            else
            {
                target.X = vectorA.X;
                target.Y = vectorA.Y;
                target.Z = vectorA.Z;

                resultVector = target;
            }

            return resultVector.Add(vectorB);
        }

        public PVector Mult(float scalar)
        {
            X *= scalar;
            Y *= scalar;
            Z *= scalar;

            return this;
        }

        public static PVector Mult(PVector vectorA, float scalar)
        {
            return Mult(vectorA, scalar, null);
        }

        public static PVector Mult(PVector vectorA, float scalar, PVector target)
        {
            PVector resultVector;
            if (target == null)
            {
                resultVector = vectorA.Copy();

            }
            else
            {
                target.X = vectorA.X;
                target.Y = vectorA.Y;
                target.Z = vectorA.Z;

                resultVector = target;
            }

            return resultVector.Mult(scalar);
        }

        public PVector Div(float scalar)
        {
            X /= scalar;
            Y /= scalar;
            Z /= scalar;

            return this;
        }

        public static PVector Div(PVector vectorA, float scalar)
        {
            return Div(vectorA, scalar, null);
        }

        public static PVector Div(PVector vectorA, float scalar, PVector target)
        {
            PVector resultVector;
            if (target == null)
            {
                resultVector = vectorA.Copy();

            }
            else
            {
                target.X = vectorA.X;
                target.Y = vectorA.Y;
                target.Z = vectorA.Z;

                resultVector = target;
            }

            return resultVector.Div(scalar);
        }

        public PVector Rotate(float theta)
        {
            Transformation transform = new Transformation() {Angle = theta};
            var rotated = transform.GetTransformedVector(X, Y);
            X = rotated.X;
            Y = rotated.Y;
            return this;
        }

        public float Dist(PVector v)
        {
            float dx = X - v.X;
            float dy = Y - v.Y;
            float dz = Z - v.Z;
            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public static float Dist(PVector a, PVector b)
        {
            PVector newVector = a.Copy();
            return newVector.Dist(b);
            
        }


    }
}
