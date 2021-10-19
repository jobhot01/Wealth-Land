using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckSourceMoney : MonoBehaviour
{
    public Toggle incomeToggle, savingsToggle;
    public string moneySourceCheck = "None";
    bool isSwap = false;
    [SerializeField] private CalculateSellCards calculateSellCards;
    [SerializeField] private SetupUI setupUI;

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
            //print("Income On");
        }
        else if (incomeToggle.isOn == true && savingsToggle.isOn == true)
        {
            setupUI.income = setupUI.income - calculateSellCards.allItemBuyValue;
            setupUI.savings = setupUI.savings + calculateSellCards.allItemBuyValue;
            calculateSellCards.updateUI = true;
            moneySourceCheck = "Income";
            //print("Income Swap");
            isSwap = true;
            savingsToggle.GetComponent<Toggle>().isOn = false;
        }
        else if (incomeToggle.isOn == false)
        {
            if (isSwap == false)
            {
                setupUI.income = setupUI.income + calculateSellCards.allItemBuyValue;
                calculateSellCards.updateUI = true;
                moneySourceCheck = "None";
                //print("Income Off");
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
            //print("Savings On");
        }
        else if (savingsToggle.isOn == true && incomeToggle.isOn == true)
        {
            setupUI.savings = setupUI.savings - calculateSellCards.allItemBuyValue;
            setupUI.income = setupUI.income + calculateSellCards.allItemBuyValue;
            calculateSellCards.updateUI = true;
            moneySourceCheck = "Savings";
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
                //print("Savings Off");
            }
            else if (isSwap == true)
            {
                isSwap = false;
            }
        }
    }
}
