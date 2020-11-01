using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetProcessing.Interfaces
{
    /* IDrawable responsabilities:
     *  Draw any shape on the screen
     *  Clear screen
     */

    interface IDrawable:IDisposable
    {
        #region Shapes
        void DrawEllipse(float x, float y, float width, float height);
        

        void DrawPoint(int x, int y);
        

        void DrawCircle(float x, float y, float radius);
        

        void DrawRectangle(float x, float y, float width, float heigth);
        

        void DrawSquare(float x, float y, float sideLength);


        void DrawLine(float x1, float y1, float x2, float y2);

        void ClearShape();

        void AddShapePoint(float x, float y);

        void DrawShape();

        #endregion

        #region Stroke
        void NoStroke();

        void SetStrokeColor(float gray);

        void SetStrokeColor(float gray, byte alpha);

        void SetStrokeColor(float v1, float v2, float v3);

        void SetStrokeColor(float v1, float v2, float v3, byte alpha);

        void SetStrokeWeight(float weight);
        #endregion

        #region Fill
        void SetFillColor(float gray);

        void SetFillColor(float gray, byte alpha);

        void SetFillColor(float v1, float v2, float v3);

        void SetFillColor(float v1, float v2, float v3, byte alpha);

        void SetNoFillColor();
        #endregion

        #region Background

        void SetBackgroundColor(float gray);

        void SetBackgroundColor(float gray, byte alpha);

        void SetBackgroundColor(float v1, float v2, float v3);

        void SetBackgroundColor(float v1, float v2, float v3, byte alpha);

        #endregion

        void Display();
    }
}
