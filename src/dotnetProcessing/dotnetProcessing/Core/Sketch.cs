using dotnetProcessing.Helpers;
using dotnetProcessing.SFML;
using System;

namespace dotnetProcessing.Core
{
    public abstract partial class Sketch
    {   

        private readonly PGraphics graphics;
        private readonly IPSurface surface;

        private readonly Random internalRandom = new Random();

        private PerlinNoise perlin = new PerlinNoise();

        private bool isNoLoop = false;


        protected int width = IPSurface.MIN_WINDOW_WIDTH;
        protected int height = IPSurface.MIN_WINDOW_WIDTH;
        

        protected void size(int width, int height)
        {
            this.width = width;
            this.height = height;
            surface.SetSize(width, height);
        }

        protected void title(string newTitle)
        {
            surface.SetTitle(newTitle);            
        }
        
        protected void colorMode(ColorMode colorMode)
        {
            PColor.SetColorMode(colorMode);
        }

        protected float radians(float degrees)
        {
            return ConvertionHelper.DegreesToRadians(degrees);
        }

        protected float degrees(float radians)
        {
            return ConvertionHelper.RadiansToDegrees(radians);
        }

        protected void frameRate(float frameRate)
        {
            surface.SetFrameRate(frameRate);
        }

        protected float noise(double x)
        {
            return (float)perlin.GetNoiseAt(x);
        }

        protected void noiseDetail(int octaves)
        {
            int samples = perlin.GetSamples();
            int seed = perlin.GetSeed();
            double falloffFactor = perlin.GetFalloffFactor();
            perlin = new PerlinNoise(samples, octaves, seed, falloffFactor);
            
        }

        protected void noiseDetail(int octaves, float falloffFactor)
        {
            int samples = perlin.GetSamples();
            int seed = perlin.GetSeed();            
            perlin = new PerlinNoise(samples, octaves, seed, falloffFactor);
        }

        protected float random(float upperLimit)
        {
            return (float)internalRandom.NextDouble() * upperLimit;
        }

        protected float random(float lowerLimit, float upperLimit)
        {
            return (float)internalRandom.NextDouble() * (upperLimit - lowerLimit) + lowerLimit;
        }

        protected void noLoop()
        {
            isNoLoop = true;
        }

        protected void loop()
        {
            isNoLoop = false;
        }

        protected void redraw()
        {
            surface.RefreshNeeded();            
        }


        public Sketch()
        {
            graphics = new PGraphicsSFML();
            surface = graphics.GetSurface();
            surface.InitFrame(this);
            
        }

        public void Run()
        {
            surface.StartThread();
        }

        public void HandleDraw()
        {   
            if (!isNoLoop)
            {
                graphics.BeginDraw();
                Draw();                
                graphics.EndDraw();
            }

            dequeueEvents();
        }

        public abstract void Setup();
        public abstract void Draw();
    }
}
