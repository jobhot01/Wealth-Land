using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    float videoVolume;
    
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        float rawVolume = PlayerPrefs.GetFloat("Volume");
        videoVolume = rawVolume * 0.65f;
        videoPlayer.SetDirectAudioVolume(0, videoVolume);
    }
}
