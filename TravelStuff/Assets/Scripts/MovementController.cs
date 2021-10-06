using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float translationTime;
    public Vector3 offset;
    
    public void MoveToPosition(Vector3 positionToReach)
    {
        StartCoroutine(PerformTranslation(positionToReach + offset));
    }

    public void MoveToPosition(Transform target)
    {
        StartCoroutine(PerformTranslation(target.position + offset));
    }

    public IEnumerator PerformTranslation(Vector3 posToReach)
    {
        Vector3 currPos = transform.position;
        float elapsedTime = 0;
        float completionRatio = 0;
        while (elapsedTime < translationTime)
        {
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
            completionRatio = Mathf.Clamp01(elapsedTime / translationTime);
            transform.position = Vector3.Lerp(currPos, posToReach, completionRatio);
        }

        transform.position = posToReach;
    }
}
