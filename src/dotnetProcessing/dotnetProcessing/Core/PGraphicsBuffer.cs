using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetProcessing.Core
{
    class PGraphicsBuffer:PGraphics
    {
        private readonly List<Action<PGraphics>> actionsBuffer = new List<Action<PGraphics>>();

        public IReadOnlyList<Action<PGraphics>> PendingActions { get { return actionsBuffer.AsReadOnly(); } }
        public override void Stroke(float v1, float v2, float v3)
        {
            actionsBuffer.Add(graphics => graphics.Stroke(v1, v2, v3));
        }

        public override void Stroke(float v1, float v2, float v3, byte alpha)
        {
            actionsBuffer.Add(graphics => graphics.Stroke(v1, v2, v3, alpha));
        }

        public override void Stroke(float gray)
        {
            actionsBuffer.Add(graphics => graphics.Stroke(gray));
        }

        public override void Stroke(float gray, byte alpha)
        {
            actionsBuffer.Add(graphics => graphics.Stroke(gray, alpha));
        }

        public override void Stroke(int rgb, byte alpha)
        {
            actionsBuffer.Add(graphics => graphics.Stroke(rgb, alpha));
        }

        public override void Stroke(int rgb)
        {
            actionsBuffer.Add(graphics => graphics.Stroke(rgb));
        }

        public override void StrokeWeight(float weight)
        {
            actionsBuffer.Add(graphics => graphics.StrokeWeight(weight));
        }

        public override void NoStroke()
        {
            actionsBuffer.Add(graphics => graphics.NoStroke());
        }

        public override void Fill(float gray)
        {
            actionsBuffer.Add(graphics => graphics.Fill(gray));
        }

        public override void Fill(float gray, byte alpha)
        {
            actionsBuffer.Add(graphics => graphics.Fill(gray, alpha));
        }

        public override void Fill(float v1, float v2, float v3)
        {
            actionsBuffer.Add(graphics => graphics.Fill(v1, v2, v3));
        }

        public override void Fill(float v1, float v2, float v3, byte alpha)
        {
            actionsBuffer.Add(graphics => graphics.Fill(v1, v2, v3, alpha));
        }

        public override void NoFill()
        {
            actionsBuffer.Add(graphics => graphics.NoFill());
        }

        public override void Circle(float x, float y, float radius)
        {
            actionsBuffer.Add(graphics => graphics.Circle(x, y, radius));
        }

        public override void Rect(float x, float y, float width, float heigth)
        {
            actionsBuffer.Add(graphics => graphics.Rect(x, y, width, heigth));
        }

        public override void Square(float x, float y, float sideLength)
        {
            actionsBuffer.Add(graphics => graphics.Square(x, y, sideLength));
        }

        public override void Ellipse(float x, float y, float width, float height)
        {
            actionsBuffer.Add(graphics => graphics.Ellipse(x, y, width, height));
        }
        public override void Point(int x, int y)
        {
            actionsBuffer.Add(graphics => graphics.Point(x, y));
        }

        public override void Line(float x1, float y1, float x2, float y2)
        {
            actionsBuffer.Add(graphics => graphics.Line(x1, y1, x2, y2));
        }

        public override void Background(float gray)
        {
            actionsBuffer.Add(graphics => graphics.Background(gray));
        }

        public override void Background(float gray, byte alpha)
        {
            actionsBuffer.Add(graphics => graphics.Background(gray, alpha));
        }

        public override void Background(float v1, float v2, float v3)
        {
            actionsBuffer.Add(graphics => graphics.Background(v1, v2, v3));
        }

        public override void Background(float v1, float v2, float v3, byte alpha)
        {
            actionsBuffer.Add(graphics => graphics.Background(v1, v2, v3, alpha));
        }

        public override void BeginShape()
        {
            actionsBuffer.Add(graphics => graphics.BeginShape());
        }

        public override void Vertex(float x, float y)
        {
            actionsBuffer.Add(graphics => graphics.Vertex(x, y));
        }

        public override void EndShape()
        {
            actionsBuffer.Add(graphics => graphics.EndShape());
        }

        public override void BeginDraw()
        {
            actionsBuffer.Add(graphics => graphics.BeginDraw());
        }

        public override void EndDraw()
        {
            actionsBuffer.Add(graphics => graphics.EndDraw());
        }


        public override void SetSize(int width, int height)
        {
            actionsBuffer.Add(graphics => graphics.SetSize(width, height));
        }        

        public override void Translate(float x, float y, float z)
        {
            actionsBuffer.Add(graphics => graphics.Translate(x, y, z));
        }

        public override void Translate(float x, float y)
        {
            actionsBuffer.Add(graphics => graphics.Translate(x, y));
        }

        public override void Rotate(float angleInRadians)
        {
            actionsBuffer.Add(graphics => graphics.Rotate(angleInRadians));
        }

        public override void Pop()
        {
            actionsBuffer.Add(graphics => graphics.Pop());
        }

        public override void PopMatrix()
        {
            actionsBuffer.Add(graphics => graphics.PopMatrix());
        }

        public override void PopStyle()
        {
            actionsBuffer.Add(graphics => graphics.PopStyle());
        }

        public override void Push()
        {
            actionsBuffer.Add(graphics => graphics.Push());
        }

        public override void PushMatrix()
        {
            actionsBuffer.Add(graphics => graphics.PushMatrix());
        }

        public override void PushStyle()
        {
            actionsBuffer.Add(graphics => graphics.PushStyle());
        }

        public override void Text(string text, float x, float y)
        {
            actionsBuffer.Add(graphics => graphics.Text(text, x, y));
        }

        public override void Text(string text, float x, float y, float z)
        {
            actionsBuffer.Add(graphics => graphics.Text(text, x, y, z));
        }

        public override void Text(char c, float x, float y)
        {
            actionsBuffer.Add(graphics => graphics.Text(c, x, y));
        }

        public override void Text(char c, float x, float y, float z)
        {
            actionsBuffer.Add(graphics => graphics.Text(c, x, y, z));
        }

        public override void Text(char[] chars, int start, int stop, float x, float y)
        {
            actionsBuffer.Add(graphics => graphics.Text(chars, start, stop, x, y));
        }

        public override void Text(char[] chars, int start, int stop, float x, float y, float z)
        {
            actionsBuffer.Add(graphics => graphics.Text(chars, start, stop, x, y, z));
        }

        public override void Text(string text, float x1, float y1, float x2, float y2)
        {
            actionsBuffer.Add(graphics => graphics.Text(text, x1, y1, x2, y2));
        }

        public override void Text(int num, float x, float y)
        {
            actionsBuffer.Add(graphics => graphics.Text(num, x, y));
        }

        public override void Text(int num, float x, float y, float z)
        {
            actionsBuffer.Add(graphics => graphics.Text(num, x, y, z));
        }
    }
}
