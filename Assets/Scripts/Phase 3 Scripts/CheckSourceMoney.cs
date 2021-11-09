using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckSourceMoney : MonoBehaviour
{
    public Toggle incomeToggle, savingsToggle;
    public string moneySourceCheck = "None";
    public bool isToggleOn = false;
    public GameObject[] itemStamp;
    bool isSwap = false;
    [SerializeField] private CalculateSellCards calculateSellCards;
    [SerializeField] private SetupUI setupUI;
    [SerializeField] private SetupCard setupCard;
    [SerializeField] private ClickItemCard[] clickItemCards;

    public void CheckIncome()
    {
        IncomeAction();
    }

    public void CheckSavings()
    {
        SavingsAction();
    }

    public void IncomeAction()
    {
        if (incomeToggle.isOn == true && savingsToggle.isOn == false)
        {
            setupUI.income = setupUI.income - calculateSellCards.allItemBuyValue;
            calculateSellCards.updateUI = true;
            moneySourceCheck = "Income";
            isToggleOn = true;
            print("Income On");
        }
        else if (incomeToggle.isOn == true && savingsToggle.isOn == true)
        {
            setupUI.income = setupUI.income - calculateSellCards.allItemBuyValue;
            setupUI.savings = setupUI.savings + calculateSellCards.allItemBuyValue;
            calculateSellCards.updateUI = true;
            moneySourceCheck = "Income";
            print("Income Swap");
            isSwap = true;
            isToggleOn = true;
            savingsToggle.GetComponent<Toggle>().isOn = false;
        }
        else if (incomeToggle.isOn == false)
        {
            if (isSwap == false)
            {
                setupUI.income = setupUI.income + calculateSellCards.allItemBuyValue;
                calculateSellCards.updateUI = true;
                moneySourceCheck = "None";
                isToggleOn = false;
                ResetValueAndStamp();
                print("Income Off");
            }
            else if (isSwap == true)
            {
                isSwap = false;
            }
        }
    }

    public void SavingsAction()
    {
        if (savingsToggle.isOn == true && incomeToggle.isOn == false)
        {
            setupUI.savings = setupUI.savings - calculateSellCards.allItemBuyValue;
            calculateSellCards.updateUI = true;
            moneySourceCheck = "Savings";
            isToggleOn = true;
            //print("Savings On");
        }
        else if (savingsToggle.isOn == true && incomeToggle.isOn == true)
        {
            setupUI.savings = setupUI.savings - calculateSellCards.allItemBuyValue;
            setupUI.income = setupUI.income + calculateSellCards.allItemBuyValue;
            calculateSellCards.updateUI = true;
            moneySourceCheck = "Savings";
            isToggleOn = true;
            //print("Savings Swap");
            isSwap = true;
            incomeToggle.GetComponent<Toggle>().isOn = false;
        }
        else if (savingsToggle.isOn == false)
        {
            if (isSwap == false)
            {
                setupUI.savings = setupUI.savings + calculateSellCards.allItemBuyValue;
                calculateSellCards.updateUI = true;
                moneySourceCheck = "None";
                isToggleOn = false;
                ResetValueAndStamp();
                //print("Savings Off");
            }
            else if (isSwap == true)
            {
                isSwap = false;
            }
        }
    }

    public void ResetValueAndStamp()
    {
        bool isPermanentItem = false;
        for (int i = 0;i < itemStamp.Length; i++)
        {
            itemStamp[i].SetActive(false);
        }
        for (int i = 0;i < setupCard.boughtCards.Count; i++)
        {
            for (int j = 0;j < setupCard.boughtPermanentItem.Count; j++)
            {
                if (setupCard.boughtCards[i] == setupCard.boughtPermanentItem[j])
                {
                    isPermanentItem = true;
                }
            }
            if (isPermanentItem == false)
            {
                setupCard.boughtCards.RemoveAt(i);
            }
            else if (isPermanentItem == true)
            {
                isPermanentItem = false;
            }
        }
        calculateSellCards.allItemBuyValue = 0;
        for (int i = 0;i < clickItemCards.Length; i++)
        {
            clickItemCards[i].isClick = false;
        }
    }
}
