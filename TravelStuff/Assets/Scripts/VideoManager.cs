using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoManager : ListIterator<VideoClip>
{
    public VideoPlayer videoPlayer;

    [Serializable]
    public class VideoUnityEvent : UnityEvent<VideoPlayer> { }
    public VideoUnityEvent videoLoaded;
    public VideoUnityEvent videoLoopPoint;
    public UnityEvent videoUpdated;
    // Start is called before the first frame update
    public void Start()
    {
        Change(0);
    }

    public void OnEnable()
    {
        videoPlayer.prepareCompleted += videoLoaded.Invoke;
        videoPlayer.loopPointReached += videoLoopPoint.Invoke;
    }

    public void OnDisable()
    {
        videoPlayer.prepareCompleted -= videoLoaded.Invoke;
        videoPlayer.loopPointReached -= videoLoopPoint.Invoke;
    }

    public override void Change(int i)
    {
        videoPlayer.clip = itemList[i];
        base.Change(i);
        videoUpdated?.Invoke();
    }
}
