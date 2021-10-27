using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenderSelect : MonoBehaviour
{
    public string gender;
    public Button manButton, womanButton;
    public GameObject manStamp, womanStamp;
    public AudioSource stampSound;
    [SerializeField] private CheckAllCharacterScripts checkAllCharacterScripts;

    public void ClickMan()
    {
        gender = "Male";
        stampSound.Play();
        //print("Man");
        manButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        womanButton.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        manStamp.SetActive(true);
        womanStamp.SetActive(false);
        checkAllCharacterScripts.UpdateButton();
    }

    public void ClickWoman()
    {
        gender = "Female";
        stampSound.Play();
        //print("Woman");
        womanButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        manButton.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        womanStamp.SetActive(true);
        manStamp.SetActive(false);
        checkAllCharacterScripts.UpdateButton();
    }
}
