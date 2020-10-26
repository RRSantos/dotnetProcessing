using dotnetProcessing;
using System;

namespace dotnetProcessingManualTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Sketch sketch = new FractalTreesSketch();
            sketch.Run();
        }
    }
}
