using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SummaryAllValues : MonoBehaviour
{
    public Text TurnDisplay;
    public Text IncomeDisplay;
    public Text SavingsDisplay;
    public Text InvestmentDisplay;
    public Text AllIncomeDisplay;
    public Text MainExpenditureDisplay;
    public Text EmergencyExpenditureDisplay;
    public Text FinancialObstacleDisplay;
    public Text SumAllExpendituresDisplay;
    public Text SumAllValuesDisplay;
    public Text NameDisplay;
    public GameObject CompleteImage;
    public GameObject FailImage;
    public GameObject CompleteMusic;
    public GameObject FailMusic;
    public Button NextButton;
    
    //Expenditure แปลว่า รายจ่าย
    float mainExpenditure;
    float emergencyExpenditure; 
    float allExpenditure;
    float financialObstacle;
    float financialObstacleValue;
    float eeOccurChance;
    float sumAllValues;
    float stackedSumAllValues;
    float profit;
    float stackedProfit;
    int[] itemArray;
    int income;
    int savings;
    int investment;
    int happiness;
    int allIncome;
    int turn;
    int deposit;
    int bond;
    int stock;
    int extraIncome;
    int stackedExtraIncome;

    void Start()
    {
        investment = PlayerPrefs.GetInt("AllInvestment");
        income = PlayerPrefs.GetInt("FirstIncome");
        savings = PlayerPrefs.GetInt("allSavings");
        happiness = PlayerPrefs.GetInt("myHappiness");
        turn = PlayerPrefs.GetInt("gameturn");
        deposit = PlayerPrefs.GetInt("inputDeposit");
        bond = PlayerPrefs.GetInt("inputBond");
        stock = PlayerPrefs.GetInt("inputStock");
        extraIncome = PlayerPrefs.GetInt("ExtraIncome");
        stackedExtraIncome = PlayerPrefs.GetInt("StackedExtraIncome");
        stackedSumAllValues = PlayerPrefs.GetFloat("StackedSumAllValues");
        stackedProfit = PlayerPrefs.GetFloat("StackedProfit");
        profit = PlayerPrefs.GetFloat("OnlyProfit");
        itemArray = PlayerPrefsX.GetIntArray("allBoughtItem");
        
        if (turn == 1)
        {
            stackedSumAllValues = 0;
        }

        if (LoadScene.playerName == null)
        {
            LoadScene.playerName = "No name detected";
        }

        CompleteImage.SetActive(false);
        FailImage.SetActive(false);
        
        CalculateEmergencyExpenditureChance();
        SumAllIncome();
        CalculateFinancialObstacle();
        FinancialObstacleChecking();
        ItemEffects();
        SumAllExpenditures();
        CalculateAllValues();
        StackingProfit();
        StackExtraIncome();
        SellInvestment();
        UI_Update();

        // Debug.Log( "Investment: " + investment );
        // Debug.Log( "Budget: " + income );
        // Debug.Log( "All Income: " + allIncome );
        // Debug.Log( "Banked Money: " + savings );
        // Debug.Log( "Happiness: " + happiness );
        // Debug.Log("Stacked Sum Value: " + stackedSumAllValues);
    }

    void Update()
    {
        
    }

    void ItemEffects()
    {
        float eeBeforeCal = emergencyExpenditure;
        float meBeforeCal = mainExpenditure;
        for (int i = 0; i < itemArray.Length; i++)
        {
            if (itemArray[i] == 6)
            {
                emergencyExpenditure = eeBeforeCal * 0.55f;
                Debug.Log("Emergency Expenditure Decreeded");
            }
            else if (itemArray[i] == 7)
            {
                emergencyExpenditure = eeBeforeCal * 0.4f;
                Debug.Log("Emergency Expenditure Decreeded");
            }
            else if (itemArray[i] == 8)
            {
                emergencyExpenditure = eeBeforeCal * 0.35f;
                Debug.Log("Emergency Expenditure Decreeded");
            }
            else if (itemArray[i] == 12)
            {
                mainExpenditure = meBeforeCal * 0.9f;
                Debug.Log("Main Expenditure Decreeded");
            }
            else if (itemArray[i] == 13)
            {
                mainExpenditure = meBeforeCal * 0.86f;
                Debug.Log("Main Expenditure Decreeded");
            }
            else if (itemArray[i] == 14)
            {
                mainExpenditure = meBeforeCal * 0.8f;
                Debug.Log("Main Expenditure Decreeded");
            }
            else if (itemArray[i] == 18)
            {
                mainExpenditure = meBeforeCal * 1.07f;
                Debug.Log("Main Expenditure Increeded");
            }
            else if (itemArray[i] == 19)
            {
                mainExpenditure = meBeforeCal * 1.08f;
                Debug.Log("Main Expenditure Increeded");
            }
            else if (itemArray[i] == 20)
            {
                mainExpenditure = meBeforeCal * 1.1f;
                Debug.Log("Main Expenditure Increeded");
            }
            else if (itemArray[i] == 27)
            {
                mainExpenditure = meBeforeCal * 1.08f;
                Debug.Log("Main Expenditure Increeded");
            }
            else if (itemArray[i] == 28)
            {
                mainExpenditure = meBeforeCal * 1.12f;
                Debug.Log("Main Expenditure Increeded");
            }
            else if (itemArray[i] == 29)
            {
                mainExpenditure = meBeforeCal * 1.19f;
                Debug.Log("Main Expenditure Increeded");
            }
        }
    }

    void StackExtraIncome()
    {
        stackedExtraIncome = stackedExtraIncome + extraIncome;
        Debug.Log("Stacked Extra Income: " + stackedExtraIncome);
    }

    void StackingProfit()
    {
        stackedProfit = stackedProfit + profit;
        Debug.Log("Stacked Profit: " + stackedProfit);
    }

    void FinancialObstacleChecking()
    {
        if ( turn == 4 || turn == 8 || turn == 12)
        {
            financialObstacle = financialObstacleValue;
            Debug.Log( "There is Financial Obstacle." );
        }
        else
        {
            financialObstacle = 0;
            Debug.Log( "No Financial Obstacle." );
        }
    }

    void CalculateFinancialObstacle()
    {
        financialObstacleValue = ( stackedSumAllValues * 0.2f ) * 1.5f + 1500f;
        //Debug.Log( "Financial Obstacle: " + calFinancialObstacle);
    }

    void SumAllIncome()
    {
        allIncome = income + savings + investment;
    }

    void CalculateEmergencyExpenditureChance()
    {
        eeOccurChance = (100 - (float)happiness) / 100;
        Debug.Log( "Emergency Expenditure Occur Chance: " + eeOccurChance );
        if ( Random.value <= eeOccurChance )
        {
            AddEmergencyExpenditure();
        }
        else
        {
            emergencyExpenditure = 0;
            Debug.Log( "No Emergency Expenditure." );
        }
    }

    void AddEmergencyExpenditure()
    {
        float x = (float)income * Random.Range( 0.75f, 1f );
        Debug.Log( "Income after /: " + x );
        emergencyExpenditure = x * eeOccurChance;
        Debug.Log( "Emergency Expenditure: " + emergencyExpenditure );
    }

    void SumAllExpenditures()
    {
        mainExpenditure = income * Random.Range( 0.6f, 0.8f );
        allExpenditure = mainExpenditure + emergencyExpenditure + financialObstacle;
        Debug.Log( "All Expenditure: " + allExpenditure );
    }

    void CalculateAllValues()
    {
        sumAllValues = (float)allIncome - allExpenditure;
        Debug.Log( "Sum All Values: " + sumAllValues );
    }

    void SellInvestment()
    {
        if ( sumAllValues <= 0 )
        {
            sumAllValues += (float)investment * 0.95f;
            investment = 0;
            deposit = 0;
            bond = 0;
            stock = 0;
            PlayerPrefs.SetInt("AllInvestment", investment);
            PlayerPrefs.SetInt("inputStock", stock);
            PlayerPrefs.SetInt("inputBond", bond);
            PlayerPrefs.SetInt("inputDeposit", deposit);

            if ( sumAllValues <= 0 )
            {
                NextButton.interactable = false;
                Invoke("ShowFailImage", 2.5f);
                FailMusic.SetActive(true);
            }
            else
            {
                Invoke("ShowCompleteImage", 5f);
                CompleteMusic.SetActive(true);
            }
        }
        else
        {
            Invoke("ShowCompleteImage", 5f);
            CompleteMusic.SetActive(true);
        }
    }

    void ShowCompleteImage()
    {
        CompleteImage.SetActive(true);
    }

    void ShowFailImage()
    {
        FailImage.SetActive(true);
        Invoke("GoGameOver", 2.5f);
    }

    void GoGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void GoNextTurn()
    {
        if (turn >= 12 )
        {
            SceneManager.LoadScene("Game Over");
        }
        else
        {
            stackedSumAllValues = stackedSumAllValues + sumAllValues;
            Debug.Log("Stacked Value before reset: " + stackedSumAllValues);
            
            //PlayerPrefs.SetInt("allIncome", income);
            PlayerPrefs.SetInt("allSavings", savings);
            PlayerPrefs.SetInt("StackedExtraIncome", stackedExtraIncome);
            PlayerPrefs.SetFloat("StackedProfit", stackedProfit);
            PlayerPrefs.SetFloat("SumAllValues", sumAllValues);

            if (turn == 4 || turn == 8 || turn == 12)
            {
                stackedSumAllValues = 0;
                Debug.Log("Reset Stacked Value: " + stackedSumAllValues);
                Debug.Log("Stack has been reset.");
                PlayerPrefs.SetFloat("StackedSumAllValues", stackedSumAllValues);
            }
            else
            {
                PlayerPrefs.SetFloat("StackedSumAllValues", stackedSumAllValues);
            }
            SceneManager.LoadScene("Turn Counting");
        }
    }

    void UI_Update()
    {
        TurnDisplay.text = $"สรุปรายรับ - รายจ่ายของเทิร์นที่ {turn.ToString()}";

        IncomeDisplay.text = income.ToString("N0");
        SavingsDisplay.text = savings.ToString("N0");
        InvestmentDisplay.text = investment.ToString("N0");
        AllIncomeDisplay.text = allIncome.ToString("N0");

        MainExpenditureDisplay.text = mainExpenditure.ToString("N0");
        EmergencyExpenditureDisplay.text = emergencyExpenditure.ToString("N0");
        FinancialObstacleDisplay.text = financialObstacle.ToString("N0");
        SumAllExpendituresDisplay.text = allExpenditure.ToString("N0");
        NameDisplay.text = LoadScene.playerName.ToString();
        SumAllValuesDisplay.text = sumAllValues.ToString("N0");
    }
}
