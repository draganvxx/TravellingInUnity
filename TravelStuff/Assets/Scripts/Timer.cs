using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float elapsedTime;

    [SerializeField]
    private float duration;

    [SerializeField]
    private bool percentage;

    [Serializable]
    public class FloatUnityEvent : UnityEvent<float> { }
    public FloatUnityEvent elapsedTimeUpdated;

    public UnityEvent completed;


    public float GetProgress(bool asPercentage = true)
    {
        float result;

        if (asPercentage)
        {
            result = elapsedTime / duration;
        }
        else
        {
            result = elapsedTime;
        }

        return Mathf.Clamp(result, 0, asPercentage ? 1 : duration);
    }

    public IEnumerator PerformTimeCheck()
    {
        while(elapsedTime < duration)
        {
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
            elapsedTimeUpdated?.Invoke(GetProgress(percentage));
        }
        completed?.Invoke();
    }

    public void ResetTime()
    {
        elapsedTime = 0;
        elapsedTimeUpdated?.Invoke(GetProgress(percentage));
    }

    public void StartTimer()
    {
        StopAllCoroutines();
        StartCoroutine(PerformTimeCheck());
    }

    public void RestartTimer()
    {
        ResetTime();
        StartTimer();
    }
}
