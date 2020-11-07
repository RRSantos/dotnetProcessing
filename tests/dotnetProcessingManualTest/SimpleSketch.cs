using dotnetProcessing.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetProcessingManualTest
{
    class SimpleSketch : Sketch
    {
        public override void Draw()
        {
            title("A simple sketch 2");
            background(0, 140, 0);
            fill(100);
            rect(10, 10, 30, 40);
        }

        public override void Setup()
        {
            size(500, 500);
            title("A simple sketch");
            background(255,0,255);
            fill(255, 0 , 0);
            rect(10, 10, 30, 40);
        }
    }
}
