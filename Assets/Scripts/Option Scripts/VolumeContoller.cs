using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeContoller : MonoBehaviour
{
    public GameObject audioObject;
    public Slider volumeSlider;
    AudioSource audioSource;
    public static float musicVolume;
    
    void Start()
    {
        audioObject = GameObject.FindWithTag("MainMenuMusic");
        if (audioObject == null)
        {
            Debug.LogWarning("Audio Object not found!!");
        }
        else
        {
            audioSource = audioObject.GetComponent<AudioSource>();
        }
        
        int wentOption = PlayerPrefs.GetInt("WentOption");
        if (wentOption == 1)
        {
            musicVolume = PlayerPrefs.GetFloat("Volume");
        }
        //musicVolume = PlayerPrefs.GetFloat("Volume");
        //Debug.Log("Volume: " + musicVolume);
        volumeSlider.value = musicVolume;
        audioSource.volume = musicVolume;
    }

    void Update()
    {
        audioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("Volume", musicVolume);
        //Debug.Log("Volume: " + PlayerPrefs.GetFloat("Volume"));
    }

    public void VolumeUpdate(float volume)
    {
        musicVolume = volume;
        volumeSlider.value = musicVolume;
    }

    public void MuteBGM()
    {
        musicVolume = 0f;
    }

    public void UnMuteBGM()
    {
        musicVolume = 1f;
    }
}
