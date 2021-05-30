using System;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {


            GraphL<int> atest = new GraphL<int>();
            atest.add(1);
            atest.add(2);
            atest.add(12);
            atest.add(8);
            atest.add(4);
            atest.addEdge(0, 1, 1);
            atest.addEdge(1, 2, 13);
            atest.addEdge(2, 3, 5);
            atest.addEdge(3, 4, 3);
            atest.addEdge(0, 4, 14);
            atest.addEdge(1, 3, 2);
            atest.KruskalsMST().listAllEdges();
            // Graph<int> ktest = new Graph<int>();
            // ktest.add(7);
            // ktest.add(3);
            // ktest.add(4);
            // ktest.add(1);
            // ktest.add(9);
            // ktest.addEdge(0, 1, 5);
            // ktest.addEdge(0, 3, 6);
            // ktest.addEdge(1, 2, 2);
            // ktest.addEdge(1, 4, 4);
            // ktest.addEdge(2, 3, 8);
            // ktest.addEdge(3, 4, 3);
            // ktest.printAdjacencyMatrix();

            // ktest.BreadthFirstSearch(ktest.getRoot());
        }
    }

}
