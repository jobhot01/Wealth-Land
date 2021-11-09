using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckMoney : MonoBehaviour
{
    public string budgetCheck = "None";
    public Text remainingBankedMoneyDisplayer, remainingBudgetDisplayer;
    public Toggle budgetToggle, bankedMoneyToggle;
    public InputField depositInput, bondInput, stockInput;
    bool isSwap = false;
    [SerializeField] private StartupInvestment startupInvestment;
    [SerializeField] private CalculateAllInvestment calculateAllInvestment;

    public void CheckBudget()
    {
        BudgetAction();
    }

    public void CheckBankedMoney()
    {
        SavingsAction();
    }

    public void BudgetAction()
    {
        if (budgetToggle.isOn == true && bankedMoneyToggle.isOn == false)
        {
            OpenInputField();
            startupInvestment.budget = startupInvestment.budget - calculateAllInvestment.allInvestment;
            UpdateText();
            budgetCheck = "Budget";
        }
        else if (budgetToggle.isOn == true && bankedMoneyToggle.isOn == true)
        {
            OpenInputField();
            startupInvestment.budget = startupInvestment.budget - calculateAllInvestment.allInvestment;
            startupInvestment.bankedMoney = startupInvestment.bankedMoney + calculateAllInvestment.allInvestment;
            UpdateText();
            budgetCheck = "Budget";
            isSwap = true;
            bankedMoneyToggle.GetComponent<Toggle>().isOn = false;
        }
        else if (bankedMoneyToggle.isOn == false)
        {
            if (isSwap == false)
            {
                CloseInputField();
                startupInvestment.budget = startupInvestment.budget + calculateAllInvestment.allInvestment;
                ResetInvestment();
                UpdateText();
                budgetCheck = "None";
            }
            else if (isSwap == true)
            {
                isSwap = false;
            }
        }
    }

    public void SavingsAction()
    {
        if (bankedMoneyToggle.isOn == true && budgetToggle.isOn == false)
        {
            OpenInputField();
            startupInvestment.bankedMoney = startupInvestment.bankedMoney - calculateAllInvestment.allInvestment;
            UpdateText();
            budgetCheck = "BankedMoney";
        }
        else if (bankedMoneyToggle.isOn == true && budgetToggle.isOn == true)
        {
            OpenInputField();
            startupInvestment.bankedMoney = startupInvestment.bankedMoney - calculateAllInvestment.allInvestment;
            startupInvestment.budget = startupInvestment.budget + calculateAllInvestment.allInvestment;
            UpdateText();
            budgetCheck = "BankedMoney";
            isSwap = true;
            budgetToggle.GetComponent<Toggle>().isOn = false;
        }
        else if (bankedMoneyToggle.isOn == false)
        {
            if (isSwap == false)
            {
                CloseInputField();
                startupInvestment.bankedMoney = startupInvestment.bankedMoney + calculateAllInvestment.allInvestment;
                ResetInvestment();
                UpdateText();
                budgetCheck = "None";
            }
            else if (isSwap == true)
            {
                isSwap = false;
            }
        }
    }

    public void UpdateText()
    {
        remainingBudgetDisplayer.text = startupInvestment.budget.ToString("N0") + " บาท";
        remainingBankedMoneyDisplayer.text = startupInvestment.bankedMoney.ToString("N0") + " บาท";

    }

    public void OpenInputField()
    {
        depositInput.GetComponent<InputField>().interactable = true;
        bondInput.GetComponent<InputField>().interactable = true;
        stockInput.GetComponent<InputField>().interactable = true;
    }

    public void CloseInputField()
    {
        depositInput.GetComponent<InputField>().interactable = false;
        bondInput.GetComponent<InputField>().interactable = false;
        stockInput.GetComponent<InputField>().interactable = false;
    }

    public void ResetInvestment()
    {
        calculateAllInvestment.allInvestment = 0;
        calculateAllInvestment.deposit = 0;
        calculateAllInvestment.bond = 0;
        calculateAllInvestment.stock = 0;
        calculateAllInvestment.beforeBond = 0;
        calculateAllInvestment.beforeDeposit = 0;
        calculateAllInvestment.beforeStock = 0;
        calculateAllInvestment.difference = 0;
        calculateAllInvestment.plusOrMinus = "";
        depositInput.text = "";
        bondInput.text = "";
        stockInput.text = "";
    }
}
