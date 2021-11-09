using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class LoadScene : MonoBehaviour
{
    Scene scene;
    int sceneBuildIndex;
    [SerializeField] private HobbySelect hobbySelect;
    [SerializeField] private GenderSelect genderSelect;
    [SerializeField] private InputName inputName;
    [SerializeField] private CalculateValue calculateValue;
    [SerializeField] private CalculateSavings calculateSavings;
    [SerializeField] private OnStartPhase onStartPhase;
    [SerializeField] private SetupUI setupUI;
    [SerializeField] private SetupCard setupCard;
    [SerializeField] private CheckSourceMoney checkSourceMoney;
    [SerializeField] private StartupInvestment startupInvestment;
    [SerializeField] private CheckMoney checkMoney;
    [SerializeField] private CalculateAllInvestment calculateAllInvestment;
    [SerializeField] private AudioController audioController;
    // [SerializeField] private AudioClip BottomSound;
    public GameObject audioObject;
    AudioSource audioSource;
    float musicVolume = 1f;
    int wentOptions = 0;

    public static string playerHobby, playerGender, playerName;
    public static int randomHobbyValue;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        audioObject = GameObject.FindWithTag("BottomSound");

        if (audioObject == null)
        {
            Debug.LogWarning("Audio Object not found!!");
        }
        else
        {
            audioSource = audioObject.GetComponent<AudioSource>();
            musicVolume = PlayerPrefs.GetFloat("Volume");
            audioSource.volume = musicVolume;
        }
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void BackToMainMenu()
    {
        //PlayerPrefs.SetFloat("Volume", VolumeContoller.musicVolume);
        //audioController.enabled = true;
        wentOptions = 1;
        audioController.enabled = true;
        SceneManager.LoadScene("Main Menu");
    }

    public void RetryNewGame()
    {
        PlayerPrefs.DeleteKey("allSavings");
        PlayerPrefs.DeleteKey("FirstIncome");
        PlayerPrefs.DeleteKey("OnlyProfit");
        PlayerPrefs.DeleteKey("myHappiness");
        PlayerPrefs.DeleteKey("ExtraIncome");
        PlayerPrefs.DeleteKey("allIncome");
        PlayerPrefs.DeleteKey("allBoughtItem");
        PlayerPrefs.DeleteKey("randomStock");
        PlayerPrefs.DeleteKey("randomBond");
        PlayerPrefs.DeleteKey("randomDeposit");
        PlayerPrefs.DeleteKey("AllInvestment");
        PlayerPrefs.DeleteKey("inputStock");
        PlayerPrefs.DeleteKey("inputBond");
        PlayerPrefs.DeleteKey("inputDeposit");
        PlayerPrefs.DeleteKey("SumAllValues");
        PlayerPrefs.DeleteKey("StackedExtraIncome");
        PlayerPrefs.DeleteKey("StackedProfit");
        PlayerPrefs.DeleteKey("StackedSumAllValues");
        PlayerPrefs.DeleteKey("EventSum");
        PlayerPrefs.DeleteKey("LastTurn");
        PlayerPrefs.DeleteKey("gameturn");
        //PlayerPrefs.SetInt("gameturn", 0);
        //float volume = PlayerPrefs.GetFloat("volume");
        Debug.Log($"Deleted all PlayerPrefs data except Volume.");
        SceneManager.LoadScene("Main Menu");
    }

    public void GoOptionMenu()
    {
        wentOptions = 1;
        PlayerPrefs.SetInt("WentOption", wentOptions);
        SceneManager.LoadScene("Option");
    }

    public void GoCredit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void GoCharacterSelec()
    {
        //PlayerPrefs.SetFloat("Volume", 0.6f);
        wentOptions = PlayerPrefs.GetInt("WentOption");
        if (wentOptions == 0)
        {
            PlayerPrefs.SetFloat("Volume", 0.35f);
            Debug.Log(wentOptions);
        }
        else if (wentOptions == 1)
        {
            //audioController.enabled = true;
            Debug.Log("No change");
        }

        SceneManager.LoadScene("CharacterSelec");
    }

    public void GoCutscene()
    {
        playerHobby = hobbySelect.hobby;
        playerGender = genderSelect.gender;
        playerName = inputName.playerName;
        AnalyticsResult genderAnalytics = Analytics.CustomEvent("PlayerGender", new Dictionary<string, object>
        {
            {"Gender", playerGender}
        });
        Debug.Log("AnalyticsResult of PlayerGender " + playerGender + "  is " + genderAnalytics);
        AnalyticsResult hobbyAnalytics = Analytics.CustomEvent("SelectHobby", new Dictionary<string, object>
        {
            {"Hobby", playerHobby}
        });
        Debug.Log("AnalyticsResult of SelectHobby " + playerHobby + "  is " + hobbyAnalytics);
        randomHobbyValue = Random.Range(10, 16);
        SceneManager.LoadScene("Cutscene");
    }

    public void GoTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void GoGameplay()
    {
        //print("Name: " + playerName + " Gender: " + playerGender + " Hobby: " + playerHobby + " Hobby Value: " + randomHobbyValue);
        SceneManager.LoadScene("Turn Counting");
    }

    public void GoLastScene()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void GoNextPhase()
    {
        int turn = PlayerPrefs.GetInt("gameturn");
        sceneBuildIndex = scene.buildIndex + 1;
        switch (sceneBuildIndex)
        {
            case 5:
                PlayerPrefs.SetInt("allSavings", GameController.savingsInt);
                PlayerPrefs.SetInt("FirstIncome", GameController.mainIncomeInt);
                PlayerPrefs.SetFloat("OnlyProfit", GameController.profitDifferent);
                break;
            case 6:
                PlayerPrefs.SetInt("allIncome", calculateValue.sumIncome);
                PlayerPrefs.SetInt("myHappiness", calculateValue.happiness);
                PlayerPrefs.SetInt("ExtraIncome", calculateValue.allExtraIncome);
                for (int i = 0; i < calculateValue.selectCard.Count; i++)
                {
                    AnalyticsResult occupationAnalytics = Analytics.CustomEvent("OccupationSelect", new Dictionary<string, object>
                    {
                        {"Turn", turn.ToString()},
                        {"Occupation",calculateValue.selectCard[i]}
                    });
                    Debug.Log("AnalyticsResult of OccupationSelect of " + calculateValue.selectCard[i] + " is " + occupationAnalytics);
                }
                break;
            case 7:
                int sumSavings;
                sumSavings = onStartPhase.previousSavings + calculateSavings.accountValue;
                if (calculateSavings.useSavings == true)
                {
                    PlayerPrefs.SetInt("allIncome", calculateSavings.remainingValue);
                }
                else if (calculateSavings.useSavings == false)
                {
                    PlayerPrefs.SetInt("allIncome", onStartPhase.myIncome);
                }
                PlayerPrefs.SetInt("allSavings", sumSavings);
                AnalyticsResult savingsAnalytics = Analytics.CustomEvent("SavingsPercent", new Dictionary<string, object>
                    {
                        {"Turn", turn.ToString()},
                        {"Percent", calculateSavings.percent}
                    });
                Debug.Log("AnalyticsResult of SavingsPercent of " + calculateSavings.percent + " is " + savingsAnalytics);
                break;
            case 8:
                PlayerPrefs.SetInt("allIncome", setupUI.income);
                PlayerPrefs.SetInt("allSavings", setupUI.savings);
                if (checkSourceMoney.moneySourceCheck == "Income" || checkSourceMoney.moneySourceCheck == "Savings")
                {
                    int[] boughtCardsArray = setupCard.boughtCards.ToArray();
                    CheckSentItem(boughtCardsArray, turn);
                    PlayerPrefsX.SetIntArray("allBoughtItem", boughtCardsArray);
                    //https://wiki.unity3d.com/index.php/ArrayPrefs2
                }
                break;
            case 9:
                PlayerPrefs.SetInt("allIncome", startupInvestment.budget);
                PlayerPrefs.SetInt("allSavings", startupInvestment.bankedMoney);
                PlayerPrefs.SetFloat("randomStock", startupInvestment.stockProfitPercentage);
                PlayerPrefs.SetFloat("randomBond", startupInvestment.bondProfitPercentage);
                PlayerPrefs.SetFloat("randomDeposit", startupInvestment.depositProfitPercentage);
                print("Random Stock: " + startupInvestment.stockProfitPercentage);
                print("Random Bond: " + startupInvestment.bondProfitPercentage);
                print("Random Deposit: " + startupInvestment.depositProfitPercentage);
                if (checkMoney.budgetCheck == "Budget" || checkMoney.budgetCheck == "BankedMoney")
                {
                    print("Stock: " + calculateAllInvestment.stock);
                    print("Bond: " + calculateAllInvestment.bond);
                    print("Deposit: " + calculateAllInvestment.deposit);
                    PlayerPrefs.SetInt("AllInvestment", calculateAllInvestment.allInvestment);
                    PlayerPrefs.SetInt("inputStock", calculateAllInvestment.stock);
                    PlayerPrefs.SetInt("inputBond", calculateAllInvestment.bond);
                    PlayerPrefs.SetInt("inputDeposit", calculateAllInvestment.deposit);
                    AnalyticsResult investmentAnalytics = Analytics.CustomEvent("PlayerInvestment", new Dictionary<string, object>
                    {
                        {"Turn", turn.ToString()},
                        {"Investment", calculateAllInvestment.allInvestment}
                    });
                    Debug.Log("AnalyticsResult of PlayerInvestment of " + calculateAllInvestment.allInvestment + " is " + investmentAnalytics);
                    AnalyticsResult stockAnalytics = Analytics.CustomEvent("PlayerStock ", new Dictionary<string, object>
                    {
                        {"Turn", turn.ToString()},
                        {"Stock", calculateAllInvestment.stock}
                    });
                    Debug.Log("AnalyticsResult of PlayerStock of " + calculateAllInvestment.stock + " is " + stockAnalytics);
                    AnalyticsResult bondAnalytics = Analytics.CustomEvent("PlayerBond", new Dictionary<string, object>
                    {
                        {"Turn", turn.ToString()},
                        {"Bond", calculateAllInvestment.bond}
                    });
                    Debug.Log("AnalyticsResult of PlayerBond of " + calculateAllInvestment.bond + " is " + bondAnalytics);
                    AnalyticsResult depositAnalytics = Analytics.CustomEvent("PlayerDeposit", new Dictionary<string, object>
                    {
                        {"Turn", turn.ToString()},
                        {"Deposit", calculateAllInvestment.deposit}
                    });
                    Debug.Log("AnalyticsResult of PlayerDeposit of " + calculateAllInvestment.deposit + " is " + depositAnalytics);
                }
                else
                {
                    PlayerPrefs.SetInt("AllInvestment", 0);
                    PlayerPrefs.SetInt("inputStock", 0);
                    PlayerPrefs.SetInt("inputBond", 0);
                    PlayerPrefs.SetInt("inputDeposit", 0);
                }
                break;

            case 10:
                PlayerPrefs.SetInt("EventSum", GameEventsManager.eventSum);
                Debug.Log("Scene: " + sceneBuildIndex);
                break;
        }
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public void TimeOut()
    {
        sceneBuildIndex = scene.buildIndex + 1;
        switch (sceneBuildIndex)
        {
            case 6:
                PlayerPrefs.SetInt("allIncome", calculateValue.sumIncome);
                break;

            case 9:
                PlayerPrefs.SetInt("AllInvestment", 0);
                PlayerPrefs.SetInt("inputStock", 0);
                PlayerPrefs.SetInt("inputBond", 0);
                PlayerPrefs.SetInt("inputDeposit", 0);
                break;
        }
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }

    void CheckSentItem(int[] boughtItem, int turn)
    {
        int[] permanentItem = new int[] { 12, 13, 14, 18, 19, 20, 24, 25, 26, 27, 28, 29 };
        string[] itemName = new string[] {"LiveEquipment1","LiveEquipment2","LiveEquipment3",
        "Snacks1","Snacks2","Snacks3","HealthEquipment1","HealthEquipment2","HealthEquipment3",
        "PlantingKit1","PlantingKit2","PlantingKit3","SolarCells1","SolarCells2","SolarCells3",
        "Fashion1","Fashion2","Fashion3","Car1","Car2","Car3","Book1","Book2","Book3","CraftSet1",
        "CraftSet2","CraftSet3","Pet1","Pet2","Pet3","Gadget1","Gadget2","Gadget3","Toy1","Toy2",
        "Toy3"};
        List<int> checkSameItem = new List<int>();
        List<string> itemNameToSent = new List<string>();
        bool toCheck = false;
        bool noAdd = false;
        int nameIndex;
        List<int> purchaseItem = new List<int>();
        int[] purchasePermanentItem;

        if (turn == 1)
        {
            PlayerPrefs.DeleteKey("PurchaseItemAlready");
        }
        else
        {
            purchasePermanentItem = PlayerPrefsX.GetIntArray("PurchaseItemAlready");
            for (int i = 0; i < purchasePermanentItem.Length; i++)
            {
                purchaseItem.Add(purchasePermanentItem[i]);
            }
        }

        for (int i = 0; i < boughtItem.Length; i++)
        {
            for (int j = 0; j < permanentItem.Length; j++)
            {
                if (boughtItem[i] == permanentItem[j])
                {
                    toCheck = true;
                }
            }
            if (toCheck == true)
            {
                checkSameItem.Add(boughtItem[i]);
                toCheck = false;
            }
            else if (toCheck == false)
            {
                nameIndex = boughtItem[i];
                itemNameToSent.Add(itemName[nameIndex]);
            }
        }
        for (int i = 0; i < checkSameItem.Count; i++)
        {
            for (int j = 0; j < purchaseItem.Count; j++)
            {
                if (checkSameItem[i] == purchaseItem[j])
                {
                    noAdd = true;
                }
            }
            if (noAdd == false)
            {
                purchaseItem.Add(checkSameItem[i]);
                nameIndex = checkSameItem[i];
                itemNameToSent.Add(itemName[nameIndex]);
            }
            else if (noAdd == true)
            {
                noAdd = false;
            }
        }
        for (int i = 0; i < itemNameToSent.Count; i++)
        {
            AnalyticsResult itemAnalytics = Analytics.CustomEvent("ItemSelect", new Dictionary<string, object>
                        {
                            {"Turn", turn.ToString()},
                            {"Item Index",itemNameToSent[i]}
                        });
            Debug.Log("AnalyticsResult of ItemSelect of " + itemNameToSent[i] + " is " + itemAnalytics);
            //print("Buy Card Index: " + boughtCardsArray[i]);
        }
        PlayerPrefsX.SetIntArray("PurchaseItemAlready", purchaseItem.ToArray());
    }
}
