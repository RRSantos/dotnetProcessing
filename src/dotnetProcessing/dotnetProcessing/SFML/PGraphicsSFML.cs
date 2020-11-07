using dotnetProcessing.Core;
using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;


namespace dotnetProcessing.SFML
{
    class PGraphicsSFML:PGraphics
    {
        
        private RenderWindow window;
        private readonly VertexArray shapePoints;
        

        private Color toColor(PColor pcolor)
        {
            Color newColor = new Color(pcolor.RGBA);
            return newColor;
        }

        private Vector2f toVector2f(PVector pvector)
        {
            return new Vector2f(pvector.X, pvector.Y);
        }

        private CircleShape createCircleShape(float radius)
        {
            CircleShape circleShape = new CircleShape(radius)
            {
                FillColor = toColor(fillColor),
                OutlineThickness = strokeWeight,
                OutlineColor = toColor(strokeColor),
                Rotation = Helpers.ConvertionHelper.RadiansToDegrees(transformation.Angle)
            };

            return circleShape;
        }

        protected override void drawCircleImpl(PVector position, float radius)
        {
            Shape circle = createCircleShape(radius);
            circle.Position = toVector2f(position);
            window.Draw(circle);
            surface.RefreshNeeded();
        }
        

        protected override void drawRectImpl(PVector position, float width, float heigth)
        {
            RectangleShape rectangle = new RectangleShape(new Vector2f(width, heigth))
            {
                Position = toVector2f(position),
                FillColor = toColor(fillColor),
                OutlineThickness = strokeWeight,
                OutlineColor = toColor(strokeColor),
                Rotation = Helpers.ConvertionHelper.RadiansToDegrees(transformation.Angle)
            };

            window.Draw(rectangle);
            surface.RefreshNeeded();
        }

        protected override void drawSquareImpl(PVector position, float sideLength)
        {
            drawRectImpl(position, sideLength, sideLength);
        }

        protected override void drawEllipseImpl(PVector position, float width, float height)
        {
            Shape ellipse = createCircleShape(width);
            ellipse.Position = toVector2f(position);
            ellipse.Scale = new Vector2f(1, height / width);
            window.Draw(ellipse);
            surface.RefreshNeeded();
        }

        protected override void drawPointImpl(PVector position)
        {
            if (strokeWeight <= 1)
            {   
                Vector2f newPosition = toVector2f(position);

                Vertex newPoint = new Vertex(newPosition, toColor(strokeColor));
                Vertex[] points = new Vertex[1];
                points[0] = newPoint;
                window.Draw(points, PrimitiveType.Points);
            }
            else
            {
                CircleShape circleShape = new CircleShape(strokeWeight * 0.5f)
                {
                    FillColor = toColor(strokeColor),
                    OutlineThickness = 0
                };
                
                circleShape.Position = toVector2f(position);
                window.Draw(circleShape);
            }
            surface.RefreshNeeded();
        }

        protected override void drawLineImpl(PVector p1, PVector p2)
        {
            
            Vertex point1 = new Vertex(toVector2f(p1), toColor(strokeColor));
            Vertex point2 = new Vertex(toVector2f(p2), toColor(strokeColor));
            Vertex[] points = new Vertex[2];
            points[0] = point1;
            points[1] = point2;
            window.Draw(points, PrimitiveType.Lines);
            surface.RefreshNeeded();
        }

        protected override void beginShapeImpl()
        {
            shapePoints.Clear();
        }

        protected override void endShapeImpl()
        {
            window.Draw(shapePoints);
            surface.RefreshNeeded();
            shapePoints.Clear();
        }

        protected override void addVertexImpl(PVector position)
        {   
            Vector2f shapePoint = toVector2f(position);
            shapePoints.Append(new Vertex(shapePoint, toColor(strokeColor)));
        }

        protected override void applyBackgoundColor(PColor backgroundColor)
        {
            Color background = toColor(backgroundColor);
            window.Clear(background);
        }

        public PGraphicsSFML()
        {
            surface = new PSurfaceSFML(this);
            shapePoints = new VertexArray(PrimitiveType.LineStrip);
            
        }

        public override void SetSize(int width, int height)
        {
            surface.SetSize(width, height);
        }

        public override IPSurface GetSurface()
        {    
            return surface;
        }

        public void SetWindow(RenderWindow window)
        {
            this.window = window;
        }


    }
}
