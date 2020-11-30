using System.Collections.Generic;
using System.Linq;

namespace DecisionSystems.TSP.Solver
{
    public class BranchAndBoundTSPSolver : ITSPSolver
    {
        public List<int> Solve(IReadOnlyList<Location> cities)
        {
            var permutations = CalculatePermutations(cities);
            return permutations.BestBy(tour => Utils.GetDistance(tour, cities), (v1, v2) => v1 < v2).ToList();
        }

        private List<int[]> CalculatePermutations(IReadOnlyList<Location> cities)
        {
            var result = new List<int[]>();
            var baseTour = Enumerable.Range(1, cities.Count).ToArray();
            double bestDistance = double.MaxValue;

            void CalculatePermutationsRecursive(int[] baseTour, int startIndex, double currentDistance)
            {
                if (startIndex == baseTour.Length - 1)
                {

                    result.Add(baseTour.ToArray());
                }
                else
                {
                    //Calculate permutations by placing baseTour[startIndex] at every possible index
                    //and then calculate permutations of elements with idex > startIndex.
                    for (int i = startIndex; i < baseTour.Length; i++)
                    {
                        baseTour.Swap(startIndex, i);
                        var nextSegmentDistance = cities.GetDistance(baseTour[startIndex - 1], baseTour[startIndex]);
                        if(currentDistance + nextSegmentDistance < bestDistance)
                        {
                            CalculatePermutationsRecursive(baseTour, startIndex+1,currentDistance+nextSegmentDistance);
                        }
                        baseTour.Swap(startIndex, i);
                    }

                }
            }
            CalculatePermutationsRecursive(baseTour, 1, 0);
            return result;
        }



    }
}