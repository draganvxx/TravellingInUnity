using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class VRClick : MonoBehaviour
{
    public GameObject gazeTarget;

    public UnityEvent newGazeTarget;
    public UnityEvent gazeTargetExited;

    public void ProcessGazedAsset(GameObject asset)
    {
        gazeTarget = asset;
        newGazeTarget?.Invoke();
    }

    public void StoppedGazingAtAsset()
    {
        gazeTarget = null;
        gazeTargetExited?.Invoke();
    }

    public void PerformClick()
    {
        IPointerClickHandler clickHandler = gazeTarget.GetComponent<IPointerClickHandler>();
        PointerEventData data = new PointerEventData(EventSystem.current);

        clickHandler?.OnPointerClick(data);
    }
}
