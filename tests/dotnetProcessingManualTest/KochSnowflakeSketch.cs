using dotnetProcessing;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetProcessingManualTest
{
    class Segment
    {
        public PVector a { get; }
        public PVector b { get; }

        public Segment(PVector a_, PVector b_)
        {
            a = a_.Copy();
            b = b_.Copy();
        }

        public Segment[] Generate()
        {
            Segment[] children = new Segment[4];

            PVector v = PVector.Sub(b, a);
            v.Div(3);

            // Segment 0
            PVector b1 = PVector.Add(a, v);
            children[0] = new Segment(a, b1);

            // Segment 3
            PVector a1 = PVector.Sub(b, v);
            children[3] = new Segment(a1, b);

            v.Rotate((float)-Math.PI / 3);
            PVector c = PVector.Add(b1, v);
            // Segment 2
            children[1] = new Segment(b1, c);
            // Segment 3
            children[2] = new Segment(c, a1);
            return children;
        }

        //void show()
        //{
        //    stroke(255);
        //    line(a.x, a.y, b.x, b.y);
        //}

    }
    class KochSnowflakeSketch : Sketch
    {
        private List<Segment> segments;

        private void addAll(Segment[] arr, List<Segment> list)
        {
            foreach (Segment s in arr)
            {
                list.Add(s);
            }
        }
        public override void Draw()
        {            
            background(0);         

            foreach (Segment s in segments)
            {   
                line(s.a.X, s.a.Y, s.b.X, s.b.Y);
            }
        }

        protected override void mousePressed()
        {
            List<Segment> nextGeneration = new List<Segment>();

            foreach (Segment s in segments)
            {
                Segment[] children = s.Generate();
                addAll(children, nextGeneration);
            }            
            segments = nextGeneration;
        }

        private void setupTriangle()
        {

            size(600, 800);

            translate(0, 100);
            stroke(255);
            segments = new List<Segment>();
            PVector a = new PVector(0, 100);
            PVector b = new PVector(600, 100);
            Segment s1 = new Segment(a, b);

            float len = PVector.Dist(a, b);
            float h = (float)(len * Math.Sqrt(3) / 2);
            PVector c = new PVector(300, 100 + h);

            Segment s2 = new Segment(b, c);
            Segment s3 = new Segment(c, a);
            segments.Add(s1);
            segments.Add(s2);
            segments.Add(s3);
        }


        private void setupSomething()
        {
            size(800, 800);
            stroke(0,255,255);
            int border = 150;
            segments = new List<Segment>();
            
            PVector a = new PVector(border, border);
            PVector b = new PVector(width- border, border);
            PVector c = new PVector(width- border, height- border);
            PVector d = new PVector(border, height- border);
            Segment s1 = new Segment(a, b);
            Segment s2 = new Segment(b, c);
            Segment s3 = new Segment(c, d);
            Segment s4 = new Segment(d, a);

            
            segments.Add(s1);
            segments.Add(s2);
            segments.Add(s3);
            segments.Add(s4);
        }

        public override void Setup()
        {
            //setupTriangle();
            setupSomething();
        }

    }
}
