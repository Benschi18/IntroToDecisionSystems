﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DecisionSystems.TSP.Solver
{
    public class BacktrackingTSPSolver : ITSPSolver
    {
        public List<int> Solve(IReadOnlyList<Location> cities)
        {
            var permutations = CalculatePermutations(cities);
            return permutations.MinBy(solution => Utils.GetDistance(solution, cities));
        }

        private List<int[]> CalculatePermutations(IReadOnlyList<Location> cities)
        {
            var result = new List<int[]>();
            var baseTour = Enumerable.Range(1, cities.Count).ToArray();
            CalculatePermutationsRecursive(baseTour, 1, result);
        }

        private void CalculatePermutationsRecursive(int[] baseTour, int startIndex, List<int[]> result)
        {
            if (startIndex == baseTour.Length - 1) result.Add(baseTour.ToArray());
            else
            {
                //Calculate permutations by placing baseTour[startIndex] at every possible index
                //and then calculate permutations of elements with idex > startIndex.
                for (int i = startIndex; i < baseTour.Length; i++)
                {
                    Swap(baseTour, startIndex, i);
                    CalculatePermutationsRecursive(baseTour, startIndex++, result);
                    Swap(baseTour, startIndex, i);
                }

            }
        }

        public static void Swap<T>(T[] items, int idx1, int idx2)
        {
            //T item1 = items[idx1];
            //items[idx1] = items[idx2];
            //items[idx2] = item1;

            (items[idx1], items[idx2]) = (items[idx2], items[idx1]);
        }
    }
}