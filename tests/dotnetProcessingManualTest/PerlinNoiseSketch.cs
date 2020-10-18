using dotnetProcessing;

namespace dotnetProcessingManualTest
{   
    class PerlinNoiseSketch : Sketch
    {   

        private double start = 0;

        private double xOffset = 0;
        
        private double increment = 0.01;

        private void drawOrganicRandomCircle()
        {
            int radius = 50;
            double noiseValue = noise(xOffset);
            background(51);
            noStroke();
            fill(255, 30, 100);

            circle(radius + (float)(noiseValue * (width - radius)) , height / 2, radius);

            xOffset += increment;
            
        }

        private void drawValues()
        {
            background(51);
            stroke(255);

            double offset = start;

            beginShape();
            for (int i = 0; i < width; i++)
            {
                double noiseValue = noise(offset);

                int y = (int)height / 4 + (int)(noiseValue * height / 2f);

                vertex(i, y);
                offset += increment;

            }
            endShape();
            start += increment;
        }


        public override void Setup()
        {
            size(600, 600);
            noiseDetail(8, 0.5f);
        }
        public override void Draw()
        {
            //drawValues();
            drawOrganicRandomCircle();

        }

        

        
    }
}
