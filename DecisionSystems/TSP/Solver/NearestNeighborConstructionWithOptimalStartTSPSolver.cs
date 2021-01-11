using System.Collections.Generic;
using System.Linq;

namespace DecisionSystems.TSP.Solver
{
    public class NearestNeighborConstructionWithOptimalStartTSPSolver : ITSPSolver
    {
        public List<int> Solve(IReadOnlyList<Location> cities)
        {
            var besttour = SolveWithStartCity(cities, 1);
            var minDistance = Utils.GetDistance(besttour, cities);
            for (var startCity = 2; startCity <= cities.Count; startCity++)
            {
                var tour=  SolveWithStartCity(cities, startCity);
                var distance = Utils.GetDistance(tour, cities);
                if(distance < minDistance)
                {
                    minDistance = distance;
                    besttour = tour;
                }
            }
            return besttour;
        }

        private static List<int> SolveWithStartCity(IReadOnlyList<Location> cities, int startCity)
        {
            var result = Enumerable.Range(1, cities.Count).ToList();
            result.Swap(0, startCity - 1);
            for (int i = 1; i < result.Count; i++)
            {
                var minDistance = cities.GetDistance(result[i - 1], result[i]);
                var next = i;
                //Index der nähesten Stadt zur Stadt 'result[i-1]' suchen
                for (int j = i + 1; j < result.Count; j++)
                {
                    var distance = cities.GetDistance(result[j], result[i - 1]);
                    if (minDistance > distance)
                    {
                        minDistance = distance;
                        next = j;
                    }
                }
                result.Swap(i, next);
            }
            return result;
        }
    }
}