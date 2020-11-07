using dotnetProcessing.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetProcessing.Core
{
    public class PGraphics: PImage
    {
        
        protected  Transformation transformation;

        protected PColor strokeColor;
        protected bool hasStroke = true;
        protected float strokeWeight = 1.0f;


        protected PColor fillColor;
        protected bool hasFill = true;


        protected PColor backgroundColor;
        

        public PGraphics()
        {
            strokeColor = new PColor();
            fillColor = new PColor();
            backgroundColor = new PColor();
            transformation = new Transformation();
        }

        public void Stroke(float v1, float v2, float v3)
        {
            hasStroke = true;
            strokeColor.SetColor(v1, v2, v3);
        }


        public void Stroke(float v1, float v2, float v3, byte alpha)
        {
            hasStroke = true;
            strokeColor.SetColor(v1, v2, v3, alpha);
        }

        public void Stroke(float gray)
        {
            hasStroke = true;
            strokeColor.SetColor(gray);
        }

        public void Stroke(float gray, byte alpha)
        {
            hasStroke = true;
            strokeColor.SetColor(gray,alpha);
        }

        public void Stroke(int rgb, byte alpha)
        {
            hasStroke = true;
            strokeColor.SetColor(rgb, alpha);
        }

        public void Stroke(int rgb)
        {
            hasStroke = true;
            strokeColor.SetColor(rgb);
        }

        public void StrokeWeight(float weight)
        {
            strokeWeight = weight;
        }

        public void NoStroke()
        {
            hasStroke = false;
        }

        public void Fill(float gray)
        {
            hasFill = true;
            fillColor.SetColor(gray);
        }

        public void Fill(float gray, byte alpha)
        {
            hasFill = true;
            fillColor.SetColor(gray, alpha);
        }

        public void Fill(float v1, float v2, float v3)
        {
            hasFill = true;
            fillColor.SetColor(v1, v2, v3);
        }

        public void Fill(float v1, float v2, float v3, byte alpha)
        {
            hasFill = true;
            fillColor.SetColor(v1, v2, v3, alpha);
        }

        public void NoFill()
        {
            hasFill = false;
        }
        

        protected virtual void drawCircleImpl(PVector position, float radius)
        {

        }

        protected virtual void drawRectImpl(PVector position, float width, float heigth)
        {

        }

        protected virtual void drawSquareImpl(PVector position, float sideLength)
        {

        }

        protected virtual void drawEllipseImpl(PVector position, float width, float height)
        {

        }

        protected virtual void drawPointImpl(PVector position)
        {

        }

        protected virtual void drawLineImpl(PVector p1, PVector p2)
        {

        }

        protected virtual void beginShapeImpl()
        {
        }

        protected virtual void endShapeImpl()
        {
        }

        protected virtual void addVertexImpl(PVector position)
        {
        }

        protected virtual void applyBackgoundColor(PColor backgroundColor)
        {
        }




        public void Circle(float x, float y, float radius)
        {
            PVector transformedPosition = transformation.GetTransformedVector(x-radius, y-radius);
            drawCircleImpl(transformedPosition, radius);            
        }

        public void Rect(float x, float y, float width, float heigth)
        {
            PVector transformedPosition = transformation.GetTransformedVector(x, y);
            drawRectImpl(transformedPosition, width, heigth);
            
        }

        public void Square(float x, float y, float sideLength)
        {
            PVector transformedPosition = transformation.GetTransformedVector(x, y);
            drawSquareImpl(transformedPosition, sideLength);            
        }

        public void Ellipse(float x, float y, float width, float height)
        {
            PVector transformedPosition = transformation.GetTransformedVector(x-width, y-height);
            drawEllipseImpl(transformedPosition, width, height);
        }
        public void Point(int x, int y)
        {
            PVector transformedPosition = transformation.GetTransformedVector(x, y);
            drawPointImpl(transformedPosition);
        }

        public void Line(float x1, float y1, float x2, float y2)
        {
            PVector transformedP1 = transformation.GetTransformedVector(x1, y1);
            PVector transformedP2 = transformation.GetTransformedVector(x2, y2);
            drawLineImpl(transformedP1, transformedP2);            
        }

        public void Background(float gray)
        {
            backgroundColor.SetColor(gray);
            applyBackgoundColor(backgroundColor);
        }        

        public void Background(float gray, byte alpha)
        {
            backgroundColor.SetColor(gray, alpha);
            applyBackgoundColor(backgroundColor);
        }

        public void Background(float v1, float v2, float v3)
        {
            backgroundColor.SetColor(v1, v2, v3);
            applyBackgoundColor(backgroundColor);
        }

        public void Background(float v1, float v2, float v3, byte alpha)
        {
            backgroundColor.SetColor(v1, v2, v3, alpha);
            applyBackgoundColor(backgroundColor);
        }

        public void BeginShape()
        {
            beginShapeImpl();
        }

        public void Vertex(float x, float y)
        {
            PVector position = transformation.GetTransformedVector(x, y);
            addVertexImpl(position);
        }

        public void EndShape()
        {
            endShapeImpl();
        }

        public virtual void BeginDraw()
        {
            transformation.Clear();
        }

        public virtual void EndDraw()
        {
            transformation.Clear();
        }


        public virtual void SetSize(int width, int height)
        {
            
        }

        public virtual IPSurface GetSurface()
        {
            return null;
        }

        public void Translate(float x, float y, float z)
        {
            transformation.Translate(x, y, z);
        }

        public void Translate(float x, float y)
        {
            Translate(x, y, 0);
        }

        public void Rotate(float angleInRadians)
        {
            float newAngle = transformation.Angle + angleInRadians;
            transformation.SetAngle(newAngle);
        }


    }
}
