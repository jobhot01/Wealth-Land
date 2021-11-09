using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateAllInvestment : MonoBehaviour
{
    public InputField stockInputField, bondInputField, depositInputField;
    public Text remainingBankedMoneyDisplayer, remainingBudgetDisplayer;
    public Button continueButton;
    public string plusOrMinus;
    public int stock, bond, deposit, allInvestment;
    public int beforeStock, beforeBond, beforeDeposit, difference;
    [SerializeField] private StartupInvestment startupInvestment;
    [SerializeField] private CheckMoney checkMoney;

    public void Calculating()
    {
        //print(CheckMoney.budgetCheck);
        int.TryParse(stockInputField.text, out stock);
        int.TryParse(bondInputField.text, out bond);
        int.TryParse(depositInputField.text, out deposit);
        allInvestment = stock + bond + deposit;
        if (stock != beforeStock)
        {
            if (stock > beforeStock)
            {
                difference = stock - beforeStock;
                plusOrMinus = "Minus";
            }
            else if (beforeStock > stock)
            {
                difference = beforeStock - stock;
                plusOrMinus = "Plus";
            }
            //print("Stock");
            beforeStock = stock;
        }
        else if (bond != beforeBond)
        {
            if (bond > beforeBond)
            {
                difference = bond - beforeBond;
                plusOrMinus = "Minus";
            }
            else if (beforeBond > bond)
            {
                difference = beforeBond - bond;
                plusOrMinus = "Plus";
            }
            //print("bond");
            beforeBond = bond;
        }
        else if (deposit != beforeDeposit)
        {
            if (deposit > beforeDeposit)
            {
                difference = deposit - beforeDeposit;
                plusOrMinus = "Minus";
            }
            else if (beforeDeposit > deposit)
            {
                difference = beforeDeposit - deposit;
                plusOrMinus = "Plus";
            }
            //print("deposit");
            beforeDeposit = deposit;
        }

        if (checkMoney.budgetCheck == "Budget")
        {
            if (plusOrMinus == "Minus")
            {
                startupInvestment.budget = startupInvestment.budget - difference;
                remainingBudgetDisplayer.text = startupInvestment.budget.ToString("N0") + " บาท";
                //print("Budget Minus");
                plusOrMinus = "None";
            }
            else if (plusOrMinus == "Plus")
            {
                startupInvestment.budget = startupInvestment.budget + difference;
                remainingBudgetDisplayer.text = startupInvestment.budget.ToString("N0") + " บาท";
                //print("Budget Plus");
                plusOrMinus = "None";
            }
            
        }

        else if (checkMoney.budgetCheck == "BankedMoney")
        {
            if (plusOrMinus == "Minus")
            {
                startupInvestment.bankedMoney = startupInvestment.bankedMoney - difference;
                remainingBankedMoneyDisplayer.text = startupInvestment.bankedMoney.ToString("N0") + " บาท";
                //print("BankedMoneyt Minus");
                plusOrMinus = "None";
            }
            else if (plusOrMinus == "Plus")
            {
                startupInvestment.bankedMoney = startupInvestment.bankedMoney + difference;
                remainingBankedMoneyDisplayer.text = startupInvestment.bankedMoney.ToString("N0") + " บาท";
                //print("BankedMoney Plus");
                plusOrMinus = "None";
            }

        }

        if (startupInvestment.budget < 0 || startupInvestment.bankedMoney < 0)
        {
            continueButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
            continueButton.GetComponent<Button>().interactable = false;

        }
        else
        {
            continueButton.GetComponent<Image>().color = new Color(255, 255, 255, 1);
            continueButton.GetComponent<Button>().interactable = true;
        }
    }
}
