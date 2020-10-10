using dotnetProcessing;
using dotnetProcessing.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetProcessingManualTest
{
    class MySketch : Sketch
    {   
        float n = 0;
        const float radius = 40;
        float ellipseRadius= 0.08f * radius;
        public override void Draw()
        {
            background(0,0,.3f);
            translate(width/2, height/2);


            ///rotate(n * 0.3);
            for (int i = 0; i < n; i++)
            {
                float a = i * radians(137.5f);
                float r = (float)(radius * Math.Sqrt(radians(i)));
                float x = (float)(r * Math.Cos(a));
                float y = (float)(r * Math.Sin(a));
                float hu = (i / 3) % 360;
                fill(hu, 1, 1);
                noStroke();
                ellipse(x, y, ellipseRadius, ellipseRadius);
            }
            
            n+=5;
        }

        public override void Setup()
        {
            size(800, 600);
            colorMode(ColorMode.HSB);

            
        }
    }
}
