﻿using dotnetProcessing.Core;
//using dotnetProcessing.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;


namespace dotnetProcessingManualTest
{
    class ChaosGameSketch : Sketch
    {   
        
        //Poligono
        List<Point> points = new List<Point>();
        Random  internalRandom = new Random();
        Point lastPoint;
        int pointRadius = 3;
        double distanceFactor = 1/2d;
        int vertexCount = 8;

        private void setColorBasedOnIndex(int index)
        {
            if (index == 0)
            {
                fill(255, 0, 0);
                stroke(255, 0, 0);
            }
            else if (index == 1)
            {
                fill(0, 255, 0);
                stroke(0, 255, 0);
            }
            else if (index == 2)
            {
                fill(0, 0, 255);
                stroke(0, 0, 255);
            }
            else if (index == 3)
            {
                fill(255, 255, 0);
                stroke(255, 255, 0);
            }
            else if (index == 4)
            {
                fill(255, 0, 255);
                stroke(255, 0, 255);
            }
            else if (index == 5)
            {
                fill(0, 255, 255);
                stroke(0, 255, 255);
            }
        }

        public override void Setup()
        {
            
            title("teste do ramos");
            //setupPoligonoRegular();            
            setupChaosGameSquare();

        }        

        public override void Draw()
        {
            //drawPoligonoRegular();            
            drawChaosGameSquare();

        }

        private void drawChaosGameSquare()
        {
            translate(width / 2, height / 2);
            int lastIndex = internalRandom.Next(points.Count);
            for (int i = 0; i < 500; i++)
            {
                int signal = Math.Sign(internalRandom.Next(points.Count) - internalRandom.Next(points.Count));
                int nextIndex = (lastIndex + signal + points.Count) % points.Count; 

                lastIndex = nextIndex;
                Point randomVertex = points[nextIndex];
                double xDiff = randomVertex.X + lastPoint.X;
                double yDiff = randomVertex.Y + lastPoint.Y;

                lastPoint.X = (int)(xDiff * distanceFactor);
                lastPoint.Y = (int)(yDiff * distanceFactor);

                
                fill(0, 150, 255,100);
                stroke(0, 150, 255,100);
                point(lastPoint.X, lastPoint.Y);
            }
        }

        private void setupChaosGameSquare()
        {   
            distanceFactor = 0.5d;
            vertexCount = 7;
            setupPoligonoRegular();
        }

        private void drawPoligonoRegular()
        {
            translate(width / 2, height / 2);
            for (int i = 0; i < 500; i++)
            {
                int nextIndex = internalRandom.Next(points.Count);

                Point randomVertex = points[nextIndex];
                double xDiff = randomVertex.X + lastPoint.X;
                double yDiff = randomVertex.Y + lastPoint.Y;

                lastPoint.X = (int)(xDiff * distanceFactor);
                lastPoint.Y = (int)(yDiff * distanceFactor);

                setColorBasedOnIndex(nextIndex);
                point(lastPoint.X, lastPoint.Y);
            }
        }

        

        private void setupPoligonoRegular()
        {
            size(800, 800);
            colorMode(ColorMode.RGB);

            translate(width / 2, height / 2);
            float angle;
            if (vertexCount % 2 == 1)
            {
                angle = (360f / vertexCount) - 90;
            }
            else
            {
                angle = (180 - (360f / vertexCount))/2f;
            }
            rotate(radians(angle));
            double angleOffset = 2 * Math.PI / vertexCount;
            double initialAngle = 0;
            double radius = (width / 2d) - 10;
            for (int i = 0; i < vertexCount; i++)
            {

                int newX = (int)(radius * Math.Cos(initialAngle));
                int newY = (int)(radius * Math.Sin(initialAngle));


                points.Add(new Point(newX, newY));

                initialAngle += angleOffset;
            }
            

            for (int i = 0; i < points.Count; i++)
            {
                setColorBasedOnIndex(i);
                circle(points[i].X, points[i].Y, pointRadius);

            }


            int randomX = internalRandom.Next((int)width);
            int randomY = internalRandom.Next((int)height);
            lastPoint = new Point(randomX, randomY);
            fill(255, 0, 255);
            stroke(255, 0, 255);
            circle(lastPoint.X, lastPoint.Y, pointRadius);
        }        
    }
}
