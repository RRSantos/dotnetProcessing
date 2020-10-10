using dotnetProcessing.Helpers;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace dotnetProcessing
{
    public abstract class Sketch
    {
        private const int DEFAULT_WIDTH = 100;
        private const int DEFAULT_HEIGHT = 100;
        private readonly Color DEFAULT_BACKGROUND_COLOR = Color.Black;
        private readonly Color DEFAULT_FILL_COLOR = Color.White;
        private const float DEFAULT_STROKE_WEIGHT = 1f;

        private float x;
        private float y;
        private float z;


        protected RenderWindow window;
        protected Color backgroundColor;
        protected Color fillColor;
        protected uint width;
        protected uint height;
        protected float strokeWeight;

        protected float radians(float degrees)
        {
            return (float)(degrees * (Math.PI / 180f));
        }

        protected float degrees(float radians)
        {
            return (float)(radians * (180f/ Math.PI));
        }


        private void Window_KeyReleased(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
            {
                window.Close();
            }
        }

        private void initializeWindow()
        {
            VideoMode video = new VideoMode(width, height);
            window = new RenderWindow(video, "dotnetProcessing");
            window.SetFramerateLimit(60);
            window.Closed += (_, __) => window.Close();
            window.KeyReleased += Window_KeyReleased;

            window.Clear(backgroundColor);
        }

        protected void noStroke()
        {
            strokeWeight = 0;
        }


        public Sketch()
        {
            width = DEFAULT_WIDTH;
            height = DEFAULT_HEIGHT;
            backgroundColor = DEFAULT_BACKGROUND_COLOR;
            fillColor = DEFAULT_FILL_COLOR;
            strokeWeight = DEFAULT_STROKE_WEIGHT;
            x = 0;
            y = 0;
            z = 0;
        }
        protected void size(uint width, uint height)
        {
            this.width = width;
            this.height = height;
        }

        protected void fill(float gray)
        {
            fillColor = ColorHelper.NewColor(gray);
        }

        protected void fill(float gray, byte alpha)
        {
            fillColor = ColorHelper.NewColor(gray, alpha);
        }

        protected void fill(float v1, float v2, float v3)
        {
            fillColor = ColorHelper.NewColor(v1, v2, v3);
        }

        protected void fill(float v1, float v2, float v3, byte alpha)
        {
            fillColor = ColorHelper.NewColor(v1, v2, v3, alpha);
        }

        protected void background(float gray)
        {
            this.backgroundColor = ColorHelper.NewColor(gray);
        }

        protected void background(float gray, byte alpha)
        {
            this.backgroundColor = ColorHelper.NewColor(gray,alpha);
        }

        protected void background(float v1, float v2, float v3)
        {
            this.backgroundColor = ColorHelper.NewColor(v1, v2, v3);
        }

        protected void background(float v1, float v2, float v3, byte alpha)
        {   
            this.backgroundColor = Helpers.ColorHelper.NewColor(v1,v2,v3,alpha);
        }

        protected void translate(float x, float y, float z)
        {
            this.x = x;
            this.y = y; 
            this.z = z;
        }

        protected void translate(float x, float y)
        {
            translate(x, y, this.z);
        }

        protected void ellipse(float x, float y, float width, float height)
        {
            CircleShape circle = new CircleShape(width)
            {
                Position = new Vector2f(this.x + x, this.y + y),
                FillColor = fillColor,
                OutlineThickness = strokeWeight
            };
            if (width != height)
            {
                circle.Scale = new Vector2f(1, height / width);
            }
            
            window.Draw(circle);
        }

        protected void colorMode(ColorMode colorMode)
        {
            ColorHelper.SetColorMode(colorMode);
        }


        public void Run()
        {
            Setup();

            initializeWindow();

            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(backgroundColor);
                Draw();
                window.Display();
            }
            
        }

        public abstract void Setup();
        public abstract void Draw();
    }
}
