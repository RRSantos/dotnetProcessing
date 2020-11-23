using dotnetProcessing.Core;
using System;
using System.Collections.Generic;
using System.Text;


namespace dotnetProcessingManualTest
{
    class TextSketch : Sketch
    {
        char[] chars = new char[] { '0', '1', '2', '3', '4' };
        int counter = 0;
        float internalTextSize = 10;
        protected override void mouseClicked()
        {   
            counter++;
            internalTextSize += 5;
        }

        public override void Draw()
        {   
            newDraw();
        }

        private void newDraw()
        {
            background(51);
            textSize(internalTextSize);
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

        public override void Setup()
        {
            size(500, 500);         
        }
    }
}
