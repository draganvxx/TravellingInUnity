using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotTime;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, (rotTime) * Time.deltaTime, 0, Space.Self);    
    }
}
