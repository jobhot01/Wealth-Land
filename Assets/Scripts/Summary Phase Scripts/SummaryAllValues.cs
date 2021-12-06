using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

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
    int fristIncome;
    int savings;
    int investment;
    int happiness;
    int allIncome;
    int remainingIncome;
    int turn;
    int deposit;
    int bond;
    int stock;
    int extraIncome;
    int stackedExtraIncome;
    int eventSum;
    int eventIncome;
    int eventCost;

    void Start()
    {
        GetPlayerPrefValues();
        
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
        ItemEffects();
        CalculateFinancialObstacle();
        FinancialObstacleChecking();
        CalculateEventSummary();
        SumAllIncome();
        SumAllExpenditures();
        CalculateAllValues();
        StackingProfit();
        StackExtraIncome();
        SellInvestment();
        UI_Update();
    }

    void GetPlayerPrefValues()
    {
        investment = PlayerPrefs.GetInt("AllInvestment");
        fristIncome = PlayerPrefs.GetInt("FirstIncome");
        remainingIncome = PlayerPrefs.GetInt("allIncome");
        savings = PlayerPrefs.GetInt("allSavings");
        happiness = PlayerPrefs.GetInt("myHappiness");
        turn = PlayerPrefs.GetInt("gameturn");
        deposit = PlayerPrefs.GetInt("inputDeposit");
        bond = PlayerPrefs.GetInt("inputBond");
        stock = PlayerPrefs.GetInt("inputStock");
        eventSum = PlayerPrefs.GetInt("EventSum");
        extraIncome = PlayerPrefs.GetInt("ExtraIncome");
        stackedExtraIncome = PlayerPrefs.GetInt("StackedExtraIncome");
        stackedSumAllValues = PlayerPrefs.GetFloat("StackedSumAllValues");
        stackedProfit = PlayerPrefs.GetFloat("StackedProfit");
        profit = PlayerPrefs.GetFloat("OnlyProfit");
        itemArray = PlayerPrefsX.GetIntArray("allBoughtItem");
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

    void CalculateEventSummary()
    {
        Debug.Log("Event Sum: " + eventSum);
        if (eventSum >= 0)
        {
            eventIncome = eventSum;
            Debug.Log("Event Income: " + eventIncome);
        }
        else if (eventSum < 0)
        {
            eventCost = eventSum * -1;
            Debug.Log("Event Cost: " + eventCost);
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
    }

    void SumAllIncome()
    {
        remainingIncome = remainingIncome + eventIncome;
        allIncome = remainingIncome + savings + investment;
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
        }
    }

    void AddEmergencyExpenditure()
    {
        float x = (float)fristIncome * Random.Range( 0.75f, 1f );
        Debug.Log( "Income after /: " + x );
        emergencyExpenditure = x * eeOccurChance + eventCost;
        Debug.Log( "Emergency Expenditure: " + emergencyExpenditure );
    }

    void SumAllExpenditures()
    {
        mainExpenditure = fristIncome * Random.Range( 0.6f, 0.8f );
        emergencyExpenditure += eventCost;
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
            FailMusic.SetActive(true);
        }
        else
        {
            CompleteMusic.SetActive(true);
        }
    }

    void LoadNextTurn()
    {
        SceneManager.LoadScene("Turn Counting");
    }

    void GoGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    void GoEndCutscene()
    {
        SceneManager.LoadScene("EndCutscene");
    }

    public void GoNextTurn()
    {
        System.DateTime stopTime;
        if ( sumAllValues >= 0 )
        {
            CompleteImage.SetActive(true);
            NextButton.interactable = false;
            stackedSumAllValues = stackedSumAllValues + sumAllValues;
            Debug.Log("Stacked Value before reset: " + stackedSumAllValues);
            
            PlayerPrefs.SetInt("allSavings", savings);
            PlayerPrefs.SetInt("StackedExtraIncome", stackedExtraIncome);
            PlayerPrefs.SetFloat("StackedProfit", stackedProfit);
            PlayerPrefs.SetFloat("SumAllValues", sumAllValues);

            if (turn == 4 || turn == 8 || turn == 12)
            {
                stackedSumAllValues = 0;
                PlayerPrefs.DeleteKey("StackedSumAllValues");
                Debug.Log("Stack has been reset.");
                if (turn >= 12)
                {
                    float allValue = PlayerPrefs.GetFloat("SumAllValues");
                    int extraIncome = PlayerPrefs.GetInt("StackedExtraIncome");
                    float stackedProfit = PlayerPrefs.GetInt("StackedProfit");
                    AnalyticsResult completeGameAnalytics = Analytics.CustomEvent("CompleteGame", new Dictionary<string, object>
                    {
                        {"Value", allValue},
                        {"ExtraIncome", extraIncome},
                        {"Profit", stackedProfit}
                    });
                    Debug.Log("AnalyticsResult of CompleteGameAllValue of " + allValue + " is " + completeGameAnalytics);
                    //AnalyticsResult stackedExtraIncomeAnalytics = Analytics.CustomEvent("CompleteGameStackedExtraIncome", new Dictionary<string, object>
                    //{
                    //    {"ExtraIncome", extraIncome},
                    //});
                    //Debug.Log("AnalyticsResult of CompleteGameStackedExtraIncome of " + extraIncome + " is " + stackedExtraIncomeAnalytics);
                    //AnalyticsResult stackedProfitAnalytics = Analytics.CustomEvent("CompleteGameStackedProfitTime", new Dictionary<string, object>
                    //{
                    //    {"Profit", stackedProfit},
                    //});
                    //Debug.Log("AnalyticsResult of CompleteTime of " + stackedProfit + " is " + stackedProfitAnalytics);
                    stopTime = System.DateTime.UtcNow;
                    System.TimeSpan tsa = stopTime - GameController.startTime;
                    AnalyticsResult finalTimeAnalytics = Analytics.CustomEvent("CompleteTime", new Dictionary<string, object>
                    {
                        {"Time", tsa.Seconds.ToString()}
                    });
                    Debug.Log("AnalyticsResult of CompleteTime of " + tsa.Seconds.ToString() + " is " + finalTimeAnalytics);
                    //AnalyticsResult completeGame = Analytics.CustomEvent("CompleteGame");
                    //Debug.Log("AnalyticsResult of CompleteGame is " + completeGame);
                    PlayerPrefs.SetInt("LastTurn", turn);
                    Invoke("GoEndCutscene", 2.5f);
                }
                else
                {
                    Invoke("LoadNextTurn", 2.5f);
                }
            }
            else
            {
                if (turn == 1)
                {
                    stopTime = System.DateTime.UtcNow;
                    System.TimeSpan tsf = stopTime - GameController.startTime;
                    AnalyticsResult firstTimeAnalytics = Analytics.CustomEvent("FirstTurnTime", new Dictionary<string, object>
                    {
                        {"Time", tsf.Seconds.ToString()}
                    });
                    Debug.Log("AnalyticsResult of FirstTurnTime of " + tsf.Seconds.ToString() + " is " + firstTimeAnalytics);
                }
                PlayerPrefs.SetFloat("StackedSumAllValues", stackedSumAllValues);
                Invoke("LoadNextTurn", 2.5f);
            }
        }
        else if (sumAllValues < 0)
        {
            FailImage.SetActive(true);
            PlayerPrefs.SetInt("LastTurn", turn);
            PlayerPrefs.SetFloat("StackedProfit", stackedProfit);
            PlayerPrefs.SetInt("StackedExtraIncome", stackedExtraIncome);
            PlayerPrefs.SetFloat("SumAllValues", sumAllValues);
            AnalyticsResult gameOverAnalytics = Analytics.CustomEvent("GameOver", new Dictionary<string, object>
                    {
                        {"Turn", turn},
                        {"StackedProfit", stackedProfit},
                        {"StackedExtraIncome", stackedExtraIncome},
                        {"SumAllValues", sumAllValues}
                    });
            Debug.Log("AnalyticsResult of GameOver of " + turn + " is " + gameOverAnalytics);
            NextButton.interactable = false;
            Invoke("GoGameOver", 2.5f);
        }
    }

    void UI_Update()
    {
        TurnDisplay.text = $"สรุปรายรับ - รายจ่ายของเทิร์นที่ {turn.ToString()}";
        IncomeDisplay.text = remainingIncome.ToString("N2");
        SavingsDisplay.text = savings.ToString("N2");
        InvestmentDisplay.text = investment.ToString("N2");
        AllIncomeDisplay.text = allIncome.ToString("N2");
        MainExpenditureDisplay.text = mainExpenditure.ToString("N2");
        EmergencyExpenditureDisplay.text = emergencyExpenditure.ToString("N2");
        FinancialObstacleDisplay.text = financialObstacle.ToString("N2");
        SumAllExpendituresDisplay.text = allExpenditure.ToString("N2");
        NameDisplay.text = LoadScene.playerName.ToString();
        SumAllValuesDisplay.text = sumAllValues.ToString("N2");
    }
}
