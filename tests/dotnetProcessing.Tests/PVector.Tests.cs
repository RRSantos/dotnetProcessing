using System;
using Xunit;
using dotnetProcessing;
using SFML.Graphics;

namespace dotnetProcessing.Tests
{
    public class PVectorTests
    {
        private const double ROUNDING_ERROR = 0.000001d;

        [Fact]
        public void ShouldCopyComponentsFrom3dVector()
        {
            PVector originalVector = new PVector(10, 20.30f, 40.5678f);
            PVector copyVector = originalVector.Copy();

            Assert.NotEqual(originalVector, copyVector);

            Assert.Equal(originalVector.X, copyVector.X);
            Assert.Equal(originalVector.Y, copyVector.Y);
            Assert.Equal(originalVector.Z, copyVector.Z);

        }

        [Fact]
        public void ShouldSubtractVectorAndReturnItself()
        {
            PVector originalVector = new PVector(1.2f, 3.456f, 7.8901f);
            PVector vectorToSubtractFrom = new PVector(.2f, .456f, .8901f);

            PVector subtractedVector = originalVector.Sub(vectorToSubtractFrom);

            
            Assert.Equal(1f, originalVector.X);
            Assert.Equal(3f, originalVector.Y);
            Assert.Equal(7f, originalVector.Z);

            
            Assert.Equal(subtractedVector, originalVector);
            Assert.Equal(subtractedVector.X, originalVector.X);
            Assert.Equal(subtractedVector.Y, originalVector.Y);
            Assert.Equal(subtractedVector.Z, originalVector.Z);
        }

        [Fact]
        public void ShouldSubtract2ComponentsAndReturnItself()
        {
            PVector originalVector = new PVector(1.2f, 3.456f, 7.8901f);

            PVector subtractedVector = originalVector.Sub(.2f, .456f);

            Assert.Equal(1f, originalVector.X);
            Assert.Equal(3f, originalVector.Y);
            Assert.Equal(7.8901f, originalVector.Z); 

            
            Assert.Equal(subtractedVector, originalVector);
            Assert.Equal(subtractedVector.X, originalVector.X);
            Assert.Equal(subtractedVector.Y, originalVector.Y);
            Assert.Equal(subtractedVector.Z, originalVector.Z);
        }

        [Fact]
        public void ShouldSubtract3ComponentsAndReturnItself()
        {
            PVector originalVector = new PVector(1.2f, 3.456f, 7.8901f);

            PVector subtractedVector = originalVector.Sub(.2f, .456f, .8901f);

            Assert.Equal(1f, originalVector.X);
            Assert.Equal(3f, originalVector.Y);
            Assert.Equal(7, originalVector.Z);


            Assert.Equal(subtractedVector, originalVector);
            Assert.Equal(subtractedVector.X, originalVector.X);
            Assert.Equal(subtractedVector.Y, originalVector.Y);
            Assert.Equal(subtractedVector.Z, originalVector.Z);
        }

        [Fact]
        public void ShouldReturnSubtractedVectorWhithoutChangingOriginalVectors()
        {
            PVector vectorA = new PVector(1.2f, 3.456f, 7.8901f);

            PVector vectorB = new PVector(.2f, .456f, .8901f);

            PVector subtractedVector = PVector.Sub(vectorA, vectorB);

            Assert.Equal(1f, subtractedVector.X);
            Assert.Equal(3f, subtractedVector.Y);
            Assert.Equal(7, subtractedVector.Z);

            Assert.Equal(1.2f, vectorA.X);
            Assert.Equal(3.456f, vectorA.Y);
            Assert.Equal(7.8901f, vectorA.Z);

            Assert.Equal(.2f, vectorB.X);
            Assert.Equal(.456f, vectorB.Y);
            Assert.Equal(.8901f, vectorB.Z);

        }

        [Fact]
        public void ShouldAssignSubtractedVectorToTargetWhithoutChangingOriginalVectors()
        {
            PVector vectorA = new PVector(1.2f, 3.456f, 7.8901f);

            PVector vectorB = new PVector(.2f, .456f, .8901f);

            PVector targetVector = new PVector();

            PVector returnedVector = PVector.Sub(vectorA, vectorB, targetVector);

            Assert.Equal(returnedVector, targetVector);

            Assert.Equal(1f, targetVector.X);
            Assert.Equal(3f, targetVector.Y);
            Assert.Equal(7, targetVector.Z);

            Assert.Equal(1.2f, vectorA.X);
            Assert.Equal(3.456f, vectorA.Y);
            Assert.Equal(7.8901f, vectorA.Z);

            Assert.Equal(.2f, vectorB.X);
            Assert.Equal(.456f, vectorB.Y);
            Assert.Equal(.8901f, vectorB.Z);
        }

        [Fact]
        public void ShouldAddVectorAndReturnItself()
        {   
            PVector originalVector = new PVector(1, 3, 7);
            PVector vectorToSubtractFrom = new PVector(.2f, .456f, .8901f);

            PVector addedVector = originalVector.Add(vectorToSubtractFrom);


            Assert.Equal(1.2f, originalVector.X);
            Assert.Equal(3.456f, originalVector.Y);
            Assert.Equal(7.8901f, originalVector.Z);


            Assert.Equal(addedVector, originalVector);
            Assert.Equal(addedVector.X, originalVector.X);
            Assert.Equal(addedVector.Y, originalVector.Y);
            Assert.Equal(addedVector.Z, originalVector.Z);
        }

        [Fact]
        public void ShouldAdd2ComponentsAndReturnItself()
        {
            PVector originalVector = new PVector(1, 3, 7);

            PVector addedVector = originalVector.Add(.2f, .456f);

            Assert.Equal(1.2f, originalVector.X);
            Assert.Equal(3.456f, originalVector.Y);
            Assert.Equal(7, originalVector.Z);


            Assert.Equal(addedVector, originalVector);
            Assert.Equal(addedVector.X, originalVector.X);
            Assert.Equal(addedVector.Y, originalVector.Y);
            Assert.Equal(addedVector.Z, originalVector.Z);
        }

        [Fact]
        public void ShouldAdd3ComponentsAndReturnItself()
        {
            PVector originalVector = new PVector(1, 3, 7);

            PVector addedVector = originalVector.Add(.2f, .456f, .8901f);

            Assert.Equal(1.2f, originalVector.X);
            Assert.Equal(3.456f, originalVector.Y);
            Assert.Equal(7.8901f, originalVector.Z);


            Assert.Equal(addedVector, originalVector);
            Assert.Equal(addedVector.X, originalVector.X);
            Assert.Equal(addedVector.Y, originalVector.Y);
            Assert.Equal(addedVector.Z, originalVector.Z);
        }

        [Fact]
        public void ShouldReturnAddedVectorWhithoutChangingOriginalVectors()
        {
            PVector vectorA = new PVector(1, 3, 7);

            PVector vectorB = new PVector(.2f, .456f, .8901f);

            PVector addedVector = PVector.Add(vectorA, vectorB);

            Assert.Equal(1.2f, addedVector.X);
            Assert.Equal(3.456f, addedVector.Y);
            Assert.Equal(7.8901f, addedVector.Z) ; ;

            Assert.Equal(1, vectorA.X);
            Assert.Equal(3, vectorA.Y);
            Assert.Equal(7, vectorA.Z);

            Assert.Equal(.2f, vectorB.X);
            Assert.Equal(.456f, vectorB.Y);
            Assert.Equal(.8901f, vectorB.Z);

        }

        [Fact]
        public void ShouldAssignAddedVectorToTargetWhithoutChangingOriginalVectors()
        {
            PVector vectorA = new PVector(1, 3, 7);

            PVector vectorB = new PVector(.2f, .456f, .8901f);

            PVector targetVector = new PVector();

            PVector returnedVector = PVector.Add(vectorA, vectorB, targetVector);

            Assert.Equal(returnedVector, targetVector);

            Assert.Equal(1.2f, targetVector.X);
            Assert.Equal(3.456f, targetVector.Y);
            Assert.Equal(7.8901f, targetVector.Z);

            Assert.Equal(1f, vectorA.X);
            Assert.Equal(3f, vectorA.Y);
            Assert.Equal(7, vectorA.Z);            

            Assert.Equal(.2f, vectorB.X);
            Assert.Equal(.456f, vectorB.Y);
            Assert.Equal(.8901f, vectorB.Z);
        }

        [Fact]
        public void ShouldMultiplyAllComponentsByTheScalarAndReturnItself()
        {
            float x = 1.2f;
            float y = 3.456f;
            float z = 7.8901f;
            float scalar = 3.58f;
            PVector vectorA = new PVector(x,y,z);
            
            PVector returnedVector = vectorA.Mult(scalar);

            Assert.Equal(returnedVector, vectorA);

            Assert.Equal(x * scalar, vectorA.X);
            Assert.Equal(y * scalar, vectorA.Y);
            Assert.Equal(z * scalar, vectorA.Z);
        }

        [Fact]
        public void ShouldReturnMultipliedVectorWhithoutChangingOriginalVector()
        {

            float x = 1.2f;
            float y = 3.456f;
            float z = 7.8901f;
            float scalar = 3.58f;
            PVector vectorA = new PVector(x, y, z);

            PVector returnedVector = PVector.Mult(vectorA,scalar);

            Assert.Equal(x, vectorA.X);
            Assert.Equal(y, vectorA.Y);
            Assert.Equal(z, vectorA.Z);

            Assert.Equal(x * scalar, returnedVector.X);
            Assert.Equal(y * scalar, returnedVector.Y);
            Assert.Equal(z * scalar, returnedVector.Z);
            
        }


        [Fact]
        public void ShouldAssignMultipliedVectorToTargetWhithoutChangingOriginalVectors()
        {

            float x = 1.2f;
            float y = 3.456f;
            float z = 7.8901f;
            float scalar = 3.58f;
            PVector vectorA = new PVector(x, y, z);

            PVector targetVector = new PVector();
            PVector returnedVector = PVector.Mult(vectorA, scalar, targetVector);

            Assert.Equal(returnedVector, targetVector);

            Assert.Equal(x, vectorA.X);
            Assert.Equal(y, vectorA.Y);
            Assert.Equal(z, vectorA.Z);

            Assert.Equal(x * scalar, targetVector.X);
            Assert.Equal(y * scalar, targetVector.Y);
            Assert.Equal(z * scalar, targetVector.Z);

        }

        [Fact]
        public void ShouldDivideAllComponentsByTheScalarAndReturnItself()
        {
            float x = 1.2f;
            float y = 3.456f;
            float z = 7.8901f;
            float scalar = 3.58f;
            PVector vectorA = new PVector(x, y, z);

            PVector returnedVector = vectorA.Div(scalar);

            Assert.Equal(returnedVector, vectorA);

            Assert.Equal(x / scalar, vectorA.X);
            Assert.Equal(y / scalar, vectorA.Y);
            Assert.Equal(z / scalar, vectorA.Z);
        }

        [Fact]
        public void ShouldReturnDividedVectorWhithoutChangingOriginalVector()
        {

            float x = 1.2f;
            float y = 3.456f;
            float z = 7.8901f;
            float scalar = 3.58f;
            PVector vectorA = new PVector(x, y, z);

            PVector returnedVector = PVector.Div(vectorA, scalar);

            Assert.Equal(x, vectorA.X);
            Assert.Equal(y, vectorA.Y);
            Assert.Equal(z, vectorA.Z);

            Assert.Equal(x / scalar, returnedVector.X);
            Assert.Equal(y / scalar, returnedVector.Y);
            Assert.Equal(z / scalar, returnedVector.Z);

        }


        [Fact]
        public void ShouldAssignDividedVectorToTargetWhithoutChangingOriginalVectors()
        {

            float x = 1.2f;
            float y = 3.456f;
            float z = 7.8901f;
            float scalar = 3.58f;
            PVector vectorA = new PVector(x, y, z);

            PVector targetVector = new PVector();
            PVector returnedVector = PVector.Div(vectorA, scalar, targetVector);

            Assert.Equal(returnedVector, targetVector);

            Assert.Equal(x, vectorA.X);
            Assert.Equal(y, vectorA.Y);
            Assert.Equal(z, vectorA.Z);

            Assert.Equal(x / scalar, targetVector.X);
            Assert.Equal(y / scalar, targetVector.Y);
            Assert.Equal(z / scalar, targetVector.Z);

        }

        [Fact]
        public void ShouldRotateVectorByThetaIn2dSpaceAndReturnItself()
        {
            float x = 5f;
            float y = 0;
            float z = 7.8901f;
            float theta = (float)Math.PI/2;
            PVector vectorA = new PVector(x, y, z);

            PVector returnedVector = vectorA.Rotate(theta);

            Assert.Equal(returnedVector, vectorA);

            double xDiff = Math.Abs(y - vectorA.X);
            double yDiff = Math.Abs(x - vectorA.Y);

            Assert.Equal(z, vectorA.Z);
            Assert.True(xDiff < ROUNDING_ERROR);
            Assert.True(yDiff < ROUNDING_ERROR);


            theta = (float)Math.PI / 4;

            vectorA = new PVector(x, y, z);
            returnedVector = vectorA.Rotate(theta);

            Assert.Equal(returnedVector, vectorA);

            double cos45DegreesMultByX = Math.Cos(theta) * x;
            xDiff = Math.Abs(cos45DegreesMultByX - vectorA.X);
            yDiff = Math.Abs(cos45DegreesMultByX - vectorA.Y);

            Assert.Equal(z, vectorA.Z);
            Assert.True(xDiff < ROUNDING_ERROR);
            Assert.True(yDiff < ROUNDING_ERROR);
        }

        [Fact]
        public void ShouldCalculateEuclideanDistanceBetweenVectors()
        {
            PVector a = new PVector(1, 0, 0);
            PVector b = new PVector(0, 1, 0);

            float distance = a.Dist(b);

            Assert.Equal((float)Math.Sqrt(2), distance);
        }


    }
}