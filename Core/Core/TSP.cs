using System;
using System.Collections.Generic;

namespace Core
{
    class TSP
    {
        static void Main(string[] args)
        {
            const string input_file = "../../../../Data/a280.tsp";
            Data data = new Data(input_file);
            Solver solver = new GreedyAlgorithm(in data);

            bool is_solved = solver.run();

            if(is_solved)
            {
                int[] calculated_best_route = solver.calculated_best_route;
                Console.Write("Calculated Best Route   : [ ");
                foreach(int element in calculated_best_route)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine("]");
                Console.WriteLine("Calculated Best Distance: " + solver.calculated_best_distance);
            }
        }
    }
}
