using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : ListIterator<Material>
{
    // Start is called before the first frame update
    void Start()
    {
        Change(0);
    }

    public override void Change(int i)
    {
        RenderSettings.skybox = itemList[i];
        base.Change(i);
    }
}
