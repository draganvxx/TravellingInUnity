using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ListIterator<T> : MonoBehaviour
{
    public List<T> itemList;
    internal int index;

    public virtual void Change(int i)
    {
        index = i;
    }

    public void Next()
    {
        int i = index + 1;

        if (i >= itemList.Count)
        {
            i = 0;
        }
        Change(i);
    }

    public void Previous()
    {
        int i = index - 1;

        if (i < 0)
        {
            i = itemList.Count - 1;
        }

        Change(i);
    }
}
