using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetProcessing
{
    class PerlinNoise
    {
        private const int DEFAULT_SAMPLES = 4096;
        private const int DEFAULT_OCTAVES = 4;
        private const int DEFAULT_SEED = -1;
        private const double DEFAULT_FALLOFF_FACTOR = 0.5f;

        private readonly int octaves;
        private readonly int samples;
        private readonly int seed;
        private readonly double falloffFactor;

        private double[] gridDouble;

        private double smoothStep(double t)
        {
            return t * t * t * (t * (t * 6d - 15d) + 10d);
        }

        private void prepareGrid()
        {
            Random rand;
            if (seed == -1)
            {
                rand = new Random();
            }
            else
            {
                rand = new Random(seed);
            }
             
            gridDouble = new double[samples];
            for (int i = 0; i < gridDouble.Length; i++)
            {
                gridDouble[i] = rand.NextDouble();
            }
        }

        public PerlinNoise() : this(DEFAULT_SAMPLES, DEFAULT_OCTAVES, DEFAULT_SEED, DEFAULT_FALLOFF_FACTOR)
        {

        }

        public PerlinNoise(int samples, int octaves, int seed, double falloffFactor)
        {
            this.octaves = octaves;
            this.samples = samples;
            this.seed = seed;
            this.falloffFactor = falloffFactor;
            prepareGrid();
        }

        public double GetNoiseAt(double x)
        {
            while (x > gridDouble.Length)
            {
                x -= gridDouble.Length;
            }
            int floorIndex = (int)x;
            double offsetFromIndex = x - floorIndex;
            double result = 0;
            double amplitude = 1d;
            double amplitudeAccumulated = 0;

            for (int i = 0; i < octaves; i++)
            {
                int actualIndex = floorIndex;
                double smooth = smoothStep(offsetFromIndex);
                double sample1 = gridDouble[actualIndex % gridDouble.Length];
                double sample2 = gridDouble[(actualIndex + 1) % gridDouble.Length];
                double n = sample1 + smooth * (sample2 - sample1);

                result += n * amplitude;

                amplitudeAccumulated += amplitude;
                amplitude *= falloffFactor;
                floorIndex <<= 1;
                offsetFromIndex *= 2;

                if (offsetFromIndex >= 1.0)
                {
                    floorIndex++;
                    offsetFromIndex--;
                }
            }

            result /= amplitudeAccumulated;
            return result;
        }

        public int GetOctaves() { return octaves; }
        public int GetSamples() { return samples; }
        public int GetSeed() { return seed; }
        public double GetFalloffFactor() { return falloffFactor; }

    }
}
