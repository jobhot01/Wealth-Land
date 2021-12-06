using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndCutsceneController : MonoBehaviour
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
        GetGender();
        PlayVideo();
        SetVolume();
    }

    void Update()
    {
        videoTime += Time.deltaTime;
        OnCutsceneEnd();
    }

    void GetGender()
    {
        gender = PlayerPrefs.GetString("Gender");
    }

    void PlayVideo()
    {
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
        }

        switch (gender)
        {
            case "Male":
                filePath = Path.Combine(Application.streamingAssetsPath, "end male scene.mp4");
                videoPlayer.url = filePath;
                break;

            case "Female":
                filePath = Path.Combine(Application.streamingAssetsPath, "end female scene.mp4");
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
        if (videoTime > 19f)
        {
            loadScene.GoLastScene();
        }
    }
}
