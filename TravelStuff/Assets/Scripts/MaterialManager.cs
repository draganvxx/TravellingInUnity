using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : ListIterator<Material>
{
    private void Start()
    {
        Change(0);
    }

    public override void Change(int i)
    {
        gameObject.GetComponent<MeshRenderer>().material = itemList[i];
        base.Change(i);
    }
}
