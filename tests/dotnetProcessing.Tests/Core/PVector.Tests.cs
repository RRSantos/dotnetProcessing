using System;
using Xunit;
using dotnetProcessing.Core;


namespace dotnetProcessing.Tests.Core
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

        [Fact]
        public void ShouldNormalizeVector()
        {
            PVector aVector = new PVector(3, 4, 5);
            float originalMagnitude = aVector.Mag();

            PVector normalizedVector = aVector.Normalize();

            Assert.Same(normalizedVector, aVector);
            Assert.NotEqual(originalMagnitude, aVector.Mag());
            Assert.Equal(1f, aVector.Mag());

        }

        [Fact]
        public void ShouldReturnNormalizedVectorWithoutChangingActrualVector()
        {
            PVector vectorA = new PVector(3, 4, 5);
            PVector vectorACopy = vectorA.Copy();
            float originalMagnitude = vectorA.Mag();
            PVector targetVector = new PVector(5, 5, 5);

            PVector normalizedVector = vectorA.Normalize(targetVector);

            //Vector A should not change
            Assert.Equal(originalMagnitude, vectorA.Mag());
            Assert.Equal(vectorACopy.X, vectorA.X);
            Assert.Equal(vectorACopy.Y, vectorA.Y);
            Assert.Equal(vectorACopy.Z, vectorA.Z);

            Assert.Same(normalizedVector, targetVector);            
            Assert.NotEqual(1f, targetVector.Mag());
        }

        [Fact]
        public void ShouldChangeMagnitudeIfActualMagnitudeIsGreaterThanMaxValue()
        {
            PVector vectorA = new PVector(1, 2, 2); // Magnitude 3
            float originalMagnitude = vectorA.Mag();
            float maxMagnitude = 2f;
            PVector limitedVector = vectorA.Limit(maxMagnitude);
            float newMagnitude = limitedVector.Mag();

            Assert.Same(vectorA, limitedVector);
            Assert.Equal(3f, originalMagnitude);
            Assert.NotEqual(newMagnitude, originalMagnitude);
            Assert.Equal(maxMagnitude, newMagnitude);
        }

        [Fact]
        public void ShouldNotChangeMagnitudeIfActualMagnitudeIsLowerThanMaxValue()
        {
            PVector vectorA = new PVector(1, 2, 2); // Magnitude 3
            float originalMagnitude = vectorA.Mag();
            float maxMagnitude = 5f;
            PVector limitedVector = vectorA.Limit(maxMagnitude);
            float newMagnitude = limitedVector.Mag();

            Assert.Same(vectorA, limitedVector);
            Assert.Equal(3f, originalMagnitude);
            Assert.Equal(originalMagnitude, newMagnitude);
        }

        [Fact]
        public void ShouldSetMagnitude()
        {
            PVector vectorA = new PVector(1, 2, 2); // Magnitude 3
            float originalMagnitude = vectorA.Mag();
            float desiredNewMagnitude = 5f;
            PVector limitedVector = vectorA.SetMag(desiredNewMagnitude);
            float newMagnitude = limitedVector.Mag();

            Assert.Same(vectorA, limitedVector);
            Assert.Equal(3f, originalMagnitude);
            Assert.NotEqual(originalMagnitude, newMagnitude);
            double roundingError = Math.Abs(desiredNewMagnitude - newMagnitude);
            Assert.True(roundingError < ROUNDING_ERROR);
        }

        [Fact]
        public void ShouldThowExceptionIfNewMagnitudeIsZeroOrLower()
        {
            PVector vectorA = new PVector(1, 2, 2); // Magnitude 3
            float originalMagnitude = vectorA.Mag();

            Assert.Throws<ArgumentException>(
                "length",
                () => { PVector limitedVector = vectorA.SetMag(-0.001f); }
            );


            Assert.Throws<ArgumentException>(
                "length", 
                () => { PVector limitedVector = vectorA.SetMag(0f); }
            );

        }

        [Fact]
        public void ShouldSetMagnitudeOfTargetVectorWithoutChangingActualVector()
        {
            PVector vectorA = new PVector(1, 2, 2); 
            float originalVectorAMagnitude = vectorA.Mag(); // Magnitude 3
            PVector vectorACopy = vectorA.Copy();

            PVector targetVector = new PVector(3, 4, 0); 
            float originalTargetVectorMagnitude = targetVector.Mag(); // Magnitude 5

            float desiredNewMagnitude = 8f;

            PVector resultVector = vectorA.SetMag(targetVector, desiredNewMagnitude);
            float resultMagnitude = resultVector.Mag();

            //Vector A should not change
            Assert.Equal(originalVectorAMagnitude, vectorA.Mag());
            Assert.Equal(vectorACopy.X, vectorA.X);
            Assert.Equal(vectorACopy.Y, vectorA.Y);
            Assert.Equal(vectorACopy.Z, vectorA.Z);


            Assert.Same(targetVector, resultVector);            
            Assert.NotEqual(originalTargetVectorMagnitude, resultMagnitude);
            Assert.Equal(desiredNewMagnitude, resultMagnitude);
        }

        [Fact]
        public void ShouldReturnActualAngleOfVectorOnXYPlane()
        {
            PVector vectorA = new PVector(1, 1, 2);
            float theta = vectorA.Heading(); // PI/4
            float expectedTheta = (float)Math.PI / 4;
            Assert.Equal(expectedTheta, theta);

            vectorA.Set(1,0);
            theta = vectorA.Heading(); // 0
            expectedTheta = 0f;
            Assert.Equal(expectedTheta, theta);

            vectorA.Set(0, 1);
            theta = vectorA.Heading(); // PI/2
            expectedTheta = (float)Math.PI / 2;
            Assert.Equal(expectedTheta, theta);
        }


        [Fact]
        public void ShouldReturnAngleBetweenVectorsOnXYPlane()
        {
            PVector vectorA = new PVector(1, 0);
            PVector vectorB = new PVector(0, 1);

            float expectedTheta = (float)Math.PI / 2;
            float actualTheta = vectorA.AngleBetween(vectorB);
            Assert.Equal(expectedTheta, actualTheta);


            vectorA = new PVector(2, 7);
            vectorB = new PVector(1, -4);

            float expectedThetaInDegrees = 150.01836f;
            float actualThetaInDegrees = Helpers.ConvertionHelper.RadiansToDegrees(vectorA.AngleBetween(vectorB));
            Assert.Equal(expectedThetaInDegrees, actualThetaInDegrees);
        }

        [Fact]
        public void ShouldReturnZeroIfOneVectorHasAllComponentsEqualsZero()
        {
            PVector vectorA = new PVector(0, 0, 0);
            PVector vectorB = new PVector(1, 1, 1);
            float expectedTheta = 0f;

            float actualTheta = vectorA.AngleBetween(vectorB);
            
            
            Assert.Equal(expectedTheta, actualTheta);
            actualTheta = vectorB.AngleBetween(vectorA);
            Assert.Equal(expectedTheta, actualTheta);
        }

        [Fact]
        public void ShouldReturnArrayOfActualVectorsComponents()
        {
            PVector vectorA = new PVector(1.1f, 2.2f, 3.3f);
            float[] expectedResult = new float[3] { 1.1f, 2.2f, 3.3f };
            float[] actualResult = vectorA.Array();

            Assert.Equal(expectedResult, actualResult);
        }


        [Fact]
        public void ShouldCreateUnitVectorFromGivenAngle()
        {
            float angle = (float)Math.PI / 2;
            PVector vectorA = PVector.FromAngle(angle);
            float calculatedAngle = vectorA.Heading();
            float calculatedMagnitude = vectorA.Mag();

            Assert.Equal(angle, calculatedAngle);
            float diff = (float)Math.Abs(1f - calculatedMagnitude);
            Assert.True(diff < ROUNDING_ERROR);



            angle = (float)Math.PI / 4;
            vectorA = PVector.FromAngle(angle);
            calculatedAngle = vectorA.Heading();
            calculatedMagnitude = vectorA.Mag();

            Assert.Equal(angle, calculatedAngle);
            diff = (float)Math.Abs(1f - calculatedMagnitude);
            Assert.True(diff < ROUNDING_ERROR);

        }

        [Fact]
        public void ShouldCreateARandom2DUnitVector()
        {   
            PVector vectorA = PVector.Random2D();
            Assert.NotNull(vectorA);
        }

        [Fact]
        public void ShouldCreateARandom2DUnitVectorAndSetTarget()
        {
            PVector target = new PVector();
            PVector vectorA = PVector.Random2D(target);

            Assert.Same(target, vectorA);
            Assert.NotNull(vectorA);
        }

        [Fact]
        public void ShouldCreateASameRandom2DUnitVectorFromGivenRandomObject()
        {
            Random random = new Random(1);
            PVector vectorA = PVector.Random2D(random);
            float angle = vectorA.Heading();
            float expectedAngle = 1.56243074f;


            Assert.NotNull(vectorA);
            Assert.Equal(expectedAngle, angle);



            random = new Random(1000);
            vectorA = PVector.Random2D(random);
            angle = vectorA.Heading();
            expectedAngle = 0.9522636f;


            Assert.NotNull(vectorA);
            Assert.Equal(expectedAngle, angle);

        }

        [Fact]
        public void ShouldCreateASameRandom2DUnitVectorFromGivenRandomObjectAndSetTarget()
        {
            Random random = new Random(1);
            PVector target = new PVector();
            PVector vectorA = PVector.Random2D(target, random);
            float angle = vectorA.Heading();
            float expectedAngle = 1.56243074f;

            Assert.Same(target, vectorA);
            Assert.NotNull(vectorA);
            Assert.Equal(expectedAngle, angle);
        }


        [Fact]
        public void ShouldLinearInterpoleFromGivenVectorAndAmmout()
        {
            PVector vectorA = new PVector(1, 2, 3);
            PVector vectorB = new PVector(5, 6, 7);
            float ammount = 0.5f;
            PVector resultVector = vectorA.Lerp(vectorB, ammount);

            Assert.Same(resultVector, vectorA);
            Assert.NotNull(resultVector);

            Assert.Equal(3f, resultVector.X);
            Assert.Equal(4f, resultVector.Y);
            Assert.Equal(5f, resultVector.Z);


            vectorA = new PVector(1, 2, 3);
            vectorB = new PVector(4, 5, 6);
            ammount = 1f/3f;
            resultVector = vectorA.Lerp(vectorB, ammount);

            Assert.NotNull(resultVector);
            Assert.Same(resultVector, vectorA);

            Assert.Equal(2f, resultVector.X);
            Assert.Equal(3f, resultVector.Y);
            Assert.Equal(4f, resultVector.Z);
        }

        [Fact]
        public void ShouldLinearInterpoleFromXYZAndAmmountParams()
        {
            PVector vectorA = new PVector(1, 2, 3);
            
            float ammount = 0.5f;
            PVector resultVector = vectorA.Lerp(5, 6, 7, ammount);

            Assert.Same(resultVector, vectorA);
            Assert.NotNull(resultVector);

            Assert.Equal(3f, resultVector.X);
            Assert.Equal(4f, resultVector.Y);
            Assert.Equal(5f, resultVector.Z);


            vectorA = new PVector(1, 2, 3);
            ammount = 1f / 3f;
            resultVector = vectorA.Lerp(4, 5, 6, ammount);

            Assert.NotNull(resultVector);
            Assert.Same(resultVector, vectorA);

            Assert.Equal(2f, resultVector.X);
            Assert.Equal(3f, resultVector.Y);
            Assert.Equal(4f, resultVector.Z);
        }

        [Fact]
        public void ShouldStaticallyLinearInterpoleTwoVectorsByGivenAmmountAndDontChangeOriginalVectors()
        {
            PVector vectorA = new PVector(1, 2, 3);
            PVector vectorACopy = vectorA.Copy();


            PVector vectorB = new PVector(5, 6, 7);
            PVector vectorBCopy = vectorB.Copy();

            float ammount = 0.5f;
            PVector resultVector = PVector.Lerp(vectorA, vectorB, ammount);

            // vectorA should not be changed
            Assert.Equal(vectorACopy.X, vectorA.X);
            Assert.Equal(vectorACopy.Y, vectorA.Y);
            Assert.Equal(vectorACopy.Z, vectorA.Z);

            // vectorB should not be changed
            Assert.Equal(vectorBCopy.X, vectorB.X);
            Assert.Equal(vectorBCopy.Y, vectorB.Y);
            Assert.Equal(vectorBCopy.Z, vectorB.Z);


            Assert.NotNull(resultVector);

            Assert.Equal(3f, resultVector.X);
            Assert.Equal(4f, resultVector.Y);
            Assert.Equal(5f, resultVector.Z);
            
        }

        [Fact]
        public void ShouldCreateARandom3DUnitVector()
        {
            PVector vectorA = PVector.Random3D();
            Assert.NotNull(vectorA);
        }

        [Fact]
        public void ShouldCreateARandom3DUnitVectorAndSetTarget()
        {
            PVector target = new PVector();
            PVector vectorA = PVector.Random3D(target);

            Assert.Same(target, vectorA);
            Assert.NotNull(vectorA);
        }

        [Fact]
        public void ShouldCreateASameRandom3DUnitVectorFromGivenRandomObject()
        {
            Random random = new Random(1);
            PVector vectorA = PVector.Random3D(random);
            float expectedX = -0.5410597f;
            float expectedY = -0.83798015f;
            float expectedZ = -0.07101854f;

            Assert.NotNull(vectorA);
            Assert.Equal(expectedX, vectorA.X);
            Assert.Equal(expectedY, vectorA.Y);
            Assert.Equal(expectedZ, vectorA.Z);

            //Another Seed
            random = new Random(1234567);
            vectorA = PVector.Random3D(random);
            expectedX = 0.6300232f;
            expectedY = 0.5864165f;
            expectedZ = -0.5091036f;

            Assert.NotNull(vectorA);
            Assert.Equal(expectedX, vectorA.X);
            Assert.Equal(expectedY, vectorA.Y);
            Assert.Equal(expectedZ, vectorA.Z);

        }

        [Fact]
        public void ShouldCreateASameRandom3DUnitVectorFromGivenRandomObjectAndSetTarget()
        {
            Random random = new Random(1);
            PVector target = new PVector();
            PVector vectorA = PVector.Random3D(target, random);
            float expectedX = -0.5410597f;
            float expectedY = -0.83798015f;
            float expectedZ = -0.07101854f;

            Assert.NotNull(vectorA);
            Assert.Same(target, vectorA);
            Assert.Equal(expectedX, vectorA.X);
            Assert.Equal(expectedY, vectorA.Y);
            Assert.Equal(expectedZ, vectorA.Z);
        }


    }
}
