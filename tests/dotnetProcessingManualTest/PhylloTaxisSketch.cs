using dotnetProcessing;
using dotnetProcessing.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetProcessingManualTest
{
    class PhylloTaxisSketch : Sketch
    {
        float n = 0;
        const float radius = 50;
        const float ellipseRadius = 0.08f * radius;

        protected void setupPhylloTaxis()
        {
            size(600, 600);
            colorMode(ColorMode.HSB);
            noStroke();
        }

        protected void drawPhylloTaxis()
        {
            background(0, 0, .1f);
            translate(width / 2, height / 2);


            rotate(radians(n * 0.3f));
            for (int i = 0; i < n; i++)
            {
                float a = i * radians(137.5f);
                float r = (float)(radius * Math.Sqrt(radians(i)));
                float x = (float)(r * Math.Cos(a));
                float y = (float)(r * Math.Sin(a));
                float hu = (i / 3) % 360;
                fill(hu, 1, 1);
                noStroke();
                circle(x, y, ellipseRadius);
            }

            n += 5;
        }

        public override void Draw()
        {
            drawPhylloTaxis();
        }

        public override void Setup()
        {
            setupPhylloTaxis();
        }
    }
}
