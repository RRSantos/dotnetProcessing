﻿using dotnetProcessing.Helpers;
using SFML.Graphics;
using SFML.Window;
using System;

namespace dotnetProcessing
{
    public abstract partial class Sketch
    {
        
        
        private const int DEFAULT_WIDTH = 640;
        private const int DEFAULT_HEIGHT = 480;
        private const string DEFAULT_TITLE = "dotnet Processing";

        private readonly Transformation transformation;
        private Drawing drawing;

        private RenderWindow window;

        private Random internalRandom = new Random();

        private PerlinNoise perlin = new PerlinNoise();

        private string windowTitle;

        protected bool needsRefresh = false;
        
        
        protected uint width;
        protected uint height;


        private void Window_KeyReleased(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
            {
                window.Close();
            }
        }

        private void initializeInternalFields()
        {
            initializeWindow();
            drawing = new Drawing(window, transformation);
        }

        private void initializeWindow()
        {   
            if (window != null)
            {
                window.Dispose();
            }

            VideoMode video = new VideoMode(width, height);
            ContextSettings settings = new ContextSettings();
            settings.AntialiasingLevel = 0;
            window = new RenderWindow(video, windowTitle, Styles.Default, settings);
            
            window.SetFramerateLimit(60);
            window.Closed += (_, __) => window.Close();
            window.KeyReleased += Window_KeyReleased;
        }        
        
        protected void size(uint width, uint height)
        {
            this.width = width;
            this.height = height;
            initializeInternalFields();
        }

        protected void title(string newTitle)
        {
            windowTitle = newTitle;
            window.SetTitle(windowTitle);
        }
        
        protected void colorMode(ColorMode colorMode)
        {
            ColorHelper.SetColorMode(colorMode);
        }

        protected float radians(float degrees)
        {
            return ConvertionHelper.DegreesToRadians(degrees);
        }

        protected float degrees(float radians)
        {
            return ConvertionHelper.RadiansToDegrees(radians);
        }

        protected void frameRate(int frameRate)
        {
            window.SetFramerateLimit((uint)frameRate);
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


        public Sketch()
        {
            width = DEFAULT_WIDTH;
            height = DEFAULT_HEIGHT;
            transformation = new Transformation();
            initializeInternalFields();
            windowTitle = DEFAULT_TITLE;
        }

        public void Run()
        {
            Setup();
            
            while (window.IsOpen)
            {
                window.DispatchEvents();
                Draw();
                
                if (needsRefresh)
                {   
                    window.Display();
                    needsRefresh = false;
                }
            }
            
        }

        public abstract void Setup();
        public abstract void Draw();
    }
}
