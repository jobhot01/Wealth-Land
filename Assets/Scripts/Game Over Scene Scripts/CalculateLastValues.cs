﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateLastValues : MonoBehaviour
{
    public Text ExtraIncomeDisplay;
    public Text ProfitDisplay;
    public Text RemainingValueDisplay;
    public Text NameDisplay;
    public Text TurnDisplay;
    float allValues;
    float stackedProfit;
    int stackedExtraIncome;
    int turn;

    string folderPath = "C:/Users/user/Desktop";



    void Start()
    {
        GetValues();
        NoMinusValues();
        UI_Update();
        ScreenCapture.CaptureScreenshot(System.IO.Path.Combine(folderPath, "Result.png"));
    }

    void GetValues()
    {
        turn = PlayerPrefs.GetInt("LastTurn");
        allValues = PlayerPrefs.GetFloat("SumAllValues");
        stackedExtraIncome = PlayerPrefs.GetInt("StackedExtraIncome");
        stackedProfit = PlayerPrefs.GetFloat("StackedProfit");

        if (LoadScene.playerName == null)
        {
            LoadScene.playerName = "No name detected";
        }
    }

    void NoMinusValues()
    {
        if (allValues <= 0)
        {
            allValues = 0;
        }

        if (stackedExtraIncome <= 0)
        {
            stackedExtraIncome = 0;
        }

        if (stackedProfit <= 0)
        {
            stackedProfit = 0;
        }
    }

    void UI_Update()
    {
        NameDisplay.text = LoadScene.playerName.ToString();
        TurnDisplay.text = turn.ToString();
        ExtraIncomeDisplay.text = stackedExtraIncome.ToString("N0");
        ProfitDisplay.text = stackedProfit.ToString("N0");
        RemainingValueDisplay.text = allValues.ToString("N0") + " บาท";
    }
}
