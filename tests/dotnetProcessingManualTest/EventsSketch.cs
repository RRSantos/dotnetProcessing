using dotnetProcessing.Core;

namespace dotnetProcessingManualTest
{
    class EventsSketch : Sketch
    {
        string tecla; 
        public override void Draw()
        {
            title($"Última tecla pressionada: {tecla}");
            if (keyCode == ALT)
            {             
                background(0, 0, 100);
            }
            else if (keyCode == CONTROL)
            {
             
                background(0, 100, 0);
            }
            else if (keyCode == SHIFT)
            {
                background(100, 0, 0);
            }
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
                    background(0, 0, 100);
                }
                else if (keyCode == CONTROL)
                {
                    tecla = "CONTROL";
                    background(0, 100, 0);
                }
                else if (keyCode == SHIFT)
                {
                    tecla = "SHIFT";
                    background(100, 0, 0);
                }
            }

            
        }

        public override void Setup()
        {
            size(600, 600);
            background(51);
        }
    }
}
