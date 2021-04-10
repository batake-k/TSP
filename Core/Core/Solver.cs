using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    abstract class Solver
    {
        protected Data data;
        public float calculated_best_distance { set; get; } = float.MaxValue;
        public int[] calculated_best_route { set; get; } = new int[0];

        public Solver(in Data _data)
        {
            data = _data;
        }

        public abstract bool run();

        protected float calculateRouteDistance(in int[] route)
        {
            float distance = 0;
            for(int i = 0; i < route.Length - 1; i++)
            {
                distance += data.getDistance(route[i], route[i + 1]);
            }
            distance += data.getDistance(route[route.Length - 1], 0);

            return distance;
        }
    }
}
