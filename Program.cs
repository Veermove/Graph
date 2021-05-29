using System;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {

            Graph<int> ktest = new Graph<int>();
            ktest.add(7);
            ktest.add(3);
            ktest.add(4);
            ktest.add(1);
            ktest.add(9);
            ktest.addEdge(0, 1, 5);
            ktest.addEdge(0, 3, 6);
            ktest.addEdge(1, 2, 2);
            ktest.addEdge(1, 4, 4);
            ktest.addEdge(2, 3, 8);
            ktest.addEdge(3, 4, 3);
            ktest.printAdjacencyMatrix();

            ktest.BreadthFirstSearch(ktest.getRoot());
        }
    }

}
