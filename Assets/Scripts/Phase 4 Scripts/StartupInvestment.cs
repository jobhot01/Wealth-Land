using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartupInvestment : MonoBehaviour
{
    public int budget, bankedMoney;
    public float depositProfitPercentage, bondProfitPercentage, stockProfitPercentage;
    public Text remainingBankedMoneyDisplayer, remainingBudgetDisplayer, nameDisplay;
    public GameObject TutorialBox, timerWarning;
    [SerializeField] private Timer timer;

    void Start()
    {
        budget = PlayerPrefs.GetInt("allIncome");
        bankedMoney = PlayerPrefs.GetInt("allSavings");

        if (LoadScene.playerName == null)
        {
            LoadScene.playerName = "No name detected";
        }

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

        remainingBudgetDisplayer.text = budget.ToString("N0");
        remainingBankedMoneyDisplayer.text = bankedMoney.ToString("N0");
        nameDisplay.text = LoadScene.playerName.ToString();
        PlayerPrefs.DeleteKey("inputStock");
        PlayerPrefs.DeleteKey("inputBond");
        PlayerPrefs.DeleteKey("inputDeposit");
        CalculateProfitPercentage();
    }

    void CalculateProfitPercentage()
    {
        depositProfitPercentage = Random.Range(1.0048f, 1.0275f);
        bondProfitPercentage = Random.Range(1.0119f, 1.1525f);
        stockProfitPercentage = Random.Range(0.8877f, 1.487f);
    }
}
