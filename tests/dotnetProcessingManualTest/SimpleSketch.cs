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
            push();
            translate(width/2, height/2);
            counter++;
            title($"A simple sketch. Counter: {counter}");
            background(0, 140, 0);
            fill(100);
            stroke(190);
            rect(counter, -50, 30, 40);
            pop();
            internalAngle += 0.01f;
            fill(100, 0, 255);
            rotate((float)Math.PI/4);
            text("sou o dougras", mouseX, mouseY);
            //text(internalAngle.ToString(), 0, 0);
        }

        private void testFont() 
        {
            
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
