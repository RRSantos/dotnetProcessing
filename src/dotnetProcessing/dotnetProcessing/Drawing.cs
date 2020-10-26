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
        private Transformation transformation;

        private readonly VertexArray shapePoints = new VertexArray(PrimitiveType.LineStrip);


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

        public void SetStrokeWeight(float weight)
        {
            strokeWeight = weight;
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

        public void SetNoFillColor()
        {
            fillColor = ColorHelper.NewColor(0, 0, 0, 0);
        }

        #endregion

        #region Shapes

        private CircleShape createCircleShape(float x, float y, float radius)
        {
            CircleShape circleShape = new CircleShape(radius)
            {
                //Position = transformation.GetTransformedVector(x-radius, y-radius),
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
            circle.Position = transformation.GetTransformedVector(x - width, y - height);
            circle.Scale = new Vector2f(1, height / width);
            window.Draw(circle);
        }

        public void DrawPoint(int x, int y)
        {
            if (strokeWeight <= 1)
            {
                Vertex newPoint = new Vertex(transformation.GetTransformedVector(x, y), strokeColor);
                Vertex[] points = new Vertex[1];
                points[0] = newPoint;
                window.Draw(points, PrimitiveType.Points);
            }
            else
            {
                CircleShape circleShape = new CircleShape(strokeWeight*0.5f)
                {   
                    FillColor = strokeColor,
                    OutlineThickness = 0
                };
                circleShape.Position = transformation.GetTransformedVector(x, y);
                window.Draw(circleShape);
            }
            
        }

        public void DrawCircle(float x, float y, float radius)
        {

            CircleShape circle = createCircleShape(x, y, radius);
            circle.Position = transformation.GetTransformedVector(x - radius, y - radius);
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

        public void DrawLine(float x1, float y1, float x2, float y2)
        {
            Vertex point1 = new Vertex(transformation.GetTransformedVector(x1, y1), strokeColor);
            Vertex point2 = new Vertex(transformation.GetTransformedVector(x2, y2), strokeColor);
            Vertex[] points = new Vertex[2];
            points[0] = point1;
            points[1] = point2;
            window.Draw(points, PrimitiveType.Lines);
        }



        #endregion

        #region Background

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


        public void ClearShape()
        {
            shapePoints.Clear();
        }

        public void AddShapePoint(float x, float y )
        {
            Vector2f shapePoint = transformation.GetTransformedVector(x, y);
            shapePoints.Append(new Vertex(shapePoint, strokeColor));
        }

        public void DrawShape()
        {
            window.Draw(shapePoints);
            ClearShape();
        }

        public void SetTransformation(Transformation newTransformation)
        {
            transformation = newTransformation; 
        }

    }
}
