﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenderSelect : MonoBehaviour
{
    public string gender;
    public Button manButton, womanButton;
    public AudioSource stampSound;
    [SerializeField] private CheckAllCharacterScripts checkAllCharacterScripts;

    public void ClickMan()
    {
        gender = "Male";
        stampSound.Play();
        //print("Man");
        manButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        womanButton.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        checkAllCharacterScripts.UpdateButton();
    }

    public void ClickWoman()
    {
        gender = "Female";
        stampSound.Play();
        //print("Woman");
        womanButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        manButton.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        checkAllCharacterScripts.UpdateButton();
    }
}
