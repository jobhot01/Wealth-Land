using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{   
     public void GoLastScene()
    {
        if ( GameController.gameturn == 12)
        {
            SceneManager.LoadScene("Game Over");
        }
        else
        {
            //PlayerPrefs.SetInt("allIncome", StartupInvestment.budget);
            //PlayerPrefs.SetInt("allSavings", StartupInvestment.bankedMoney);
            //PlayerPrefs.SetInt("inputStock", CalculateAllInvestment.stock);
            //PlayerPrefs.SetInt("inputBond", CalculateAllInvestment.bond);
            //PlayerPrefs.SetInt("inputDeposit", CalculateAllInvestment.deposit);
            //PlayerPrefs.SetFloat("randomStock", StartupInvestment.stockProfitPercentage);
            //PlayerPrefs.SetFloat("randomBond", StartupInvestment.bondProfitPercentage);
            //PlayerPrefs.SetFloat("randomDeposit", StartupInvestment.depositProfitPercentage);
            SceneManager.LoadScene("Turn Counting");
        }
    }
}
