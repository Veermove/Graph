using System;
using System.Collections.Generic;
using System.Collections;

public class EnumeratedLinkedList<T> : LinkedList<T>
{
    public EnumeratedLinkedList() : base()
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
}
