using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnStartPhase : MonoBehaviour
{
    public Text previousSavingsText, incomeText, nameDisplay;
    public GameObject TutorialBox;
    public int previousSavings, myIncome;

    void Start()
    {
        previousSavings = PlayerPrefs.GetInt("allSavings");
        myIncome = PlayerPrefs.GetInt("allIncome");

        if ( GameController.gameturn <= 1 )
        {
            TutorialBox.gameObject.SetActive(true);
        }
        else
        {
            TutorialBox.gameObject.SetActive(false);
        }

        if (LoadScene.playerName == null)
        {
            LoadScene.playerName = "No name detected";
        }

        previousSavingsText.text = previousSavings.ToString("N0") + "           บาท";
        incomeText.text = myIncome.ToString("N0") + "           บาท";
        nameDisplay.text = LoadScene.playerName.ToString();
    }
}
