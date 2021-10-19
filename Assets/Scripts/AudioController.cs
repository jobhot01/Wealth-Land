using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        musicVolume = PlayerPrefs.GetFloat("Volume");
        // Debug.Log("VolumePP: " + PlayerPrefs.GetFloat("Volume"));
        // Debug.Log("Volume: " + musicVolume);
        audioSource.volume = musicVolume;
    }

    void Update()
    {
        
    }
}
