using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    class Solver
    {
        public Solver(in Data _data)
        {
            data = _data;

            calculated_best_distance = float.MaxValue;
            calculated_best_route = new int[0];
        }

        public virtual bool run()
        {
            return false;
        }

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

        protected Data data;

        public float calculated_best_distance { set; get; }
        public int[] calculated_best_route { set; get; }
    }
}
