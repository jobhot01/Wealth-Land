using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    [SerializeField] LoadScene loadScene;
    [SerializeField] GameObject timeOutObj;
    [SerializeField] GameObject warningObj;
    [SerializeField] GameObject tutorialPanel;
    [SerializeField] Button nextButton;
    [SerializeField] Button openTutorialButton;
    [SerializeField] float decreaseTime;
    [SerializeField] Text timeDisplay;
    int gameturn;
    public static bool isPausing;

    void Start()
    {
        GetPlayerPref();
        timeOutObj.SetActive(false);
        isPausing = false;
        openTutorialButton.onClick.AddListener(OpenTutorial);
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
        if (isPausing == false)
        {
            decreaseTime -= Time.deltaTime;
        }
        else if (isPausing == true)
        {
            decreaseTime = decreaseTime;
        }

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

    public void OpenTutorial()
    {
        if (gameturn > 1)
        {
            isPausing = true;
        }
    }

    public void IsPausing(bool isPause)
    {
        isPausing = isPause;
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
