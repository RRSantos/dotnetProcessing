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
        

        private void validateRGBRangeValues(float r, float g, float b)
        {
            if (r < 0 || r > 255)
                throw new ArgumentException("Red value is out of bounds. Permitted values: integers from 0 to 255");

            if (g < 0 || g > 255)
                throw new ArgumentException("Green value is out of bounds. Permitted values: integers from 0 to 255");

            if (b < 0 || b > 255)
                throw new ArgumentException("Blue value is out of bounds. Permitted values: integers from 0 to 255");
        }

        private uint rgbaToUInt(byte red, byte green, byte blue, byte alpha)
        {
            uint result = (uint)((red << 24) | (green << 16) | (blue << 8) | alpha);
            return result;
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
                validateRGBRangeValues(v1, v2, v3);
                byte r = Convert.ToByte(v1);
                byte g = Convert.ToByte(v2);
                byte b = Convert.ToByte(v3);
                rgbaValue = rgbaToUInt(r, g, b, alpha);
            }
            else 
            {
                throw new NotImplementedException("HSV color mode not implemented");
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
