using dotnetProcessing.Core;

namespace dotnetProcessingManualTest
{
    class EventsSketch : Sketch
    {
        string tecla;
        byte red = 255;
        byte green = 255;
        byte blue = 255;
        public override void Draw()
        {
            title($"Última tecla pressionada: {tecla}");
            background(red, green, blue);            
        }

        protected override void keyPressed()
        {
            if (key != CODED)
            {
                if (key == ESC)
                {
                    tecla = "ESC";
                }
                else if (key == BACKSPACE)
                {
                    tecla = "BACKSPACE";
                }
                else if (key == TAB)
                {
                    tecla = "TAB";
                }
                else if (key == ENTER)
                {
                    tecla = "ENTER";
                }
                else if (key == DELETE)
                {
                    tecla = "DELETE";
                }
                else 
                {
                    tecla = key.ToString();
                }
            }
            else
            {
                if (keyCode == UP)
                {
                    tecla = "UP";
                }
                else if (keyCode == DOWN)
                {
                    tecla = "DOWN";
                }
                else if (keyCode == LEFT)
                {
                    tecla = "LEFT";
                }
                else if (keyCode == RIGHT)
                {
                    tecla = "RIGHT";
                }
                else if (keyCode == ALT)
                {
                    tecla = "ALT";
                    red = 120;
                }
                else if (keyCode == CONTROL)
                {
                    tecla = "CONTROL";
                    green = 120;
                }
                else if (keyCode == SHIFT)
                {
                    tecla = "SHIFT";
                    blue = 120;
                }
            }
            
        }

        protected override void keyReleased()
        {
            red = 255;
            green = 255;
            blue = 255;
        }

        public override void Setup()
        {
            size(600, 600);
            background(51);
        }
    }
}
