using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    // [SerializeField] private AudioSource BottomSoundObj;
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
        
        if ( audioObject == null)
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
        audioSource.Play();
        SceneManager.LoadScene("Main Menu");
    }

    public void BackToMainMenu()
    {
        //PlayerPrefs.SetFloat("Volume", VolumeContoller.musicVolume);
        audioSource.Play();
        wentOptions = 1;
        SceneManager.LoadScene("Main Menu");
    }

    public void GoOptionMenu()
    {
        audioSource.Play();
        wentOptions = 1;
        PlayerPrefs.SetInt("WentOption",wentOptions);
        SceneManager.LoadScene("Option");
    }
    
    public void GoCharacterSelec()
    {
        //PlayerPrefs.SetFloat("Volume", 0.6f);
        audioSource.Play();
        wentOptions = PlayerPrefs.GetInt("WentOption");
        if (wentOptions == 0)
        {
            PlayerPrefs.SetFloat("Volume", 0.6f);
            Debug.Log(wentOptions);
        }
        else if (wentOptions == 1)
        {
            Debug.Log("No change");
        }

        SceneManager.LoadScene("CharacterSelec");
    }
    
    public void GoCutscene()
    {
        playerHobby = hobbySelect.hobby;
        playerGender = genderSelect.gender;
        playerName = inputName.name;
        randomHobbyValue = Random.Range(10, 16);
        audioSource.Play();
        SceneManager.LoadScene("Cutscene");
    }

    public void GoTutorial()
    {
        audioSource.Play();
        SceneManager.LoadScene("Tutorial");
    }

    public void GoGameplay()
    {
        //print("Name: " + playerName + " Gender: " + playerGender + " Hobby: " + playerHobby + " Hobby Value: " + randomHobbyValue);
        audioSource.Play();
        SceneManager.LoadScene("Turn Counting");
    }

    public void GoLastScene()
    {
        audioSource.Play();
        SceneManager.LoadScene("Game Over");
    }

    public void GoNextPhase()
    {
        audioSource.Play();
        sceneBuildIndex = scene.buildIndex + 1;
        switch (sceneBuildIndex)
        {
            case 5:
                PlayerPrefs.SetInt("allSavings", GameController.savingsInt);
                PlayerPrefs.SetInt("FirstIncome", GameController.mainIncomeInt);
                PlayerPrefs.SetFloat("OnlyProfit", GameController.profitDifferent);
                //BottomSoundObj.PlayOneShot(BottomSound);
                // BottomSoundObj.Play();
                // audioSource.Play();
                //PlayerPrefs.SetString("PlayerName", playerName);
                break;
            case 6:
                PlayerPrefs.SetInt("allIncome", calculateValue.sumIncome);
                PlayerPrefs.SetInt("myHappiness", calculateValue.happiness);
                PlayerPrefs.SetInt("ExtraIncome", calculateValue.allExtraIncome);
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
                break;
            case 8:
                PlayerPrefs.SetInt("allIncome", setupUI.income);
                PlayerPrefs.SetInt("allSavings", setupUI.savings);
                if (checkSourceMoney.moneySourceCheck == "Income" || checkSourceMoney.moneySourceCheck == "Savings")
                {
                    int[] boughtCardsArray = setupCard.boughtCards.ToArray();
                    for (int i = 0; i < boughtCardsArray.Length; i++)
                    {
                        print("Buy Card Index: " + boughtCardsArray[i]);
                    }
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
                }
                else
                {
                    PlayerPrefs.SetInt("AllInvestment", 0);
                    PlayerPrefs.SetInt("inputStock", 0);
                    PlayerPrefs.SetInt("inputBond", 0);
                    PlayerPrefs.SetInt("inputDeposit", 0);
                }
                break;
        }
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
