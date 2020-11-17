using dotnetProcessing.Helpers;
using dotnetProcessing.SFML;
using System;
using System.Collections.Generic;

namespace dotnetProcessing.Core
{
    public abstract partial class Sketch
    {
        

        private readonly PGraphicsBuffer graphicsBuffer;

        private string internalTitle = string.Empty;
        private float internalFrameRate = 0;
        private PGraphics graphics;
        
        private IPSurface surface;

        private readonly Random internalRandom = new Random();

        private PerlinNoise perlin = new PerlinNoise();

        private bool isNoLoop = false;


        protected int width = IPSurface.MIN_WINDOW_WIDTH;
        protected int height = IPSurface.MIN_WINDOW_WIDTH;

        protected const byte P2D = PConstants.P2D;
        protected const byte P3D = PConstants.P3D;

        protected byte render = PConstants.P2D;

        protected PGraphics createGraphics(int graphicsWidth, int graphicsHeight, byte graphicsRender)
        {   
            if (graphicsRender == P2D)
            {
                return new PGraphicsSFML(graphicsWidth, graphicsHeight);
            }
            throw new NotImplementedException("Render not implemented");
        }

        protected PGraphics createGraphics(int graphicsWidth, int graphicsHeight)
        {
            return createGraphics(graphicsWidth, graphicsHeight, render);
        }


        protected void size(int width, int height)
        {
            this.width = width;
            this.height = height;
            if (surface != null)
            {
                surface.SetSize(width, height);
            }
            
        }

        protected void size(int width, int height, byte render)
        {
            this.render = render;
            size(width, height);
        }

        protected void title(string newTitle)
        {
            internalTitle = newTitle;
            if (surface != null)
            {
                surface.SetTitle(internalTitle);
            }
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
            internalFrameRate = frameRate;
            if (surface != null)
            {
                surface.SetFrameRate(internalFrameRate);
            }
                
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
            if (surface != null)
            {
                surface.RefreshNeeded();
            }
            
        }

        private void prepareFinalGraphicsAndSurface()
        {
            graphics = createGraphics(width, height);
            surface = graphics.GetSurface();
            surface.InitFrame(this);
            if (!string.IsNullOrEmpty(internalTitle))
            {
                surface.SetTitle(internalTitle);
            }

            if (internalFrameRate > 0)
            {
                surface.SetFrameRate(internalFrameRate);
            }


            foreach (Action<PGraphics> pendingAction in graphicsBuffer.PendingActions)
            {
                pendingAction(graphics);
            }
        }


        public Sketch()
        {
            graphicsBuffer = new PGraphicsBuffer();
            graphics = graphicsBuffer;
            colorMode(ColorMode.RGB);

        }

        public void Run()
        {   
            Setup();

            prepareFinalGraphicsAndSurface();

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
