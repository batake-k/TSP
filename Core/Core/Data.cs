using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    class Data
    {
        public Data(in string input_file)
        {
            num_cities = 4;
            distances = new float[4, 4] {
                { 0.00f, 1.00f, 1.41f, 1.00f},
                { 1.00f, 0.00f, 1.00f, 1.41f},
                { 1.41f, 1.00f, 0.00f, 1.00f},
                { 1.00f, 1.41f, 1.00f, 0.00f},
            };
        }

        public float getDistance(int i, int j)
        {
            return distances[i,j];
        }

        public int num_cities {set; get;}
        private float[,] distances;
    }
}
