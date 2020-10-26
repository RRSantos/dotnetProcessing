using dotnetProcessing;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace dotnetProcessingManualTest
{
    class FractalTreesSketch : Sketch
    {
        float len = 150;
        float angle = 0f;
        float decay = 0.67f;
        

        public override void Draw()
        {
            background(51);
            translate(width / 2f, height);
            branch(len);
            angle += 0.01f;
        }

        public override void Setup()
        {   
            size(600, 600);
            background(51);            
        }

        protected void branch(float length)
        {
            stroke(0,255,255);
            line(0, 0, 0, -length);
            translate(0, -length);

            if (length > 4)
            {
                push();
                rotate(angle);                
                branch(length * decay);
                pop();

                push();
                rotate(-angle);
                branch(length * decay);
                pop();
            }
        }
    }
}
