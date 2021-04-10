using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    class GreedyAlgorithm : Solver
    {
        public GreedyAlgorithm(in Data data) : base(in data)
        {

        }

        public override bool run()
        {
            int num_cities = data.num_of_cities;
            int[] route = new int[num_cities];
            route[0] = 0;

            var remain_cities = new List<int>();
            for(int i=1; i<num_cities; ++i)
            {
                remain_cities.Add(i);
            }

            for(int current_city_index=0; current_city_index<num_cities-1; ++current_city_index)
            {
                float min_distance = float.MaxValue;
                int min_distance_city = 0;

                foreach(int remain_city in remain_cities)
                {
                    float current_distance = data.getDistance(route[current_city_index], remain_city);
                    if (current_distance < min_distance)
                    {
                        min_distance = current_distance;
                        min_distance_city = remain_city;
                    }
                }

                route[current_city_index + 1] = min_distance_city;
                remain_cities.Remove(min_distance_city);
            }

            calculated_best_route = route;
            calculated_best_distance = calculateRouteDistance(route);

            return true;
        }
    }
}
