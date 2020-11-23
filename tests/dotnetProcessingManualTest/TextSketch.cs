using dotnetProcessing.Core;
using System;
using System.Collections.Generic;
using System.Text;


namespace dotnetProcessingManualTest
{
    class TextSketch : Sketch
    {
        char[] chars = new char[] { '0', '1', '2', '3', '4' };
        string meutexto = "AMAPAMMM-.XI";
        int counter = 0;
        float internalTextSize = 10;
        float textAngle = 0f;
        protected override void mouseClicked()
        {   
            counter++;
            internalTextSize += 5;
        }

        public override void Draw()
        {   
            //newDraw();
            newDraw2();
        }

        private void newDraw2()
        {
            background(51);
            translate(width / 2, height / 2);

            int resto = counter % 9;


            if (resto == 0)
            {
                textAlign(LEFT, BOTTOM);
            }
            else if (resto == 1)
            {
                textAlign(CENTER, BOTTOM);
            }
            else if (resto == 2)
            {
                textAlign(RIGHT, BOTTOM);
            }
            else if (resto == 3)
            {
                textAlign(LEFT, CENTER);
            }
            else if (resto == 4)
            {
                textAlign(CENTER, CENTER);
            }
            else if (resto == 5)
            {
                textAlign(RIGHT, CENTER);
            }
            else if (resto == 6)
            {
                textAlign(LEFT, TOP);
            }
            else if (resto == 7)
            {
                textAlign(CENTER, TOP);
            }
            else if (resto == 8)
            {
                textAlign(RIGHT, TOP);
            }

            fill(255, 0, 255);
            stroke(200,0,0);
            //rotate(textAngle);
            textSize(20);
            strokeWeight(1);
            text($"Meu texgq,!ÃÉ. {resto}", 5, 5);
            line(5, 5, 50, 5);
            line(5, 5, 5, 40);
            textAngle += 0.01f;

            text(meutexto, 10, 100);
            stroke(0, 255, 10);
            line(10, 100, 10, 140);
            line(10+ textWidth(meutexto), 100, 10+ textWidth(meutexto), 140);



        }

        private void newDraw()
        {
            background(51);
            textSize(internalTextSize);
            int resto = counter % 6;
            title($"Resto: {resto}");
            fill(255, 0, 255);
            stroke(190);
            if (resto == 0)
            {
                text(chars, 0, chars.Length - 1, mouseX, mouseY);
            }
            else if (resto == 1)
            {
                text(chars, 2, 4, mouseX, mouseY);
            }
            else if (resto == 2)
            {
                text('C', mouseX, mouseY);
            }
            else if (resto == 3)
            {
                text("String", mouseX, mouseY);
            }
            else if (resto == 4)
            {
                text(12345, mouseX, mouseY);
            }
            else if (resto == 5)
            {
                textSize(30);
                text("Meu texto", 100, 100);
            }

        }

        public override void Setup()
        {
            size(500, 500);         
        }
    }
}
