using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMinWeightGraph
{
    public class CalculateGraph
    {
        public int[,] fullGraph = new int[,] 
        {
            {0, 5, 6, 9, int.MaxValue, int.MaxValue},
            {5, 0, 3, 3, int.MaxValue, 14},
            {6, 3, 0, 13, 4, 16},
            {9, 3, 13, 0, 3, 4},
            {int.MaxValue, int.MaxValue, 4, 3, 0, int.MaxValue},
            {int.MaxValue, 14, 16, 4, int.MaxValue, 0}
        };

        private const int len = 6;
        public List<List<int>> list;      

        public void CalculateMinGraphWeight()
        {
            SearchMinWeight(fullGraph);
        }

        private int ReturnMinKey(int[] key, bool[] mstSet) 
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int i = 0; i < len; i++)
            {
                if (!mstSet[i] && key[i] < min)
                {
                    min = key[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        private void FormingList(int[] parent, int[,] graph) 
        {
            list = new List<List<int>>();
            for (int i = 1; i < len; i++)
            {
                List<int> tempList = new List<int> { parent[i], i, graph[parent[i], i] };
                list.Add(tempList);
            }
        }

        private void SearchMinWeight(int[,] graph) 
        {
            int[] parent = new int[len];
            int[] key = new int[len];
            bool[] mstSet = new bool[len];

            for (int i = 0; i < len; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int i = 0; i < len - 1; i++)
            {
                int u = ReturnMinKey(key, mstSet);
                if (u != -1) 
                {
                    mstSet[u] = true;

                    for (int j = 0; j < len; j++)
                    {
                        if (graph[u, j] != 0 && mstSet[j] == false && graph[u, j] < key[j])
                        {
                            parent[j] = u;
                            key[j] = graph[u, j];
                        }
                    }
                }                
            }
            FormingList(parent, graph);
        }
    }
}
