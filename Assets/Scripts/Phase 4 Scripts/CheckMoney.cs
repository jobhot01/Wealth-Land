using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckMoney : MonoBehaviour
{
    public string budgetCheck = "None";
    public Text remainingBankedMoneyDisplayer, remainingBudgetDisplayer;
    public Toggle budgetToggle, bankedMoneyToggle;
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
            startupInvestment.budget = startupInvestment.budget - calculateAllInvestment.allInvestment;
            UpdateText();
            budgetCheck = "Budget";
        }
        else if (budgetToggle.isOn == true && bankedMoneyToggle.isOn == true)
        {
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
                startupInvestment.budget = startupInvestment.budget + calculateAllInvestment.allInvestment;
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
            startupInvestment.bankedMoney = startupInvestment.bankedMoney - calculateAllInvestment.allInvestment;
            UpdateText();
            budgetCheck = "BankedMoney";
        }
        else if (bankedMoneyToggle.isOn == true && budgetToggle.isOn == true)
        {
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
                startupInvestment.bankedMoney = startupInvestment.bankedMoney + calculateAllInvestment.allInvestment;
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
}
