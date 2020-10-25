using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace dotnetProcessing
{
    public class PVector
    {
        private bool isAllComponentsZero(PVector testVector)
        {
            return (testVector.X == 0 && testVector.Y == 0 && testVector.Z == 0);
        }
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

        public float MagSq()
        {
            return (X * X + Y * Y + Z * Z);
        }

        public float Mag()
        {
            return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public float Dot(PVector v)
        {
            return Dot(v.X, v.Y, v.Z);
        }

        public float Dot(float x, float y, float z)
        {
            return (x * X + y * Y + z * Z);
        }

        public static float Dot(PVector a, PVector b)
        {
            return a.Dot(b);
        }

        public PVector Cross(PVector v)
        {
            return Cross(v,null);
        }

        public PVector Cross(PVector v, PVector target)
        {
            float xCrossComponent = Y * v.Z - Z * v.Y;
            float yCrossComponent = Z * v.X - X * v.Z;
            float zCrossComponent = X * v.Y - Y * v.X;

            if (target == null)
            {
                target = new PVector(xCrossComponent, yCrossComponent, zCrossComponent);
            }
            else
            {
                target.Set(xCrossComponent, yCrossComponent, zCrossComponent);
            }

            return target;
        }

        public static PVector Cross(PVector v1, PVector v2, PVector target)
        {
            PVector crossProduct = v1.Cross(v2);

            if (target == null)
            {
                target = crossProduct;
            }
            else
            {
                target.Set(crossProduct.X, crossProduct.Y, crossProduct.Z);
            }

            return target;
        }

        public PVector Normalize()
        {
            float magnitude = Mag();

            if (magnitude!= 0 && magnitude != 1)
            {
                Div(magnitude);
            }

            return this;
        }

        public PVector Normalize(PVector target)
        {
            if (target == null)
            {
                target = Copy();
            }

            target.Normalize();

            return target;
        }

        public PVector Limit(float max)
        {
            if (MagSq() > max*max)
            {
                return SetMag(max);
            }

            return this;
        }

        public PVector SetMag(float length)
        {
            if (length <= 0f)
            {
                throw new ArgumentException("New magnitude should be greater than zero.", "length");
            }
            Normalize();
            Mult(length);
            return this;
        }

        public PVector SetMag(PVector target, float length)
        {
            return target.SetMag(length);
        }

        public float Heading()
        {
            return (float)Math.Atan2(Y, X);
        }


        public float AngleBetween(PVector v)
        {
            if (isAllComponentsZero(this) || isAllComponentsZero(v))
                return 0.0f;

            float dotProduct = Dot(v);
            float thisMagnitude = Mag();
            float vMagnitude  = v.Mag();
            float cosAngle = dotProduct / (thisMagnitude * vMagnitude);
            float angle = (float)Math.Acos(cosAngle);

            return angle;
        }

        public float[] Array()
        {
            float[] result = new float[3] { X,Y,Z};
            return result;
        }

        public static PVector FromAngle(float angle)
        {
            return FromAngle(angle, null);
        }

        public static PVector FromAngle(float angle, PVector target)
        {
            if (target == null)
            {
                target = new PVector();
            }
            float x = (float)Math.Cos(angle);
            float y = (float)Math.Sin(angle);

            target.Set(x, y);

            return target;
        }

        public static PVector Random2D(PVector target, Random random)
        {
            if (random == null)
            {
                random = new Random();
            }

            float randomAngle = (float)(random.NextDouble() * Math.PI * 2);

            if (target == null)
            {
                target = FromAngle(randomAngle);
            }
            else
            {
                PVector vectorFromAngle = FromAngle(randomAngle);
                target.Set(vectorFromAngle.X, vectorFromAngle.Y);
            }

            return target;

        }

        public static PVector Random2D()
        {
            return Random2D(null, null);
        }

        public static PVector Random2D(Random random)
        {
            return Random2D(null, random);
        }

        public static PVector Random2D(PVector target)
        {
            return Random2D(target, null);
        }






    }
}
