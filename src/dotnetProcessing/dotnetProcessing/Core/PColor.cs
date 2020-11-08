using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetProcessing.Core
{
    public enum ColorMode
    {
        RGB,
        HSB
    }
    public class PColor
    {
        private static bool isRGB = true;        

        public static void SetColorMode(ColorMode mode)
        {
            isRGB = mode == ColorMode.RGB;
        }

        public static byte GetRed(uint rgbaColor)
        {
            return (byte)(rgbaColor >> 24);
        }

        public static byte GetGreen(uint rgbaColor)
        {
            return (byte)(rgbaColor >> 16);
        }

        public static byte GetBlue(uint rgbaColor)
        {
            return (byte)(rgbaColor >> 8);
        }

        public static byte GetAlpha(uint rgbaColor)
        {
            return (byte)(rgbaColor & 0xff);
        }
        

        private uint rgbaValue;

        private void validateSaturationAndValueRange(float saturation, float value)
        {
            if (saturation < 0 || saturation > 1)
            {
                throw new ArgumentException("Saturation value is out of bounds. Permitted values: [0,1]");
            }

            if (value < 0 || value > 1)
            {
                throw new ArgumentException("Brightness value is out of bounds. Permitted values: [0,1]");
            }
        }
        private void validateRGBRangeValues(float r, float g, float b)
        {
            if (r < 0 || r > 255)
                throw new ArgumentException("Red value is out of bounds. Permitted values: integers from 0 to 255");

            if (g < 0 || g > 255)
                throw new ArgumentException("Green value is out of bounds. Permitted values: integers from 0 to 255");

            if (b < 0 || b > 255)
                throw new ArgumentException("Blue value is out of bounds. Permitted values: integers from 0 to 255");
        }

        private uint rgbaToUInt(float red, float green, float blue, byte alpha)
        {
            validateRGBRangeValues(red, green, blue);
            byte r = (byte)red;
            byte g = (byte)green;
            byte b = (byte)blue;            

            uint result = (uint)((r << 24) | (g << 16) | (b << 8) | alpha);
            return result;
        }

        private uint hsvaToUInt(float hue, float saturation, float value, byte alpha)
        {
            validateSaturationAndValueRange(saturation, value);

            int hi = (int)(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value *= 255;
            byte v = (byte)value;
            byte p = (byte)(value * (1 - saturation));
            byte q = (byte)(value * (1 - f * saturation));
            byte t = (byte)(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return rgbaToUInt(v, t, p, alpha);
            else if (hi == 1)
                return rgbaToUInt(q, v, p, alpha);
            else if (hi == 2)
                return rgbaToUInt(p, v, t, alpha);
            else if (hi == 3)
                return rgbaToUInt(p, q, v, alpha);
            else if (hi == 4)
                return rgbaToUInt(t, p, v, alpha);
            else
                return rgbaToUInt(v, p, q, alpha);
            
        }


        





        public byte Red { get { return GetRed(rgbaValue); } }
        public byte Green { get { return GetGreen(rgbaValue); } }
        public byte Blue { get { return GetBlue(rgbaValue); } }
        public byte Alpha { get { return GetAlpha(rgbaValue); } }

        public uint RGBA { get { return rgbaValue; } }

        public PColor()
        {
            rgbaValue = 0x00000000;
        }


        public void SetColor(float v1, float v2, float v3, byte alpha)
        {
            if (isRGB)
            {   
                rgbaValue = rgbaToUInt(v1, v2, v3, alpha);
            }
            else 
            {
                rgbaValue = hsvaToUInt(v1, v2, v3, alpha);
            }
        }

        public void SetColor(float v1, float v2, float v3)
        {
            SetColor(v1, v2, v3, 255);
        }

        public void SetColor(float gray)
        {
            SetColor(gray, gray, gray, 255);
        }

        public void SetColor(float gray, byte alpha)
        {
            SetColor(gray, gray, gray, alpha);
        }

        public void SetColor(int rgb)
        {
            SetColor(rgb, 255);
            
        }

        public void SetColor(int rgb, byte alpha)
        {
            uint validRGB = (uint)(rgb & 0x00ffffff);
            rgbaValue = (validRGB | alpha);            
        }


    }
}
