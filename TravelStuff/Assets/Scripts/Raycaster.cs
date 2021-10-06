using Boo.Lang;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Raycaster : MonoBehaviour
{
    [Tooltip("The layer considered as valid")]
    public LayerMask layerMasks;

    [Tooltip("Max raycast distance")]
    public float distance;

    private bool isColliding;

    [Serializable]
    public class GameObjectUnityEvent : UnityEvent<GameObject> { }
    public GameObjectUnityEvent hitTargetChanged;

    [Serializable]
    public class Vector3UnityEvent : UnityEvent<Vector3> { }
    public Vector3UnityEvent hitPosition;
    public Vector3UnityEvent hitAngle;

    public UnityEvent stoppedHittingTarget;
    public GameObject currentHitTarget;

    public void Raycast()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        //Debug.DrawRay(transform.position, transform.forward);
        bool hasHit = Physics.Raycast(ray, out hitInfo, distance, layerMasks);

        if (hasHit)
        {
            if(currentHitTarget != hitInfo.transform.gameObject)
            {
                currentHitTarget = hitInfo.transform.gameObject;
                hitTargetChanged?.Invoke(currentHitTarget);
            }
            
            hitAngle?.Invoke(hitInfo.normal);
            hitPosition?.Invoke(hitInfo.point);
        }
        else if (isColliding)
        {
            stoppedHittingTarget?.Invoke();
            currentHitTarget = null;
        }
        else
        {
            currentHitTarget = null;
        }

        if(isColliding != hasHit)
        {
            isColliding = hasHit;
        }
    }

    public void Update()
    {
        Raycast();
    }
}
