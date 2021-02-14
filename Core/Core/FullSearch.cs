using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    class FullSearch : Solver
    {
        public FullSearch(in Data data) : base(in data)
        {
        }
        public override bool run()
        {
            int num_cities = data.num_cities;
            // 2都市目以降のルート
            int[] sub_route = new int[num_cities - 1];

            // 開始地点は必ず都市0である。他の num_cities - 1 都市の回り方を全列挙する。
            // 準備として辞書順で最初の順列 [1, 2, ... , num_cities - 1] を用意。
            for(int i = 0; i < num_cities - 1; i++)
            {
                sub_route[i] = i + 1;
            }

            do
            {
                // 既に探索したルートの逆順となるものは除外
                if (sub_route[0] > sub_route[num_cities - 2]) continue;

                int[] route = new int[num_cities];
                route[0] = 0;
                sub_route.CopyTo(route, 1);

                float distance = calculateRouteDistance(route);
                if(distance < calculated_best_distance)
                {
                    calculated_best_distance = distance;
                    calculated_best_route = route;
                }

            } while (nextPermutation(sub_route));

            return true;
        }

        // 引数routeの辞書順で次の順列を求める。
        private bool nextPermutation(int[] array)
        {
            var size = array.Length;
            int i = size - 2;
            for(; 0 <= i; i--)
            {
                if(array[i] < array[i + 1]) break;
            }

            if(i < 0) return false;

            int j = size - 1;
            for(; ; j--)
            {
                if (array[i] < array[j]) break;
            }

            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;

            Array.Reverse(array, i + 1, size - (i + 1));

            return true;
        }
    }
}
