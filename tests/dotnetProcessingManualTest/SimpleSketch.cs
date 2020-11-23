using dotnetProcessing.Core;
using System;
using System.Collections.Generic;
using System.Text;


namespace dotnetProcessingManualTest
{
    class SimpleSketch : Sketch
    {
        char[] chars = new char[] { '0', '1', '2', '3', '4' };
        int counter = 0;
        bool looping = true;
        float internalAngle = 0;
        protected override void mouseClicked()
        {
            //looping = !looping;
            //if (looping)
            //    loop();
            //else
            //    noLoop();
            counter++;
        }

        public override void Draw()
        {
            //oldDraw();
            newDraw();
        }

        private void newDraw()
        {
            background(51);
            int resto = counter % 5;
            title($"Resto: {resto}");
            fill(255, 0, 255);
            stroke(190);
            if (resto == 0)
            {
                text(chars, 0, chars.Length-1, mouseX, mouseY);
            }
            else if (resto == 1)
            {
                text(chars, 2, 4, mouseX, mouseY);
            }
            else if (resto == 2)
            {
                text('C',  mouseX, mouseY);
            }
            else if (resto == 3)
            {
                text("String", mouseX, mouseY);
            }
            else if (resto == 4)
            {
                text(12345, mouseX, mouseY);
            }

        }

        private void oldDraw() 
        {
            push();
            translate(width / 2, height / 2);
            counter++;
            title($"A simple sketch. Counter: {counter}");
            background(0, 140, 0);
            fill(100);
            stroke(190);
            rect(counter, -50, 30, 40);
            pop();
            internalAngle += 0.01f;
            fill(100, 0, 255);
            rotate((float)Math.PI / 4);
            text("sou o dougras", mouseX, mouseY);
            
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
