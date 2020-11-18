using dotnetProcessing.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetProcessingManualTest
{
    class SimpleSketch : Sketch
    {
        int counter = 0;
        bool looping = true;
        float internalAngle = 0;
        protected override void mouseClicked()
        {
            looping = !looping;
            if (looping)
                loop();
            else
                noLoop();
        }
        
        public override void Draw()
        {
            counter++;
            title($"A simple sketch. Counter: {counter}");
            background(0, 140, 0);
            fill(100);
            stroke(190);
            rect(10+ counter, 10, 30, 40);
            internalAngle += 0.1f;
            //rotate(internalAngle);
            fill(100,0,255);
            text(internalAngle.ToString(), 100, 100);
        }

        public override void Setup()
        {
            size(500, 500);
            //title("A simple sketch");
            //background(255,0,255);
            //fill(255, 0 , 0);
            //rect(10, 10, 30, 40);
        }
    }
}
