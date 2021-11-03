using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnStartPhase : MonoBehaviour
{
    public Text previousSavingsText, incomeText, nameDisplay;
    public GameObject TutorialBox, timerWarning;
    public int previousSavings, myIncome;
    [SerializeField] private Timer timer;

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

        if (GameController.gameturn == 2)
        {
            timerWarning.SetActive(true);
        }
        else if (GameController.gameturn >= 3)
        {
            timer.enabled = true;
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
