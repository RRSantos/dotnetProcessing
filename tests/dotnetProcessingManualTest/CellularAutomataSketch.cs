using dotnetProcessing.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace dotnetProcessingManualTest
{
    class CellularAutomataSketch : Sketch
    {
        private List<int[]> history = new List<int[]>();
        private int lineSize = 80;
        private int[] actual;        
        private int cellSize;
        private int ruleNumber = 0;        
        int[] rule;

        private void drawActualRule()
        {
            rule = createRule(ruleNumber);
            clearActualLine();
            background(51);
            computeNextState();
            render();
            
            title($"rule number:{ruleNumber}");
        }

        private void clearActualLine()
        {
            for (int i = 0; i < lineSize; i++)
            {
                if (i == lineSize / 2)
                {
                    actual[i] = 1;
                }
                else
                {
                    actual[i] = 0;
                }
            }
        }


        private int[] createRule(int ruleNumber)
        {
            int[] myRule = new int[8];
            int newNumber = ruleNumber;
            for (int i = myRule.Length - 1; i >=0 ; i--)
            {
                myRule[i] = newNumber % 2;
                newNumber /= 2;
            }

            return myRule;
        }

        private int getNextState(int leftIndex, int actualIndex, int rightIndex)
        {   
            int resultIndex =  7 - (4*actual[leftIndex] + 2 * actual[actualIndex] + actual[rightIndex]);
            return rule[resultIndex];
        }

        private void computeNextState()
        {
            int maxVerticalSquaresPerScreen = (int)height / cellSize;
            history.Clear();
            for (int i = 0; i < maxVerticalSquaresPerScreen; i++)
            {
                int[] next = new int[lineSize];
                for (int j = 0; j < actual.Length; j++)
                {
                    int previousNeighborIndex = (j - 1 + lineSize) % lineSize;
                    int nextNeighborIndex = (j + 1 + lineSize) % lineSize;

                    next[j] = getNextState(previousNeighborIndex, j, nextNeighborIndex);

                }
                history.Add(actual);
                actual = next;
                
            }            
        }

        private void render()
        {
            translate(0, height- cellSize);
            stroke(130);
            for (int h = 0; h < history.Count; h++)
            {
                int[] line = history[history.Count-h-1];
                for (int i = 0; i < line.Length; i++)
                {
                    fill(255 - line[i] * 200);

                    square(i * cellSize, (-h* cellSize) % height, cellSize);
                }
            }
        }
        public override void Draw()
        {
            //drawActualRule();
            //noLoop();            
        }

        protected override void mousePressed()
        {
            if(mouseButton == LEFT)
            {
                ruleNumber++;
            }
            else if (ruleNumber > 0)
            {
                ruleNumber--;
            }
            loop();
        }

        public override void Setup()
        {
            size(800, 400);
            actual = new int[lineSize];            
            cellSize = (int)width / lineSize;
            drawActualRule();
        }        
    }
}
