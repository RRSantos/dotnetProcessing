using dotnetProcessing;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace dotnetProcessingManualTest
{

    class PerlinNoise1D
    {
        private const int gridSize = 100;
        private int[] grid;

        private double smoothStep(double t)
        {
            //return t * t * (3.0 - 2.0 * t);
            return t * t * t * (t * (t * 6d - 15d) + 10d);
                //t * t * t * (10 - 15 *t + 6*t*t);

            
        }

        public double GetPerlinNoiseAt(double x)
        {
            if (x > grid.Length)
            {
                x -= grid.Length;
            }
                

            int beforeX = (int)x % grid.Length;
            int afterX = (beforeX + 1) % grid.Length;
            double distance = x - beforeX;

            int beforeXInGrid = grid[beforeX];
            int afterXInGrid = grid[afterX];

            double loPos = beforeXInGrid * distance;
            double hiPos = -afterXInGrid * (1 -distance);

            double smooth = smoothStep(distance);

            return (loPos * (1 - smooth)) + (hiPos * smooth);
        }

        public PerlinNoise1D():this(1024)
        {

        }

        public PerlinNoise1D(int samples)
        {
            Random rand = new Random(0);
            grid = new int[samples];
            for (int i = 0; i < grid.Length; i++)
            {
                grid[i] = rand.Next(-1, 2);
            }
        }
    }
    class PerlinNoiseSketch : Sketch
    {
        Random rand = new Random();

        PerlinNoise1D noise = new PerlinNoise1D(100);

        private double start = 0;
        private double increment = 0.01;
        
        public override void Draw()
        {
            background(51);
            stroke(255);

            double xOffSet = start;
            beginShape();
            for (int i = 0; i < width; i++)
            {
                //int y = rand.Next((int)height)    ;
                int y = (int)(noise.GetPerlinNoiseAt(xOffSet) * height + height / 2);
                if (xOffSet >= 100)
                {
                    stroke(255, 0, 255);
                }
                vertex(i, y);
                xOffSet += increment;
            }
            endShape();
            start += increment;




        }

        public override void Setup()
        {
            
            size(600, 600);
            //background(51);
            //stroke(255);
            //beginShape();
            //double xOffSet = 99;
            //for (int i = 0; i < width; i++)
            //{
            //    //int y = rand.Next((int)height);
            //    int y = (int)(noise.GetPerlinNoiseAt(xOffSet)*height + height / 2) ;
            //    if ( xOffSet>= 100)
            //    {
            //        stroke(255, 0 , 255);
            //    }
            //    vertex(i, y);
            //    xOffSet += .01d;
            //}
            //endShape();
            

            
        }
    }
}
