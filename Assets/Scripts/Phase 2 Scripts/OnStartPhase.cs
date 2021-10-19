using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnStartPhase : MonoBehaviour
{
    public Text previousSavingsText, incomeText, nameDisplay;
    public int previousSavings, myIncome;

    void Start()
    {
        previousSavings = PlayerPrefs.GetInt("allSavings");
        myIncome = PlayerPrefs.GetInt("allIncome");

        if (LoadScene.playerName == null)
        {
            LoadScene.playerName = "No name detected";
        }

        previousSavingsText.text = previousSavings.ToString("N0") + "           บาท";
        incomeText.text = myIncome.ToString("N0") + "           บาท";
        nameDisplay.text = LoadScene.playerName.ToString();
    }
}
