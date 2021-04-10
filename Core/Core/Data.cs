using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    class Data
    {
        private string input_file;
        public int num_of_cities { set; get; }
        private (float, float)[] coordinates_of_cities;
        private float[,] distances;

        public Data(in string _input_file)
        {
            input_file = _input_file;
            readInputFile();
            calcDistances();
            writeInfo();
        }

        private void readInputFile()
        {
            StreamReader sr = new StreamReader(input_file);

            string line = "";
            while(sr.Peek() != -1)
            {
                line = sr.ReadLine();
                string[] words = line.Split(' ');

                if(words[0] == "DIMENSION:" || words[0] == "DIMENSION")
                {
                    num_of_cities = int.Parse(words[words.Length-1]);
                }
                else if(words[0] == "EDGE_WEIGHT_TYPE:" || words[0] == "EDGE_WEIGHT_TYPE")
                {
                    if(words[words.Length-1] != "EUC_2D" && words[words.Length-1] != "CEIL_2D")
                    {
                        Console.WriteLine("[ERROR] only supports EDGE_WEIGHT_TYPE of EUC_2D or CEIL_2D");
                        Environment.Exit(0);
                    }
                }
                else if(words[0] == "NODE_COORD_SECTION" || words[0] == "DISPLAY_DATA_SECTION")
                {
                    break;
                }
            }

            coordinates_of_cities = new (float, float)[num_of_cities];

            for(int i=0; i<num_of_cities; ++i)
            {
                int city_number = int.MaxValue;
                float x = float.MaxValue, y = float.MaxValue;

                line = sr.ReadLine();
                string[] words = line.Split(' ');

                foreach(string word in words)
                {
                    if(word == "")
                    {

                    }
                    else if(word != "" && city_number == int.MaxValue)
                    {
                        city_number = int.Parse(word);
                    }
                    else if(word != "" && x == float.MaxValue)
                    {
                        x = float.Parse(word);
                    }
                    else if(word != "" && y == float.MaxValue)
                    {
                        y = float.Parse(word);
                    }
                    else
                    {

                    }
                }
                coordinates_of_cities[i] = (x, y);
            }

            /*
            num_of_cities = 4;

            coordinates_of_cities = new(int, int)[]
            {
                (0,0),
                (1,0),
                (1,1),
                (0,1)
            };
            */
        }

        private void calcDistances()
        {
            distances = new float[num_of_cities, num_of_cities];

            for(int i=0; i<num_of_cities; ++i)
            {
                for(int j=0; j<num_of_cities; ++j)
                {
                    float diff_x = coordinates_of_cities[i].Item1 - coordinates_of_cities[j].Item1;
                    float diff_y = coordinates_of_cities[i].Item2 - coordinates_of_cities[j].Item2;
                    double distance = Math.Sqrt(diff_x * diff_x + diff_y * diff_y);

                    distances[i, j] = (float)distance;
                }
            }

            /*
            distances = new float[4, 4]
            {
                { 0.00f, 1.00f, 1.41f, 1.00f},
                { 1.00f, 0.00f, 1.00f, 1.41f},
                { 1.41f, 1.00f, 0.00f, 1.00f},
                { 1.00f, 1.41f, 1.00f, 0.00f},
            };
            */
        }

        private void writeInfo()
        {
            Console.WriteLine("input file: " + input_file);
            Console.WriteLine("number of cities: " + num_of_cities + "\n");
            Console.WriteLine("coordinates of cities:");

            if(num_of_cities <= 10)
            {
                for(int i=0; i<num_of_cities; ++i)
                {
                    Console.WriteLine(i + "\t" + coordinates_of_cities[i].Item1 + "\t" + coordinates_of_cities[i].Item2);
                }
            }
            else
            {
                for(int i=0; i<2; ++i)
                {
                    Console.WriteLine(i + "\t" + coordinates_of_cities[i].Item1 + "\t" + coordinates_of_cities[i].Item2);
                }
                Console.WriteLine("...");
                for (int i = coordinates_of_cities.Length-2; i < coordinates_of_cities.Length; ++i)
                {
                    Console.WriteLine(i + "\t" + coordinates_of_cities[i].Item1 + "\t" + coordinates_of_cities[i].Item2);
                }
            }
            Console.WriteLine();
        }

        public float getDistance(int i, int j)
        {
            return distances[i,j];
        }
    }
}
