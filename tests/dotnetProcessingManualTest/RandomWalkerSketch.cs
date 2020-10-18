using dotnetProcessing;

namespace dotnetProcessingManualTest
{
    class RandomWalkerSketch : Sketch
    {
        private int x = 0;
        private int y = 0;
        private int internal_radius = 10;

        private void drawRandomWalker()
        {
            stroke(255, 100);
            strokeWeight(internal_radius);
            
            point(x, y);
            int r = (int)random(4);
            switch (r)
            {
                case 0:
                    x += internal_radius;
                    break;
                case 1:
                    x -= internal_radius;
                    break;
                case 2:
                    y += internal_radius;
                    break;
                case 3:
                    y -= internal_radius;
                    break;
                     
            }
        }
        public override void Draw()
        {
            drawRandomWalker();
        }

        public override void Setup()
        {
            size(600, 600);
            background(0);
            translate(width / 2, height / 2);
            
            stroke(255, 0, 255);
            strokeWeight(internal_radius);
            point(x, y);
        }

    }
}
