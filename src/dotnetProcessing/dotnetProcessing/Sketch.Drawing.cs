
namespace dotnetProcessing
{
    partial class Sketch
    {
        protected void noStroke()
        {
            drawing.NoStroke();
        }

        protected void stroke(float gray)
        {
            drawing.SetStrokeColor(gray);
        }

        protected void stroke(float gray, byte alpha)
        {
            drawing.SetStrokeColor(gray, alpha);
        }

        protected void stroke(float v1, float v2, float v3)
        {
            drawing.SetStrokeColor(v1, v2, v3);
        }

        protected void stroke(float v1, float v2, float v3, byte alpha)
        {
            drawing.SetStrokeColor(v1, v2, v3, alpha);
        }

        protected void fill(float gray)
        {
            drawing.SetFillColor(gray);
        }

        protected void fill(float gray, byte alpha)
        {
            drawing.SetFillColor(gray, alpha);
        }

        protected void fill(float v1, float v2, float v3)
        {
            drawing.SetFillColor(v1, v2, v3);
        }

        protected void fill(float v1, float v2, float v3, byte alpha)
        {
            drawing.SetFillColor(v1, v2, v3, alpha);
        }

        protected void circle(float x, float y, float radius)
        {
            drawing.DrawCircle(x, y, radius);
            needsRefresh = true;
        }

        protected void rect(float x, float y, float width, float heigth)
        {
            drawing.DrawRectangle(x, y, width, heigth);
            needsRefresh = true;
        }

        protected void square(float x, float y, float sideLength)
        {
            drawing.DrawSquare(x, y, sideLength);
            needsRefresh = true;
        }

        protected void ellipse(float x, float y, float width, float height)
        {
            drawing.DrawEllipse(x, y, width, height);
            needsRefresh = true;
        }
        protected void point(int x, int y)
        {
            drawing.DrawPoint(x, y);
            needsRefresh = true;
        }

        protected void background(float gray)
        {
            drawing.SetBackgroundColor(gray);
            needsRefresh = true;
        }

        protected void background(float gray, byte alpha)
        {
            drawing.SetBackgroundColor(gray, alpha);
            needsRefresh = true;
        }

        protected void background(float v1, float v2, float v3)
        {
            drawing.SetBackgroundColor(v1, v2, v3, 255);
            needsRefresh = true;
        }

        protected void background(float v1, float v2, float v3, byte alpha)
        {
            drawing.SetBackgroundColor(v1, v2, v3, alpha);
            needsRefresh = true;
        }
    }
}
