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
        CalculateEventSummary();
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

    void CalculateEventSummary()
    {
        Debug.Log("Event Sum: " + eventSum);
        if (eventSum >= 0)
        {
            eventIncome = eventSum;
        }
        else if (eventSum < 0)
        {
            eventCost = eventSum * -1;
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
        remainingIncome += eventIncome;
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
            //Debug.Log( "Only Event Cost: " + eventCost );
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
            sumAllValues += (float)investment * 0.95f;
            PlayerPrefs.SetInt("AllInvestment", 0);
            PlayerPrefs.SetInt("inputStock", 0);
            PlayerPrefs.SetInt("inputBond", 0);
            PlayerPrefs.SetInt("inputDeposit", 0);

            if ( sumAllValues <= 0 )
            {
                //NextButton.interactable = false;
                //Invoke("ShowFailImage", 2.5f);
                FailMusic.SetActive(true);
            }
            else
            {
                //Invoke("ShowCompleteImage", 5f);
                CompleteMusic.SetActive(true);
            }
        }
        else
        {
            //Invoke("ShowCompleteImage", 5f);
            CompleteMusic.SetActive(true);
        }
    }

    void ShowCompleteImage()
    {
        //CompleteImage.SetActive(true);
    }

    void ShowFailImage()
    {
        //FailImage.SetActive(true);
        //Invoke("GoGameOver", 2.5f);
    }

    void LoadNextTurn()
    {
        SceneManager.LoadScene("Turn Counting");
    }

    void GoGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void GoNextTurn()
    {
        if ( sumAllValues > 0 )
        {
            CompleteImage.SetActive(true);
            NextButton.interactable = false;
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
                PlayerPrefs.DeleteKey("StackedSumAllValues");
                Debug.Log("Reset Stacked Value: " + stackedSumAllValues);
                Debug.Log("Stack has been reset.");
                if (turn >= 12)
                {
                    Invoke("GoGameOver", 1.5f);
                }
                else
                {
                    Invoke("LoadNextTurn", 1.5f);
                }
            }
            else
            {
                PlayerPrefs.SetFloat("StackedSumAllValues", stackedSumAllValues);
                Invoke("LoadNextTurn", 1.5f);
            }
        }
        else if (sumAllValues <= 0)
        {
            FailImage.SetActive(true);
            PlayerPrefs.SetFloat("StackedProfit", stackedProfit);
            PlayerPrefs.SetInt("StackedExtraIncome", stackedExtraIncome);
            PlayerPrefs.SetFloat("SumAllValues", sumAllValues);
            NextButton.interactable = false;
            Invoke("GoGameOver", 1.5f);
        }
    
        //if (turn >= 12 )
        //{
            // stackedSumAllValues = stackedSumAllValues + sumAllValues;
            // PlayerPrefs.SetFloat("StackedProfit", stackedProfit);
            // PlayerPrefs.SetInt("StackedExtraIncome", stackedExtraIncome);
            // PlayerPrefs.SetFloat("SumAllValues", sumAllValues);
            // NextButton.interactable = false;
            // Invoke("GoGameOver", 2.5f);
        //}
        //else
        //{
            
        //}
    }

    void UI_Update()
    {
        TurnDisplay.text = $"สรุปรายรับ - รายจ่ายของเทิร์นที่ {turn.ToString()}";

        IncomeDisplay.text = remainingIncome.ToString("N0");
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
