using System;

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

        public int Width { get; protected set; }

        public int Height { get; protected set; }

        public PGraphics()
        {
            strokeColor = new PColor();
            fillColor = new PColor();
            backgroundColor = new PColor();
            transformation = new Transformation();
        }

        public virtual void Stroke(float v1, float v2, float v3)
        {
            hasStroke = true;
            strokeColor.SetColor(v1, v2, v3);
        }


        public virtual void Stroke(float v1, float v2, float v3, byte alpha)
        {
            hasStroke = true;
            strokeColor.SetColor(v1, v2, v3, alpha);
        }

        public virtual void Stroke(float gray)
        {
            hasStroke = true;
            strokeColor.SetColor(gray);
        }

        public virtual void Stroke(float gray, byte alpha)
        {
            hasStroke = true;
            strokeColor.SetColor(gray,alpha);
        }

        public virtual void Stroke(int rgb, byte alpha)
        {
            hasStroke = true;
            strokeColor.SetColor(rgb, alpha);
        }

        public virtual void Stroke(int rgb)
        {
            hasStroke = true;
            strokeColor.SetColor(rgb);
        }

        public virtual void StrokeWeight(float weight)
        {
            strokeWeight = weight;
        }

        public virtual void NoStroke()
        {
            hasStroke = false;
        }

        public virtual void Fill(float gray)
        {
            hasFill = true;
            fillColor.SetColor(gray);
        }

        public virtual void Fill(float gray, byte alpha)
        {
            hasFill = true;
            fillColor.SetColor(gray, alpha);
        }

        public virtual void Fill(float v1, float v2, float v3)
        {
            hasFill = true;
            fillColor.SetColor(v1, v2, v3);
        }

        public virtual void Fill(float v1, float v2, float v3, byte alpha)
        {
            hasFill = true;
            fillColor.SetColor(v1, v2, v3, alpha);
        }

        public virtual void NoFill()
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

        protected virtual void drawTextImpl(PVector position, char[] chars)
        {
        }





        public virtual void Circle(float x, float y, float radius)
        {
            PVector transformedPosition = transformation.GetTransformedVector(x-radius, y-radius);
            drawCircleImpl(transformedPosition, radius);            
        }

        public virtual void Rect(float x, float y, float width, float heigth)
        {
            PVector transformedPosition = transformation.GetTransformedVector(x, y);
            drawRectImpl(transformedPosition, width, heigth);
            
        }

        public virtual void Square(float x, float y, float sideLength)
        {
            PVector transformedPosition = transformation.GetTransformedVector(x, y);
            drawSquareImpl(transformedPosition, sideLength);            
        }

        public virtual void Ellipse(float x, float y, float width, float height)
        {
            PVector transformedPosition = transformation.GetTransformedVector(x-width, y-height);
            drawEllipseImpl(transformedPosition, width, height);
        }
        public virtual void Point(int x, int y)
        {
            PVector transformedPosition = transformation.GetTransformedVector(x, y);
            drawPointImpl(transformedPosition);
        }

        public virtual void Line(float x1, float y1, float x2, float y2)
        {
            PVector transformedP1 = transformation.GetTransformedVector(x1, y1);
            PVector transformedP2 = transformation.GetTransformedVector(x2, y2);
            drawLineImpl(transformedP1, transformedP2);            
        }

        public virtual void Background(float gray)
        {
            backgroundColor.SetColor(gray);
            applyBackgoundColor(backgroundColor);
        }        

        public virtual void Background(float gray, byte alpha)
        {
            backgroundColor.SetColor(gray, alpha);
            applyBackgoundColor(backgroundColor);
        }

        public virtual void Background(float v1, float v2, float v3)
        {
            backgroundColor.SetColor(v1, v2, v3);
            applyBackgoundColor(backgroundColor);
        }

        public virtual void Background(float v1, float v2, float v3, byte alpha)
        {
            backgroundColor.SetColor(v1, v2, v3, alpha);
            applyBackgoundColor(backgroundColor);
        }

        public virtual void BeginShape()
        {
            beginShapeImpl();
        }

        public virtual void Vertex(float x, float y)
        {
            PVector position = transformation.GetTransformedVector(x, y);
            addVertexImpl(position);
        }

        public virtual void EndShape()
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

        public virtual void Translate(float x, float y, float z)
        {
            transformation.Translate(x, y, z);
        }

        public virtual void Translate(float x, float y)
        {
            Translate(x, y, 0);
        }

        public virtual void Rotate(float angleInRadians)
        {
            float newAngle = transformation.Angle + angleInRadians;
            transformation.SetAngle(newAngle);
        }

        public virtual void Pop()
        {
            PopMatrix();
            PopStyle();
        }

        public virtual void PopMatrix()
        {   
            
        }

        public virtual void PopStyle()
        {
            
        }

        public virtual void Push()
        {
            PushMatrix();
            PushStyle();
        }

        public virtual void PushMatrix()
        {

        }

        public virtual void PushStyle()
        {

        }

        public virtual void Text(char c, float x, float y)
        {
            PVector transformedPosition = transformation.GetTransformedVector(x, y);
            drawTextImpl(transformedPosition, new char[] { c });
        }

        public virtual void Text(char c, float x, float y, float z)
        {
            PVector transformedPosition = transformation.GetTransformedVector(x, y, z);
            drawTextImpl(transformedPosition, new char[] { c });
        }

        public virtual void Text(string text, float x, float y)
        {
            PVector transformedPosition = transformation.GetTransformedVector(x, y);
            drawTextImpl(transformedPosition, text.ToCharArray());
        }

        public virtual void Text(string text, float x, float y, float z)
        {
            PVector transformedPosition = transformation.GetTransformedVector(x, y, z);
            drawTextImpl(transformedPosition, text.ToCharArray());
        }

        public virtual void Text(char[] chars, int start, int stop, float x, float y)
        {
            int copyLength = stop - start + 1;
            char[] croppedArray = new char[chars.Length];
            Array.Copy(chars, start, croppedArray, 0, copyLength);
            Array.Resize<char>(ref croppedArray, copyLength);            

            PVector transformedPosition = transformation.GetTransformedVector(x, y);
            drawTextImpl(transformedPosition, croppedArray);
        }

        public virtual void Text(char[] chars, int start, int stop, float x, float y, float z)
        {
            int copyLength = stop - start + 1;
            char[] croppedArray = new char[chars.Length];
            Array.Copy(chars, croppedArray, copyLength);
            Array.Resize<char>(ref croppedArray, copyLength);

            PVector transformedPosition = transformation.GetTransformedVector(x, y, z);
            drawTextImpl(transformedPosition, croppedArray);
        }

        public virtual void Text(string text, float x1, float y1, float x2, float y2)
        {
            throw new NotImplementedException("Not implemented.");            
        }

        public virtual void Text(int num, float x, float y)
        {
            PVector transformedPosition = transformation.GetTransformedVector(x, y);
            drawTextImpl(transformedPosition, num.ToString().ToCharArray());
        }

        public virtual void Text(int num, float x, float y, float z)
        {
            PVector transformedPosition = transformation.GetTransformedVector(x, y, z);
            drawTextImpl(transformedPosition, num.ToString().ToCharArray());
        }




    }
}
