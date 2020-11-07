using dotnetProcessing.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetProcessing.Core
{
    public class PGraphics:IDisposable
    {
        private IDrawable drawable;
        private  Transformation transformation;

        public PGraphics()
            :this(100,100)
        {
            
        }

        public PGraphics(int width, int height)
        {
            drawable = RenderingEngineFactory.CreateDrawable(width, height);
            transformation = new Transformation();
        }

        public void SetSize(int width, int height)
        {
            if (drawable != null)
            {
                drawable.Dispose();
            }
            drawable = RenderingEngineFactory.CreateDrawable(width, height);
        }

        public void NoStroke()
        {
            drawable.NoStroke();
        }

        public void Stroke(float gray)
        {
            drawable.SetStrokeColor(gray);
        }

        public void Stroke(float gray, byte alpha)
        {
            drawable.SetStrokeColor(gray, alpha);
        }

        public void Stroke(float v1, float v2, float v3)
        {
            drawable.SetStrokeColor(v1, v2, v3);
        }

        public void Stroke(float v1, float v2, float v3, byte alpha)
        {
            drawable.SetStrokeColor(v1, v2, v3, alpha);
        }

        public void StrokeWeight(float weight)
        {
            drawable.SetStrokeWeight(weight);
        }

        public void Fill(float gray)
        {
            drawable.SetFillColor(gray);
        }

        public void Fill(float gray, byte alpha)
        {
            drawable.SetFillColor(gray, alpha);
        }

        public void Fill(float v1, float v2, float v3)
        {
            drawable.SetFillColor(v1, v2, v3);
        }

        public void Fill(float v1, float v2, float v3, byte alpha)
        {
            drawable.SetFillColor(v1, v2, v3, alpha);
        }

        public void NoFill()
        {
            drawable.SetNoFillColor();
        }

        public void Circle(float x, float y, float radius)
        {
            drawable.DrawCircle(x, y, radius);
            //needsRefresh = true;
        }

        public void Rect(float x, float y, float width, float heigth)
        {
            drawable.DrawRectangle(x, y, width, heigth);
            //needsRefresh = true;
        }

        public void Square(float x, float y, float sideLength)
        {
            drawable.DrawSquare(x, y, sideLength);
            //needsRefresh = true;
        }

        public void Ellipse(float x, float y, float width, float height)
        {
            drawable.DrawEllipse(x, y, width, height);
            //needsRefresh = true;
        }
        public void Point(int x, int y)
        {
            drawable.DrawPoint(x, y);
            //needsRefresh = true;
        }

        public void Line(float x1, float y1, float x2, float y2)
        {
            drawable.DrawLine(x1, y1, x2, y2);
            //needsRefresh = true;
        }

        public void Background(float gray)
        {
            drawable.SetBackgroundColor(gray);
            //needsRefresh = true;
        }

        public void Background(float gray, byte alpha)
        {
            drawable.SetBackgroundColor(gray, alpha);
            //needsRefresh = true;
        }

        public void Background(float v1, float v2, float v3)
        {
            drawable.SetBackgroundColor(v1, v2, v3, 255);
            //needsRefresh = true;
        }

        public void Background(float v1, float v2, float v3, byte alpha)
        {
            drawable.SetBackgroundColor(v1, v2, v3, alpha);
            //needsRefresh = true;
        }

        public void BeginShape()
        {
            drawable.ClearShape();
        }

        public void Vertex(float x, float y)
        {
            drawable.AddShapePoint(x, y);
        }

        public void EndShape()
        {
            drawable.DrawShape();
            //needsRefresh = true;
        }

        public void BeginDraw()
        {
            drawable.Display();
        }

        public void EndDraw()
        {

        }

        public void Dispose()
        {
            drawable.Dispose();
        }
    }
}
