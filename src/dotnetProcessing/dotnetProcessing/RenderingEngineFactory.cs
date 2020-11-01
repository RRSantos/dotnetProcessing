using dotnetProcessing.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetProcessing
{
    static class RenderingEngineFactory
    {
        public static IDrawable CreateDrawable(int width, int height)
        {
            return new Engines.Graphic.SFML.SFMLDrawable(width, height);
        }
    }
}
