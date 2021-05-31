using System;
using System.Collections.Generic;
using System.Collections;

public class QueueList<T> : LinkedList<T> where T : IComparable
{
    public QueueList() : base()
    {
    }

    public T get(int index) {
        int i = 0;
        foreach(T val in this)
        {
            // Console.Write(i + " == " + index);
            if (i == index)
            {
                return val;
            }
            i++;
        }
        throw new InvalidOperationException();
    }

    public T getMin()
    {
        T min = this.get(0);
        foreach(T val in this)
        {
            // Console.Write(i + " == " + index);
            if (val.CompareTo(min) < 0)
            {
                min = val;
            }
        }
        return min;
    }

    public void removeMin()
    {
        this.Remove(getMin());
    }
}
