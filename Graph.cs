using System;
using System.Collections.Generic;
using System.Collections;


public class Node <T> where T : IComparable
{
    T value;
    int color;

    public Node(T value)
    {
        this.value = value;
    }

    public T getValue()
    {
        return value;
    }

    public int getColor()
    {
        return color;
    }

    public void setColor(int color)
    {
        this.color = color;
    }

}

class Matrix {

    // creating a 2D array
    int[,] access;
    public Matrix()
    {
        access = new int[0, 0];
    }

    public void add(int x)
    {
        enlarge();
        access[access.GetLength(0) - 1, access.GetLength(1) - 1] = x;
    }

    public void add()
    {
        add(0);
    }

    public int getPos(int x, int y)
    {
        return access[x, y];
    }

    public void setPos(int x, int y, int value)
    {
        access[x, y] = value;
    }

    public void showMatrix()
    {
        for (int i = 0; i < access.GetLength(0); i++)
        {
            for (int j = 0; j < access.GetLength(0); j++)
            {
                Console.Write(access[i, j] + " ");
            }
            Console.Write("\n");
        }
    }

    public void showLine(int index)
    {
        for(int i = 0; i < access.GetLength(0); i++)
        {
            Console.Write(access[index, i] + " ");
        }

    }

    private void enlarge()
    {
        int [,] temp = new int[access.GetLength(0) + 1, access.GetLength(0) + 1];
        for (int i = 0; i < access.GetLength(0); i++)
        {
            for (int j = 0; j < access.GetLength(0); j++)
            {
                temp[i, j] = access[i, j];
            }
        }

        for (int i = 0; i < temp.GetLength(0); i++)
        {
            for (int j = 0; j < temp.GetLength(0); j++)
            {
                if (j == temp.Length - 1 || i == temp.Length - 1)
                {
                    temp[j,i] = 0;
                }
            }
        }
        access = temp;
    }


}

public class Graph <T> where T : IComparable
{
    // LinkedList<Node<T>> storage;
    EnumeratedLinkedList<Node<T>> storage;

    Matrix access;
    private int vertices = 0;
    int edges = 0;

    public Graph()
    {
        // storage = new LinkedList<Node<T>>();
        storage = new EnumeratedLinkedList<Node<T>>();
        access = new Matrix();
    }

    public void add (T value)
    {
        storage.AddLast(new Node<T>(value));
        vertices++;
        access.add();
    }

    public void addEdge (int x, int y, int edgeValue)
    {
        access.setPos(x, y, edgeValue);
        access.setPos(y, x, edgeValue);
        edges++;
    }

    public void BreadthFirstSearch(Node<T> start)
    {
        // Colors map
        // 0 = white
        // 1 = grey
        // 2 = black
        setColors(0);
        start.setColor(1);
        Queue<Node<T>> q = new Queue<Node<T>>();
        q.Enqueue(start);
        while (q.Count != 0)
        {
            Node<T> vis = q.Dequeue();
            Console.Write(vis.getValue() + " ");
            for (int i = 0; i < vertices; i++)
            {
                if (access.getPos(i, getPosition(vis)) > 0)
                {
                    if (storage.get(i).getColor() == 0)
                    {
                        storage.get(i).setColor(1);
                        q.Enqueue(storage.get(i));
                    }
                }
            }
            vis.setColor(2);
        }
    }



    public Node<T> getRoot()
    {
        Node<T> a;
        try
        {
            a = storage.get(0);
        } catch (InvalidOperationException e)
        {
            if (e == null)
            {}

            return null;
        }
        return a;
    }

    private void setColors(int color)
    {
       foreach (Node<T> val in storage)
        {
            val.setColor(color);
        }
    }
    private int getPosition(Node<T> s)
    {
        int pos = 0;
        foreach (Node<T> val in storage)
        {
            if (val.Equals(s))
            {
                break;
            }
            pos++;
        }
        return pos;
    }

    public void printAdjacencyMatrix()
    {
        Console.Write("X ");
        foreach (Node<T> val in storage)
        {
            Console.Write(val.getValue() + " ");
        }
        Console.Write("\n");
        int i = 0;
        foreach (Node<T> val in storage)
        {
            Console.Write(val.getValue() + " ");
            access.showLine(i);
            Console.Write("\n");
            i++;
        }
    }

}
