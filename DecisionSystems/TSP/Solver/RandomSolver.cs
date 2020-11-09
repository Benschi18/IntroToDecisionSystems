using System;
using System.Collections.Generic;
using System.Linq;

namespace DecisionSystems.TSP.Solver
{
    public class RandomSolver : ITSPSolver
    {
        private readonly int iterations;

        public RandomSolver(int iterations)
        {
            if(iterations < 1)
            {
                throw new ArgumentException("Iterations must be >= 1");
            }
            this.iterations = iterations;
        }

        public List<int> Solve(IReadOnlyList<Location> cities)
        {
            //var result = new List<int>();
            ////1. Create a list from 1...n
            //var remaining = Enumerable.Range(1, cities.Count).ToList();
            //var numbergenerator = new Random();

            //while (remaining.Count > 0)
            //{
            //    //2. Randomly select a number and add to resulting list
            //    var index = numbergenerator.Next(0, remaining.Count);
            //    result.Add(remaining[index]);
            //    //3. Remove Selected number and go to 2. until list is empty
            //    remaining.RemoveAt(index);
            //}
            //return result;
            return Enumerable.Range(1, cities.Count).Shuffle().ToList();
        }
    }
}