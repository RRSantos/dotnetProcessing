using dotnetProcessing.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnetProcessingManualTest
{
    class Program
    {   
        private static SketchHelper helper = new SketchHelper();
        private static void showMenu()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("\n         dotnetProcessing manual tests\n");
            Console.WriteLine("----------------------------------------------------------\n\n");

            Console.WriteLine("Menu");
            var availableOptions = helper.GetAvaliableOptions().ToList();
            for (int i = 1; i < availableOptions.Count; i++)
            {   
                Console.WriteLine($"{i:00} - {availableOptions[i]}");
            }

            Console.WriteLine($"{0:00} - {availableOptions[0]}");
        }

        private static int showMenuAndGetUserChoice()
        {
            bool isValidChoice = false;
            int option = 0;
            int maxOptionCount = helper.GetAvaliableOptions().Count;
            while (!isValidChoice)
            {
                showMenu();
                Console.Write("\nChoose an option: ");
                string userInput = Console.ReadLine();
                isValidChoice = int.TryParse(userInput, out option);
                isValidChoice = isValidChoice && (option >= 0 && option < maxOptionCount);

                if (!isValidChoice)
                {
                    Console.WriteLine($"\nInvalid option: {userInput}");
                }
            }
            return option;            
            
        }
        static void Main(string[] args)
        {   
            
            Sketch sketch;
            do
            {
                int userChoice = showMenuAndGetUserChoice();
                sketch = helper.GetSketchByOption(userChoice);
                if (sketch != null)
                {
                    sketch.Run();
                }
            } while (sketch != null);
            
            
        }
    }

    class SketchHelper
    {
        private readonly List<string> avaliableOptions = new List<string>();

        private void initializeInternalFields()
        {
            avaliableOptions.Add("Exit");
            avaliableOptions.Add("Cellular automata");
            avaliableOptions.Add("Chaos game");
            avaliableOptions.Add("Fractal spirograph");
            avaliableOptions.Add("Fractal tree");
            avaliableOptions.Add("Koch snowflake");
            avaliableOptions.Add("Math rose pattern");
            avaliableOptions.Add("Perlin noise");
            avaliableOptions.Add("Phyllotaxis");
            avaliableOptions.Add("Random walker");
            avaliableOptions.Add("Simple sketch");
            
        }

        public SketchHelper()
        {
            initializeInternalFields();
        }

        public Sketch GetSketchByOption(int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    return new CellularAutomataSketch();
                case 2:
                    return new ChaosGameSketch();
                case 3:
                    return new FractalSpirographSketch();
                case 4:
                    return new FractalTreesSketch();
                case 5:
                    return new KochSnowflakeSketch();
                case 6:
                    return new MathRosePatternSketch();
                case 7:
                    return new PerlinNoiseSketch();
                case 8:
                    return new PhylloTaxisSketch();
                case 9:
                    return new RandomWalkerSketch();
                case 10:
                    return new SimpleSketch();
                default:
                    return null;
            }
        }

        public IReadOnlyCollection<string> GetAvaliableOptions()
        {
            return avaliableOptions.AsReadOnly();
        }

    }
}
