using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager : ListIterator<GameObject>
{
    public void Start()
    {
        Change(0);
    }
    public override void Change(int i)
    {
        itemList[index].SetActive(false);
        itemList[i].SetActive(true);

        base.Change(i);
    }
}
