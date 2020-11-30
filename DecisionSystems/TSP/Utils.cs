using System;
using System.Collections.Generic;
using System.Linq;



namespace DecisionSystems.TSP
{
    public static class Utils
    {
        public static double GetDistance(IReadOnlyCollection<int> solution, IReadOnlyList<Location> cities)
        {
            return solution
                .Append(solution.First())
                .Pairwise(cities.GetDistance)
                .Sum();
        }

        public static double GetDistance(Location help, Location location)
        {
            if (help is null)
            {
                throw new ArgumentNullException(nameof(help));
            }

            if (location is null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            return System.Math.Sqrt(Math.Pow((location.X - help.X), 2.00) + Math.Pow((location.Y - help.Y), 2.00));
        }
        public static double GetDistance(this IReadOnlyList<Location> cities, int cityIdx1, int cityIdx2)
        {
            return GetDistance(cities[cityIdx1 - 1], cities[cityIdx2 - 1]);
        }

    }
}