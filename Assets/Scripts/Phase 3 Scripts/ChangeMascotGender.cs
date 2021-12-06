using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMascotGender : MonoBehaviour
{
    [SerializeField] GameObject maleMascot;
    [SerializeField] GameObject femaleMascot;
    string gender;

    void Start()
    {
        gender = PlayerPrefs.GetString("Gender");

        switch (gender)
        {
            case "Male":
                maleMascot.SetActive(true);
                femaleMascot.SetActive(false);
                break;

            case "Female":
                femaleMascot.SetActive(true);
                maleMascot.SetActive(false);
                break;

            case null:
                Debug.LogWarning("No Gender found");
                maleMascot.SetActive(false);
                femaleMascot.SetActive(false);
                break;
        }
    }
}
