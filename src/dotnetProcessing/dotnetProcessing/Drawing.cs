using dotnetProcessing.Helpers;
using SFML.Graphics;
using SFML.System;

namespace dotnetProcessing
{
    class Drawing
    {

        private readonly Color DEFAULT_FILL_COLOR = Color.White;
        private readonly Color DEFAULT_STROKE_COLOR = Color.White;
        private readonly Color DEFAULT_BACKGROUND_COLOR = Color.Black;        
        private const float DEFAULT_STROKE_WEIGHT = 1f;

        private readonly RenderWindow window;
        private readonly Transformation transformation;


        private Color strokeColor;
        private Color fillColor;
        private Color backgroundColor;
        private float strokeWeight;

        public Drawing(RenderWindow window, Transformation transformation)
        {
            this.window = window;
            this.transformation = transformation;
            fillColor = DEFAULT_FILL_COLOR;
            strokeColor = DEFAULT_STROKE_COLOR;
            strokeWeight = DEFAULT_STROKE_WEIGHT;
            backgroundColor = DEFAULT_BACKGROUND_COLOR;
        }

        #region stroke
        public void NoStroke()
        {
            strokeWeight = 0;
        }

        public void SetStrokeColor(float gray)
        {
            strokeColor = ColorHelper.NewColor(gray);
        }

        public void SetStrokeColor(float gray, byte alpha)
        {
            strokeColor = ColorHelper.NewColor(gray, alpha);
        }

        public void SetStrokeColor(float v1, float v2, float v3)
        {
            strokeColor = ColorHelper.NewColor(v1, v2, v3);
        }

        public void SetStrokeColor(float v1, float v2, float v3, byte alpha)
        {
            strokeColor = ColorHelper.NewColor(v1, v2, v3, alpha);
        }
        #endregion

        #region Fill
        public void SetFillColor(float gray)
        {
            fillColor = ColorHelper.NewColor(gray);
        }

        public void SetFillColor(float gray, byte alpha)
        {
            fillColor = ColorHelper.NewColor(gray, alpha);
        }

        public void SetFillColor(float v1, float v2, float v3)
        {
            fillColor = ColorHelper.NewColor(v1, v2, v3);
        }

        public void SetFillColor(float v1, float v2, float v3, byte alpha)
        {
            fillColor = ColorHelper.NewColor(v1, v2, v3, alpha);
        }

        #endregion

        #region Shapes

        private CircleShape createCircleShape(float x, float y, float radius)
        {
            CircleShape circleShape = new CircleShape(radius)
            {
                Position = transformation.GetTransformedVector(x, y),
                FillColor = fillColor,
                OutlineThickness = strokeWeight,
                OutlineColor = strokeColor,
                Rotation = ConvertionHelper.RadiansToDegrees(transformation.Angle)
            };

            return circleShape;
        }

        public void DrawEllipse(float x, float y, float width, float height)
        {
            CircleShape circle = createCircleShape(x, y, width);
            circle.Scale = new Vector2f(1, height / width);
            window.Draw(circle);
        }

        public void DrawPoint(int x, int y)
        {
            Vertex newPoint = new Vertex(transformation.GetTransformedVector(x, y), strokeColor);
            Vertex[] points = new Vertex[1];
            points[0] = newPoint;
            window.Draw(points, PrimitiveType.Points);
        }

        public void DrawCircle(float x, float y, float radius)
        {

            CircleShape circle = createCircleShape(x, y, radius);
            window.Draw(circle);
        }

        public void DrawRectangle(float x, float y, float width, float heigth)
        {
            RectangleShape rectangle = new RectangleShape(new Vector2f(width, heigth))
            {
                Position = transformation.GetTransformedVector(x, y),
                FillColor = fillColor,
                OutlineThickness = strokeWeight,
                OutlineColor = strokeColor,
                Rotation = ConvertionHelper.RadiansToDegrees(transformation.Angle)
            };

            window.Draw(rectangle);

        }

        public void DrawSquare(float x, float y, float sideLength)
        {
            DrawRectangle(x, y, sideLength, sideLength);
        }

        #endregion

        #region background

        public void SetBackgroundColor(float gray)
        {
            SetBackgroundColor(gray, 255);
        }

        public void SetBackgroundColor(float gray, byte alpha)
        {
            this.backgroundColor = ColorHelper.NewColor(gray, alpha);
            window.Clear(backgroundColor);
        }

        public void SetBackgroundColor(float v1, float v2, float v3)
        {
            SetBackgroundColor(v1, v2, v3, 255);
        }

        public void SetBackgroundColor(float v1, float v2, float v3, byte alpha)
        {
            this.backgroundColor = ColorHelper.NewColor(v1, v2, v3, alpha);
            window.Clear(backgroundColor);
        }

        #endregion

    }
}
