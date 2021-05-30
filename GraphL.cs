using System;

public class GraphL<T> where T : IComparable
{
    EnumeratedLinkedList<NodeL<T>> storage;
    EnumeratedLinkedList<Edge<T>> edgeList;
    private int vertices;

    public GraphL()
    {
        storage = new EnumeratedLinkedList<NodeL<T>>();
        edgeList = new EnumeratedLinkedList<Edge<T>>();
    }

    public void add(T value)
    {
        storage.AddLast(new NodeL<T>(value));
        vertices++;
    }

    public void addEdge (int x, int y, int edgeValue)
    {
        edgeList.AddLast(new Edge<T>(storage.get(x), storage.get(y), edgeValue));
    }

    public Group<T> KruskalsMST()
    {
        // 1) Sort edges by ascending edge weight
        Edge<T>[] edgeArr = new Edge<T>[edgeList.Count];
        for (int i = 0; i < edgeArr.GetLength(0); i++){
            edgeArr[i] = edgeList.get(i);
        }
        Array.Sort(edgeArr);
        EnumeratedLinkedList<Group<T>> forestOfGroups = new EnumeratedLinkedList<Group<T>>();
        for (int i = 0; i < edgeArr.GetLength(0); i++)
        {

            int didBelongToAny = 0;
            foreach(Group<T> k in forestOfGroups)
            {
                if(k.oneCheck(edgeArr[i]))
                {
                    didBelongToAny++;
                }
            }
            if (didBelongToAny == 0)
            {
                forestOfGroups.AddFirst(new Group<T>());
                forestOfGroups.get(0).addEdge(edgeArr[i]);
            } else if (didBelongToAny == 1)
            {
                foreach(Group<T> k in forestOfGroups)
                {
                    if(k.oneCheck(edgeArr[i]))
                    {
                        k.addEdge(edgeArr[i]);
                    }
                }
            } else if (didBelongToAny == 2)
            {

                Group<T> temp_1 = null, temp_2 = null;
                int cond = 0;
                foreach(Group<T> k in forestOfGroups)
                {
                    if(k.oneCheck(edgeArr[i]) && cond == 0)
                    {
                        temp_1 = k;
                        cond++;
                    } else if (k.oneCheck(edgeArr[i]))
                    {
                        temp_2 = k;
                    }
                }

                temp_1.addEdge(edgeArr[i]);
                temp_1.union(temp_2);

                forestOfGroups.Remove(temp_2);
                // forestOfGroups.AddLast(temp_1);
            }

        }
        return forestOfGroups.get(0);
    }
}

public class Group<T> where T : IComparable
{
    EnumeratedLinkedList<Edge<T>> groupEdges;

    EnumeratedLinkedList<NodeL<T>> groupNodes;

    public Group()
    {
        groupEdges = new EnumeratedLinkedList<Edge<T>>();
        groupNodes = new EnumeratedLinkedList<NodeL<T>>();
    }

    // returns true if one node of given Edge is already in this group
    // else return false
   public Boolean oneCheck(Edge<T> val)
   {
        foreach(NodeL<T> k in groupNodes)
        {
            if (k.Equals(val.getStart()) || k.Equals(val.getFinish()))
            {
                return true;
            }
        }
        return false;
   }

    // returns true if given edge will NOT create cycle in group
    // else return false
    public Boolean cycleCheck(Edge<T> val)
    {
        Boolean wasFound_1 = false;
        Boolean wasFound_2 = false;
        foreach(NodeL<T> k in groupNodes)
        {
            if (k.Equals(val.getStart()))
            {
                wasFound_1 = true;
            }
        }
        if (wasFound_1)
        {
            foreach(NodeL<T> k in groupNodes)
            {
                if (k.Equals(val.getFinish()))
                {
                    wasFound_2 = true;
                }
            }
        }
        return !wasFound_1 || !wasFound_2;
    }

    public void addEdge(Edge<T> addition)
    {
        if (cycleCheck(addition))
        {
            groupEdges.AddLast(addition);
            addNode(addition.getFinish());
            addNode(addition.getStart());

        }
    }

    public void addNode(NodeL<T> addit)
    {
        Boolean wasFound = false;
        foreach (NodeL<T> k in groupNodes)
        {
            if (k.Equals(addit))
            {
                wasFound = true;
            }
        }
        if (!wasFound)
        {
            groupNodes.AddLast(addit);
        }
    }

    public void union(Group<T> toBeUnified)
    {
        foreach(Edge<T> k in toBeUnified.groupEdges)
        {
            addEdge(k);
        }
    }

    public void listAllEdges()
    {
        Console.Write("\n");
        foreach(Edge<T> k in groupEdges)
        {
            Console.WriteLine("from " + k.getStart().getValue() + ", to " + k.getFinish().getValue() + "; weight: " + k.getWeight());
        }
    }

}

public class NodeL<T> where T : IComparable
{
    T value;
    public NodeL(T value)
    {
        this.value = value;
    }

    public T getValue()
    {
        return value;
    }
}

public class Edge<T> : IComparable where T : IComparable
{
    NodeL<T> finish;
    NodeL<T> start;

    int weight;

    public int CompareTo(object other)
    {
        var compared = other as Edge<T>;
        return this.weight - compared.weight;
    }

    public Edge(NodeL<T> finish, NodeL<T> start, int weight)
    {
        this.start = start;
        this.finish = finish;
        this.weight = weight;
    }
    public int getWeight()
    {
        return weight;
    }

    public NodeL<T> getStart()
    {
        return start;
    }

    public NodeL<T>  getFinish()
    {
        return finish;
    }
}
