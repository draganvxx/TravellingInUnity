using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureManager : ListIterator<Texture>
{
    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        Change(0);
    }

    public override void Change(int i)
    {
        material.SetTexture("_MainTex", itemList[i]);
        base.Change(i);
    }

}
