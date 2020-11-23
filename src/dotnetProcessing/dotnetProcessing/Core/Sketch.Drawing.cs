
using SFML.System;
using System;

namespace dotnetProcessing.Core
{
    partial class Sketch
    {
        protected void noStroke()
        {
            graphics.NoStroke();
        }

        protected void stroke(float gray)
        {
            graphics.Stroke(gray);
        }

        protected void stroke(float gray, byte alpha)
        {
            graphics.Stroke(gray, alpha);
        }

        protected void stroke(float v1, float v2, float v3)
        {
            graphics.Stroke(v1, v2, v3);
        }

        protected void stroke(float v1, float v2, float v3, byte alpha)
        {
            graphics.Stroke(v1, v2, v3, alpha);
        }

        protected void strokeWeight(float weight)
        {
            graphics.StrokeWeight(weight);
        }

        protected void fill(float gray)
        {
            graphics.Fill(gray);
        }

        protected void fill(float gray, byte alpha)
        {
            graphics.Fill(gray, alpha);
        }

        protected void fill(float v1, float v2, float v3)
        {
            graphics.Fill(v1, v2, v3);
        }

        protected void fill(float v1, float v2, float v3, byte alpha)
        {
            graphics.Fill(v1, v2, v3, alpha);
        }

        protected void noFill()
        {
            graphics.NoFill();
        }

        protected void circle(float x, float y, float radius)
        {
            graphics.Circle(x, y, radius);            
        }

        protected void rect(float x, float y, float width, float heigth)
        {
            graphics.Rect(x, y, width, heigth);
        }

        protected void square(float x, float y, float sideLength)
        {
            graphics.Square(x, y, sideLength);
        }

        protected void ellipse(float x, float y, float width, float height)
        {
            graphics.Ellipse(x, y, width, height);
        }
        protected void point(int x, int y)
        {
            graphics.Point(x, y);
        }

        protected void line(float x1, float y1, float x2, float y2)
        {
            graphics.Line(x1, y1,x2,y2);
        }

        protected void background(float gray)
        {
            graphics.Background(gray);
        }

        protected void background(float gray, byte alpha)
        {
            graphics.Background(gray, alpha);
        }

        protected void background(float v1, float v2, float v3)
        {
            graphics.Background(v1, v2, v3);
        }

        protected void background(float v1, float v2, float v3, byte alpha)
        {
            graphics.Background(v1, v2, v3, alpha);
        }

        protected void beginShape()
        {
            graphics.BeginShape();
        }

        protected void vertex(float x, float y)
        {
            graphics.Vertex(x, y);
        }

        protected void endShape()
        {
            graphics.EndShape();
        }

        protected void text(string newText, float x, float y)
        {
            graphics.Text(newText, x, y);
        }

        protected void text(string newText, float x, float y, float z)
        {
            graphics.Text(newText, x, y, z);
        }

        protected void text(char c, float x, float y)
        {
            graphics.Text(c, x, y);
        }

        protected void text(char c, float x, float y, float z)
        {
            graphics.Text(c, x, y, z);
        }

        protected void text(char[] chars, int start, int stop, float x, float y)
        {
            graphics.Text(chars, start, stop, x, y);
        }

        protected void text(char[] chars, int start, int stop, float x, float y, float z)
        {
            graphics.Text(chars, start, stop, x, y, z);
        }

        protected void text(string text, float x1, float y1, float x2, float y2)
        {
            graphics.Text(text, x1, y1, x2, y2);
        }

        protected void text(int num, float x, float y, float z)
        {
            graphics.Text(num, x, y, z);
        }

        protected void text(int num, float x, float y)
        {
            graphics.Text(num, x, y);
        }

        protected void textSize(float size)
        {
            graphics.TextSize(size);
        }
    }
}
