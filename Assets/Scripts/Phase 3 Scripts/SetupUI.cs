using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupUI : MonoBehaviour
{
    public Text incomeText, savingsText, nameDisplay;
    public Button nextButton;
    public int income, savings;
    [SerializeField] CalculateSellCards calculateSellCards;

    void Start()
    {
        income = PlayerPrefs.GetInt("allIncome");
        savings = PlayerPrefs.GetInt("allSavings");

        if (LoadScene.playerName == null)
        {
            LoadScene.playerName = "No name detected";
        }
        
        UpdateUI();
    }

    void Update()
    {
        if (calculateSellCards.updateUI == true)
        {
            UpdateUI();
            CheckButton();
            calculateSellCards.updateUI = false;
        }
    }

    public void UpdateUI()
    {
        incomeText.text = "เงินที่เหลือ           " + income.ToString("N0") + "   บาท";
        savingsText.text = "เงินเก็บทั้งหมด           " + savings.ToString("N0") + "   บาท";
        nameDisplay.text = LoadScene.playerName.ToString();
    }

    public void CheckButton()
    {
        if (income < 0 || savings < 0)
        {
            nextButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
            nextButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            nextButton.GetComponent<Image>().color = new Color(255, 255, 255, 1);
            nextButton.GetComponent<Button>().interactable = true;
        }
    }
}
