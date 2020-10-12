using dotnetProcessing;
using dotnetProcessing.Helpers;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace dotnetProcessingManualTest
{
    class Orbit
    {
        private const int k = -4; 

        private float angle;
        private float speed;
        public float X { get; protected set; }
        public float Y { get; protected set; }
        public float Radius { get; }

        public Orbit Parent { get; }
        public Orbit Child { get; protected set; }


        private int getActualLevel()
        {
            int level = 0;
            Orbit parent = Parent;
            while (parent != null)
            {
                parent = parent.Parent;
                level++;
            }

            return level;
        }
        public Orbit(float x, float y, float radius , Orbit parent)
        {
            X = x;
            Y = y;
            Radius = radius;
            Parent = parent;
            angle = (float)(-Math.PI / 2f);
            int actualLevel = getActualLevel();
            speed = ConvertionHelper.DegreesToRadians((float)Math.Pow(k, actualLevel - 1)/10f);
            //speed = (float)Math.Pow(k, actualLevel - 1) / 50f;
        }

        public Orbit(float x, float y, float radius) : this(x, y, radius, null)
        {   
            
        }

        public Orbit CreateChild()
        {
            float childRadius = this.Radius / 3;
            Child = new Orbit(this.X + this.Radius + childRadius, 0, childRadius, this);
            return Child;
        }

        public void Update()
        {
            if (Parent != null)
            {
                X = (float)(Parent.X + (Parent.Radius + Radius )* Math.Cos(angle));
                Y = (float)(Parent.Y + (Parent.Radius + Radius )* Math.Sin(angle));
                angle += speed;
            }
            
        }
    }
    class FractalSpirographSketch : Sketch
    {
        private int samples = 5;
        private Orbit sun;
        private Orbit lastMoon;
        List<Vector2f> points = new List<Vector2f>();
        public override void Draw()
        {
            background(0);
            
            for (int i = 0; i < samples; i++)
            {
                Orbit moon = sun;
                while (moon != null)
                {
                    moon.Update();
                    if (i == samples - 1)
                    {
                        stroke(255);
                        circle(moon.X, moon.Y, moon.Radius);
                    }
                    moon = moon.Child;
                }
                points.Add(new Vector2f(lastMoon.X, lastMoon.Y));
            }



            stroke(255, 0, 255);
            beginShape();            
            for (int i = 0; i < points.Count; i++)
            {
                vertex(points[i].X, points[i].Y);
            }
            endShape();

        }

        public override void Setup()
        {
            size(800, 800);
            background(0);
            translate(width / 2, height / 2);
            stroke(255);
            strokeWeight(1f);
            noFill();

            float radius = width / 6;

            sun = new Orbit(0, 0, radius);
            Orbit moon = sun;
            for (int i = 0; i < 15; i++)
            {
                moon = moon.CreateChild();
            }

            lastMoon = moon;
            
        }
    }
}
