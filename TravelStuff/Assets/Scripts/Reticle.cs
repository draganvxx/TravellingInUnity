using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    public Transform controller;
    private bool overrideAutomatedUpdate;

    public bool OverrideAutomatedUpdate
    {
        set
        {
            overrideAutomatedUpdate = value;
        }
    }

    private float distanceFromHit = 0.05f;
    public float restingDistance = 2f;
    public bool invertedForward;
    public float speed = 20f;

    public void AutoPositionOrientation()
    {
        Vector3 intendedPosition = controller.position + controller.forward * restingDistance;
        transform.position = Vector3.Lerp(transform.position, intendedPosition, Time.deltaTime * speed) ;
        SetForward(controller.forward);
    }

    public void SetPosition(Vector3 position)
    {
        //transform.position = position + (invertedForward ? -1 : 1) * transform.forward * distanceFromHit;
        Vector3 towardsController = (controller.position - position).normalized * (invertedForward ? -1 : 1);
        transform.position = position + towardsController * distanceFromHit;
    }

    public void SetForward(Vector3 forward)
    {
        transform.forward = (invertedForward ? -1 : 1) * forward;
    }

    public void Update()
    {
        if (!overrideAutomatedUpdate)
        {
            AutoPositionOrientation();
        }
    }
}
