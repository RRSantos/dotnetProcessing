using System;

namespace dotnetProcessing.Helpers
{
    public static class ConvertionHelper
    {
        public static float DegreesToRadians(float degrees)
        {
            return (float)(degrees * (Math.PI / 180f));
        }

        public static float RadiansToDegrees(float radians)
        {
            return (float)(radians * (180f / Math.PI));
        }
    }
}
