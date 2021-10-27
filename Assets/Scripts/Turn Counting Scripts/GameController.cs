using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static int gameturn;
    public static int savingsInt;
    public static int mainIncomeInt;
    public Text TurnDisplayer;
    public Text NameDisplay;
    public Text DepositDisplay;
    public Text BondDisplay;
    public Text StockDisplay;
    public Text ProfitDisplay;
    public Text SumAllDisplay;
    public Text SavingsDisplay;
    public Text Est_ExpenditureDisplay;

    public static float profitDifferent;
    float financialObstacle;
    float allValues;
    float savingsFloat;
    float inflationPercent;
    float estExpenditure;
    float depositProfitPercentage;
    float bondProfitPercentage;
    float stockProfitPercentage;
    float stockFloat;
    float bondFloat;
    float depositFloat;
    float allProfit;
    float mainIncomeFloat;
    int stock;
    int bond;
    int deposit;
    int investment;
    int sumThisSceneValues;
    
    void Start()
    {
        gameturn++;
        PlayerPrefs.GetInt("gameturn");
        PlayerPrefs.SetInt("gameturn", gameturn);
        stock = PlayerPrefs.GetInt("inputStock");
        bond = PlayerPrefs.GetInt("inputBond");
        deposit = PlayerPrefs.GetInt("inputDeposit");
        investment = PlayerPrefs.GetInt("AllInvestment");
        mainIncomeInt = PlayerPrefs.GetInt("FirstIncome");
        stockProfitPercentage = PlayerPrefs.GetFloat("randomStock");
        bondProfitPercentage = PlayerPrefs.GetFloat("randomBond");
        depositProfitPercentage = PlayerPrefs.GetFloat("randomDeposit");
        allValues = PlayerPrefs.GetFloat("SumAllValues");
        Debug.Log("All Values: " + allValues);
        
        if (LoadScene.playerName == null)
        {
            LoadScene.playerName = "No name detected";
        }

        CalculateProfit();
        CalculateInflation();
        savingsFloat = (allValues * inflationPercent) + profitDifferent ;
        IncreaseMainIncome();
        FinancialObstacleExampleChecking();
        CalculateEstExpenditure();
        CovertFloatToInt();
        ResetAllValues();
        UI_Update();
    }

    void Update()
    {
        
    }

    void FinancialObstacleExampleChecking()
    {
        if ( gameturn == 4 || gameturn == 8 || gameturn == 12 )
        {
            float stackedSumAllValues = PlayerPrefs.GetFloat("StackedSumAllValues");
            financialObstacle = ( stackedSumAllValues * 0.2f ) * 1.5f + 1500f;
            
        }
        else
        {
            financialObstacle = 0;
        }
    }

    void IncreaseMainIncome()
    {
        if ( gameturn <= 1 )
        {
            mainIncomeFloat = 15000;
        }
        else
        {
            mainIncomeFloat = mainIncomeInt;
            mainIncomeFloat = mainIncomeFloat * Random.Range(1.03f,1.085f);
        }
    }

    void CalculateProfit()
    {
        depositFloat = deposit * depositProfitPercentage;
        bondFloat = bond * bondProfitPercentage;
        stockFloat = stock * stockProfitPercentage;
        allProfit = depositFloat + bondFloat + stockFloat;

        profitDifferent = allProfit - investment;
    }

    void CalculateEstExpenditure()
    {
        estExpenditure = financialObstacle + (mainIncomeFloat * Random.Range(0.85f, 1.15f));
        Debug.Log("EST Expen.: " + estExpenditure);
    }

    void CalculateInflation()
    {
        inflationPercent = Random.Range(0.991f, 1.038f);
        Debug.Log("Inflation: " + inflationPercent + "%");
    }

    void ResetAllValues()
    {
        if( gameturn <= 1 )
        {
            savingsInt = 0;
            deposit = 0;
            bond = 0;
            stock = 0;
            investment = 0;
            profitDifferent = 0;
            mainIncomeInt = 15000;
            Debug.Log("Reset savings and all investments");
        }
    }

    void CovertFloatToInt()
    {
        savingsInt = Mathf.RoundToInt( savingsFloat );
        mainIncomeInt = Mathf.RoundToInt( mainIncomeFloat );
        Debug.Log("Money: " + savingsInt);
    }

    void UI_Update()
    {
        if (profitDifferent > 0)
        {
            ProfitDisplay.color = new Color (0, 0.65f, 0, 1f);
        }
        else if (profitDifferent < 0)
        {
            ProfitDisplay.color = Color.red;
        }
        
        TurnDisplayer.text = $"TURNS {gameturn.ToString()}";
        DepositDisplay.text = depositFloat.ToString("N0");
        BondDisplay.text = bondFloat.ToString("N0");
        StockDisplay.text = stockFloat.ToString("N0");
        SavingsDisplay.text = savingsInt.ToString("N0");
        Est_ExpenditureDisplay.text = estExpenditure.ToString("N0");
        ProfitDisplay.text = profitDifferent.ToString("N0");
        SumAllDisplay.text = allProfit.ToString("N0");
        NameDisplay.text = LoadScene.playerName.ToString();
    }
}
