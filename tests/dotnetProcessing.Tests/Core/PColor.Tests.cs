using dotnetProcessing.Core;
using System;
using Xunit;

namespace dotnetProcessing.Tests.Core
{
    public class PColorTests
    {
        [Fact]
        public void InitialValueShouldBeBlack()
        {
            PColor color = new PColor();


            Assert.Equal<uint>(0, color.RGBA);

        }

        [Fact]
        public void ShouldSetOnlyRedChannelToMax()
        {
            PColor color = new PColor();
            byte red = 255;
            byte green = 0;
            byte blue = 0;
            byte alpha = 0;
            color.SetColor(red, green, blue, alpha);


            Assert.Equal(red, color.Red);
            Assert.Equal(green, color.Green);
            Assert.Equal(blue, color.Blue);
            Assert.Equal(alpha, color.Alpha);

        }

        [Fact]
        public void ShouldSetOnlyGreenChannelToMax()
        {
            PColor color = new PColor();
            byte red = 0;
            byte green = 255;
            byte blue = 0;
            byte alpha = 0;
            color.SetColor(red, green, blue, alpha);


            Assert.Equal(red, color.Red);
            Assert.Equal(green, color.Green);
            Assert.Equal(blue, color.Blue);
            Assert.Equal(alpha, color.Alpha);

        }

        [Fact]
        public void ShouldSetOnlyBlueChannelToMax()
        {
            PColor color = new PColor();
            byte red = 0;
            byte green = 0;
            byte blue = 255;
            byte alpha = 0;
            color.SetColor(red, green, blue, alpha);


            Assert.Equal(red, color.Red);
            Assert.Equal(green, color.Green);
            Assert.Equal(blue, color.Blue);
            Assert.Equal(alpha, color.Alpha);

        }

        [Fact]
        public void ShouldSetOnlyAlphaChannelToMax()
        {
            PColor color = new PColor();
            byte red = 0;
            byte green = 0;
            byte blue = 0;
            byte alpha = 255;
            color.SetColor(red, green, blue, alpha);


            Assert.Equal(red, color.Red);
            Assert.Equal(green, color.Green);
            Assert.Equal(blue, color.Blue);
            Assert.Equal(alpha, color.Alpha);

        }

        [Fact]
        public void ShouldRespectDefinedColorsAndAlpha()
        {
            Random random = new Random();
            PColor color = new PColor();
            byte red = (byte)random.Next(256);
            byte green = (byte)random.Next(256); 
            byte blue = (byte)random.Next(256); 
            byte alpha = (byte)random.Next(256); 

            color.SetColor(red, green, blue, alpha);


            Assert.Equal(red, color.Red);
            Assert.Equal(green, color.Green);
            Assert.Equal(blue, color.Blue);
            Assert.Equal(alpha, color.Alpha);

        }
    }
}
