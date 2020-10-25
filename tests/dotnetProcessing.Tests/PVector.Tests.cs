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

        [Fact]
        public void ShouldSetComponentsFromTwoFloatParamsAndReturnVector()
        {
            PVector originalVector = new PVector(1, 2, 3);

            PVector resultVector = originalVector.Set(4, 5);

            Assert.Equal(originalVector, resultVector);

            Assert.Equal(4, originalVector.X);
            Assert.Equal(5, originalVector.Y);
            Assert.Equal(3, originalVector.Z);
        }

        [Fact]
        public void ShouldSetComponentsFromThreeFloatParamsAndReturnVector()
        {
            PVector originalVector = new PVector(1, 2, 3);

            PVector resultVector = originalVector.Set(4, 5, 6);

            Assert.Equal(originalVector, resultVector);

            Assert.Equal(4, originalVector.X);
            Assert.Equal(5, originalVector.Y);
            Assert.Equal(6, originalVector.Z);
        }

        [Fact]
        public void ShouldSetComponentsFromAnotherVectorParamAndReturnVector()
        {
            PVector originalVector = new PVector(1, 2, 3);
            PVector paramVector = new PVector(4, 5, 6);

            PVector resultVector = originalVector.Set(paramVector);

            Assert.Equal(originalVector, resultVector);

            Assert.Equal(4, originalVector.X);
            Assert.Equal(5, originalVector.Y);
            Assert.Equal(6, originalVector.Z);
        }

        [Fact]
        public void ShouldSetComponentsFromIListParamOfSize1To3AndReturnVector()
        {
            PVector originalVector = new PVector(1, 2, 3);
            float[] source1 = { 4f };

            PVector resultVector = originalVector.Set(source1);

            Assert.Equal(originalVector, resultVector);

            Assert.Equal(4, originalVector.X);
            Assert.Equal(2, originalVector.Y);
            Assert.Equal(3, originalVector.Z);


            float[] source2 = { 4f,5f };

            resultVector = originalVector.Set(source2);

            Assert.Equal(originalVector, resultVector);

            Assert.Equal(4, originalVector.X);
            Assert.Equal(5, originalVector.Y);
            Assert.Equal(3, originalVector.Z);

            float[] source3 = { 4f, 5f, 6f };

            resultVector = originalVector.Set(source3);

            Assert.Equal(originalVector, resultVector);

            Assert.Equal(4, originalVector.X);
            Assert.Equal(5, originalVector.Y);
            Assert.Equal(6, originalVector.Z);
        }

        [Fact]
        public void ShouldThrowExceptionIfIListSizeWereZeroOrHigherThenThree()
        {
            PVector originalVector = new PVector(1, 2, 3);
            float[] source1 = { };

            Assert.Throws<ArgumentException>(
                "source", 
                () => { PVector resultVector = originalVector.Set(source1); }
            );

            float[] source4 = {1,2,3,4 };

            Assert.Throws<ArgumentException>(
                "source",
                () => { PVector resultVector = originalVector.Set(source4); }
            );
        }

        [Fact]
        public void ShouldCalculateMagnitudeOfVector()
        {
            PVector originalVector = new PVector(3, 4, 0);
            float magnitude = originalVector.Mag();

            Assert.Equal(5f, magnitude);


            originalVector = new PVector(1, 2, 2);
            magnitude = originalVector.Mag();

            Assert.Equal(3, magnitude);

        }

        [Fact]
        public void ShouldCalculateMagnitudeSquaredOfVector()
        {
            PVector originalVector = new PVector(3, 4, 0);
            float magnitudeSquared = originalVector.MagSq();

            Assert.Equal(25f, magnitudeSquared);


            originalVector = new PVector(1, 2, 2);
            magnitudeSquared = originalVector.MagSq();

            Assert.Equal(9, magnitudeSquared);

        }

        [Fact]
        public void ShouldCalculateDotProductWithAnotherVector()
        {
            PVector originalVector = new PVector(3, 4, 5);

            PVector anotherVector = new PVector(1, 2, 3);

            float dotProduct = originalVector.Dot(anotherVector);

            Assert.Equal(26f, dotProduct);
        }

        [Fact]
        public void ShouldCalculateDotProductWithXYZValues()
        {
            PVector originalVector = new PVector(3, 4, 5);

            float dotProduct = originalVector.Dot(1, 2, 3);

            Assert.Equal(26f, dotProduct);
        }

        [Fact]
        public void ShouldCalculateDotProductOfTwoVectors()
        {
            PVector aVector = new PVector(3, 4, 5);
            PVector copyOfA = aVector.Copy();

            PVector bVector = new PVector(1, 2, 3);
            PVector copyOfB = bVector.Copy();

            float dotProduct = PVector.Dot(aVector,bVector);
            Assert.Equal(26f, dotProduct);


            Assert.Equal(copyOfA.X, aVector.X);
            Assert.Equal(copyOfA.Y, aVector.Y);
            Assert.Equal(copyOfA.Z, aVector.Z);

            Assert.Equal(copyOfB.X, bVector.X);
            Assert.Equal(copyOfB.Y, bVector.Y);
            Assert.Equal(copyOfB.Z, bVector.Z);
        }


        [Fact]
        public void ShouldCalculateCrossProductOfTwoVectors()
        {
            PVector aVector = new PVector(3, 4, 5);
            PVector bVector = new PVector(1, 2, 3);
            PVector expectedResult = new PVector(2, -4, 2);

            PVector crossProductVector = aVector.Cross(bVector);

            Assert.Equal(expectedResult.X, crossProductVector.X);
            Assert.Equal(expectedResult.Y, crossProductVector.Y);
            Assert.Equal(expectedResult.Z, crossProductVector.Z);
        }

        [Fact]
        public void ShouldCalculateCrossProductOfTwoVectorsAndSetTargetVector()
        {
            PVector aVector = new PVector(3, 4, 5);
            PVector bVector = new PVector(1, 2, 3);
            PVector targetVector = new PVector(6, 7, 8);
            PVector expectedResult = new PVector(2, -4, 2);

            PVector crossProductVector = aVector.Cross(bVector, targetVector);
            Assert.NotSame(targetVector, expectedResult);

            Assert.Equal(expectedResult.X, targetVector.X);
            Assert.Equal(expectedResult.Y, targetVector.Y);
            Assert.Equal(expectedResult.Z, targetVector.Z);

            Assert.Equal(expectedResult.X, crossProductVector.X);
            Assert.Equal(expectedResult.Y, crossProductVector.Y);
            Assert.Equal(expectedResult.Z, crossProductVector.Z);
        }

        [Fact]
        public void ShouldStaticallyCalculateCrossProductOfTwoVectorsAndSetTargetVector()
        {
            PVector aVector = new PVector(3, 4, 5);
            PVector bVector = new PVector(1, 2, 3);
            PVector targetVector = new PVector(6, 7, 8);
            PVector expectedResult = new PVector(2, -4, 2);

            PVector crossProductVector = PVector.Cross(aVector, bVector, targetVector);
            Assert.NotSame(targetVector, expectedResult);

            Assert.Equal(expectedResult.X, targetVector.X);
            Assert.Equal(expectedResult.Y, targetVector.Y);
            Assert.Equal(expectedResult.Z, targetVector.Z);

            Assert.Equal(expectedResult.X, crossProductVector.X);
            Assert.Equal(expectedResult.Y, crossProductVector.Y);
            Assert.Equal(expectedResult.Z, crossProductVector.Z);
        }


    }
}
