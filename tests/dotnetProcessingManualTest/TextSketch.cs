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
            //newDraw2();
            newDraw3();
        }

        private void newDraw3()
        {
            background(51);

            stroke(180);
            fill(200, 0, 100);
            
            textSize(16);
            textAlign(RIGHT);
            text("ABCD", 50, 10);
            textAlign(CENTER);
            text("EFGH", 50, 30);
            textAlign(LEFT);
            text("IJKL", 50, 50);


            fill(100, 0, 200);
            stroke(100, 0, 200);
            textSize(20);
            textAlign(LEFT, BOTTOM);
            line(0, 100, width, 100);
            text("LEFT,BOTTOM", 50, 100);
            textAlign(LEFT, CENTER);
            line(0, 150, width, 150);
            text("LEFT,CENTER", 50, 150);
            textAlign(LEFT, TOP);
            line(0, 170, width, 170);
            text("LEFT,TOP", 50, 170);


            String lines = "L1\nL2\nL3";
            textSize(12);
            fill(0);

            textLeading(10);  // Set leading to 10
            text(lines, 100, 200);

            textLeading(20);  // Set leading to 20
            text(lines, 150, 200);

            textLeading(30);  // Set leading to 30
            text(lines, 200, 200);

            textSize(15);
            text(lines, 250, 200);

            
            float wbase = height * 0.75f;
            float scalar = 1f; // Different for each font

            textAlign(LEFT, BOTTOM);
            textSize(32);  // Set initial text size
            float a = textAscent() * scalar;  // Calc ascent
            stroke(0, 0, 255);
            line(0, wbase - a, width, wbase - a);
            text("Tdp1É", 0, wbase);  // Draw text on baseline

            textAlign(LEFT, CENTER);
            //textSize(64);  // Increase text size
            a = textAscent() * scalar;  // Recalc ascent
            stroke(255, 0, 0);
            line(150, wbase - a, width, wbase - a);
            text("tdp2É", 150, wbase);  // Draw text on baseline


            textAlign(LEFT, TOP);
            //textSize(64);  // Increase text size
            a = textAscent() * scalar;  // Recalc ascent
            stroke(0, 255, 0);
            line(300, wbase - a, width, wbase - a);
            text("tdp3É", 300, wbase);  // Draw text on baseline


            textAlign(LEFT, BOTTOM);
            textSize(64);  // Increase text size
            a = textDescent() * scalar;  // Recalc ascent
            stroke(255, 0, 255);
            line(400, wbase - a, width, wbase - a);
            text("tdp64", 400, wbase);  // Draw text on baseline            
        }

        private void newDraw2()
        {
            background(51);

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
