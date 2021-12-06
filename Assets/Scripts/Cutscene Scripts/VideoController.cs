using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] LoadScene loadScene;
    float videoVolume;
    double videoTime;
    string filePath;
    string gender;


    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        gender = PlayerPrefs.GetString("Gender");
        Debug.Log("Gender: " + gender);
        PlayVideo();
        SetVolume();
    }

    void Update()
    {
        videoTime += Time.deltaTime;
        OnCutsceneEnd();
    }

    void PlayVideo()
    {
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
        }

        switch(gender)
        {
            case "Male":
                filePath = Path.Combine(Application.streamingAssetsPath, "intro male scene.mp4");
                videoPlayer.url = filePath;
                break;

            case "Female":
                filePath = Path.Combine(Application.streamingAssetsPath, "intro female scene.mp4");
                videoPlayer.url = filePath;
                break;

            case null:
                Debug.LogWarning("No gender found");
                break;
        }

        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetCameraAlpha = 1f;
        videoPlayer.Play();
    }

    void SetVolume()
    {
        float rawVolume = PlayerPrefs.GetFloat("Volume");
        videoVolume = rawVolume * 0.65f;
        videoPlayer.SetDirectAudioVolume(0, videoVolume);
    }

    void OnCutsceneEnd()
    {
        //double videoEnd = videoPlayer.length;
        if (videoTime > 41f)
        {
            loadScene.GoTutorial();
        }    
    }
}
