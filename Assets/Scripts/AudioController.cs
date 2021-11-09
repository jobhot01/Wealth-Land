using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject audioObject;
    float musicVolume;

    void Start()
    {
        if (audioSource == null)
        {
            audioObject = GameObject.FindWithTag("GameMusic");
        }
        audioSource = GetComponent<AudioSource>();
        
        //Set volume
        int wentOption = PlayerPrefs.GetInt("WentOption");
        Debug.Log("Went Option " + wentOption);
        if (wentOption == 0)
        {
            musicVolume = 0.35f;
        }
        else
        {
            musicVolume = PlayerPrefs.GetFloat("Volume");
        }
        audioSource.volume = musicVolume;
        // Debug.Log("VolumePP: " + PlayerPrefs.GetFloat("Volume"));
        // Debug.Log("Volume: " + musicVolume);
    }
}
