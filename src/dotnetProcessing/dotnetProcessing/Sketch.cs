using dotnetProcessing.Helpers;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace dotnetProcessing
{
    public abstract class Sketch
    {
        private const int DEFAULT_WIDTH = 640;
        private const int DEFAULT_HEIGHT = 480;
        private readonly Color DEFAULT_BACKGROUND_COLOR = Color.Black;
        private readonly Color DEFAULT_FILL_COLOR = Color.White;
        private const float DEFAULT_STROKE_WEIGHT = 1f;

        private float x;
        private float y;
        private float z;

        private float angle;

        protected RenderWindow window;
        protected Color backgroundColor;
        protected Color fillColor;
        protected Color strokeColor;
        protected uint width;
        protected uint height;
        protected float strokeWeight;

        private Vector2f applyRotation(float x, float y)
        {
            double newX = this.x + x * Math.Cos(angle) - y * Math.Sin(angle);
            double newY = this.y + x * Math.Sin(angle) + y * Math.Cos(angle);

            return new Vector2f((float)newX, (float)newY);
        }
        

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
            if (window != null)
            {
                window.Dispose();
            }

            VideoMode video = new VideoMode(width, height);
            ContextSettings settings = new ContextSettings();
            settings.AntialiasingLevel = 0;
            window = new RenderWindow(video, "dotnetProcessing", Styles.Default, settings);
            
            window.SetFramerateLimit(60);
            window.Closed += (_, __) => window.Close();
            window.KeyReleased += Window_KeyReleased;
            
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
            angle = 0;
            initializeWindow();
        }
        protected void size(uint width, uint height)
        {
            this.width = width;
            this.height = height;            
            initializeWindow();
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


        protected void stroke(float gray)
        {
            strokeColor = ColorHelper.NewColor(gray);
        }

        protected void stroke(float gray, byte alpha)
        {
            strokeColor = ColorHelper.NewColor(gray, alpha);
        }

        protected void stroke(float v1, float v2, float v3)
        {
            strokeColor = ColorHelper.NewColor(v1, v2, v3);
        }

        protected void stroke(float v1, float v2, float v3, byte alpha)
        {
            strokeColor = ColorHelper.NewColor(v1, v2, v3, alpha);
        }


        protected void background(float gray)
        {
            background(gray, 255);
        }

        protected void background(float gray, byte alpha)
        {
            this.backgroundColor = ColorHelper.NewColor(gray,alpha);
            window.Clear(backgroundColor);
        }

        protected void background(float v1, float v2, float v3)
        {
            background(v1, v2, v3, 255);            
        }

        protected void background(float v1, float v2, float v3, byte alpha)
        {   
            this.backgroundColor = ColorHelper.NewColor(v1,v2,v3,alpha);
            window.Clear(backgroundColor);
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
                Position = applyRotation(x, y),
                FillColor = fillColor,
                OutlineThickness = strokeWeight,
                OutlineColor = strokeColor
            };

            circle.Scale = new Vector2f(1, height / width);

            window.Draw(circle);
        }

        protected void circle(float x, float y, float radius)
        {
            CircleShape circle = new CircleShape(radius*2)
            {   
                Position = applyRotation(x, y),
                FillColor = fillColor,
                OutlineThickness = strokeWeight,
                OutlineColor = strokeColor
            };

            window.Draw(circle);
        }

        protected void rect(float x, float y, float width, float heigth)
        {
            RectangleShape rectangle = new RectangleShape(new Vector2f(width, heigth))
            {   
                Position = applyRotation(x, y),
                FillColor = fillColor,
                OutlineThickness = strokeWeight,
                OutlineColor = strokeColor
            };

            window.Draw(rectangle);
            
        }

        public void point(int x, int y)
        {
            Vertex newPoint = new Vertex(new Vector2f(this.x+x, this.y + y), strokeColor);
            Vertex[] points = new Vertex[1];
            points[0] = newPoint;
            window.Draw(points, PrimitiveType.Points);
        }


        protected void square(float x, float y, float sideLength)
        {
            rect(x, y, sideLength, sideLength);
        }

        protected void colorMode(ColorMode colorMode)
        {
            ColorHelper.SetColorMode(colorMode);
        }

        public void Run()
        {
            Setup();

            while (window.IsOpen)
            {
                window.DispatchEvents();
                Draw();
                window.Display();
            }
            
        }

        protected void rotate(float angleInRadians)
        {
            this.angle = angleInRadians;
        }

        public abstract void Setup();
        public abstract void Draw();
    }
}
