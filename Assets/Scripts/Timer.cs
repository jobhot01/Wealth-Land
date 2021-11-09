using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    [SerializeField] LoadScene loadScene;
    [SerializeField] GameObject timeOutObj;
    [SerializeField] GameObject warningObj;
    [SerializeField] Button nextButton;
    [SerializeField] float decreaseTime;
    [SerializeField] Text timeDisplay;
    int gameturn;

    void Start()
    {
        GetPlayerPref();
        timeOutObj.SetActive(false);
        // warningObj.SetActive(false);
        // if (gameturn == 2)
        // {
        //     warningObj.SetActive(true);
        // }
    }

    void Update()
    {
        StartTimer();
        UI_Update();
    }

    void GetPlayerPref()
    {
        gameturn = PlayerPrefs.GetInt("gameturn");
    }

    void StartTimer()
    {
        decreaseTime -= Time.deltaTime;
            if (decreaseTime <= 5)
            {
                timeDisplay.color = Color.red;
            }

            if (decreaseTime <= 0)
            {
                decreaseTime = 0;
                timeOutObj.SetActive(true);
                nextButton.interactable = false;
                Invoke("TimeOut", 2.25f);
            }
    }

    void TimeOut()
    {
        loadScene.TimeOut();
    }

    void UI_Update()
    {
        timeDisplay.text = decreaseTime.ToString("F0");
    }
}
