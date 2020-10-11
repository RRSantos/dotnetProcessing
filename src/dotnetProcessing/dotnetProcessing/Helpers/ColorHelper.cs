using SFML.Graphics;
using System;

namespace dotnetProcessing.Helpers
{
    public enum ColorMode
    {
        RGB,
        HSB
    }
    static class ColorHelper
    {

        private static bool isRGB = true;

        public static void SetColorMode(ColorMode mode)
        {
            isRGB = mode == ColorMode.RGB;
        }
        public static Color NewColor(float v1, float v2, float v3, byte alpha)
        {
            if (isRGB)
            {
                validateRGBRangeValues(v1, v2, v3);
                byte red = Convert.ToByte(v1);
                byte green = Convert.ToByte(v2);
                byte blue = Convert.ToByte(v3);                
                return new Color(red, green, blue, alpha);
            }
            else
            {
                return HSV(v1, v2, v3, alpha);
            }
            
        }

        public static Color NewColor(float v1, float v2, float v3)
        {
            return NewColor(v1, v2, v3, 255);            
        }

        public static Color NewColor(float gray)
        {
            return NewColor(gray, gray, gray, 255);
        }

        public static Color NewColor(float gray, byte alpha)
        {
            return NewColor(gray, gray, gray, alpha);
        }

        private static void validateRGBRangeValues(float r, float g, float b)
        {
            if (r < 0 || r > 255)
                throw new ArgumentException("Red value is out of bounds. Permitted values: integers from 0 to 255");

            if (g < 0 || g > 255)
                throw new ArgumentException("Green value is out of bounds. Permitted values: integers from 0 to 255");

            if (b < 0 || b > 255)
                throw new ArgumentException("Blue value is out of bounds. Permitted values: integers from 0 to 255");
        }

        private static Color HSV(double hue, double saturation, double value, byte alpha)
        {
            if (saturation <0 || saturation >1)
            {
                throw new ArgumentException("Saturation value is out of bounds. Permitted values: [0,1]");
            }

            if (value < 0 || value > 1)
            {
                throw new ArgumentException("Brightness value is out of bounds. Permitted values: [0,1]");
            }
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value *= 255;
            byte v = Convert.ToByte(value);
            byte p = Convert.ToByte(value * (1 - saturation));
            byte q = Convert.ToByte(value * (1 - f * saturation));
            byte t = Convert.ToByte(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return new Color(v, t, p, alpha);
            else if (hi == 1)
                return new Color(q, v, p, alpha);
            else if (hi == 2)
                return new Color(p, v, t, alpha);
            else if (hi == 3)
                return new Color(p, q, v, alpha);
            else if (hi == 4)
                return new Color(t, p, v, alpha);
            else
                return new Color(v, p, q, alpha);
        }
    }
}
