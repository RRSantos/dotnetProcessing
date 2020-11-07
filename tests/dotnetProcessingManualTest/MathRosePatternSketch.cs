using dotnetProcessing.Core;
using System;

namespace dotnetProcessingManualTest
{
    class MathRosePatternSketch : Sketch
    {   
        
        public override void Draw()
        {   
            
        }

        public override void Setup()
        {
            size(600, 600);
            background(10);
            translate(width/2,height/2);
            
            float n = 7f;
            float d = 8f;
            float k = n/d;
            int radius = (int)width/4;
            
            stroke(255, 0, 255);
            beginShape();
            for (float i = 0; i < 360 * d; i++)
            {
                double angleInRadians = radians(i);
                int x = (int)(radius * Math.Cos(k * angleInRadians) * Math.Cos(angleInRadians));
                int y = (int)(radius * Math.Cos(k * angleInRadians) * Math.Sin(angleInRadians));

                vertex(x, y);
            }
            endShape();
        }
    }
}
