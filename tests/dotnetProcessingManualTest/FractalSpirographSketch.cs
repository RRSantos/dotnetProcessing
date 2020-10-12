using dotnetProcessing;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace dotnetProcessingManualTest
{
    class FractalSpirographSketch : Sketch
    {
        public override void Draw()
        {
            //throw new NotImplementedException();
        }

        public override void Setup()
        {
            size(800, 800);
            background(0);
            translate(width / 2, height / 2);
            stroke(0, 255, 50);
            strokeWeight(2);
            noFill();
            
            float radius = width / 8;
            //circle(0, 0, radius);

            ellipse(0, 0, radius, 2*radius);
            //throw new NotImplementedException();
        }
    }
}
