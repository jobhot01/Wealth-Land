using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateSellCards : MonoBehaviour
{
    int[] itemMoney = new int[36] {1000,1500,2000,3000,4000,5000,1250,1750,2500,1250,2000,2750,25000,
        47500,80000,4500,7000,8000,75000,120000,175000,750,1500,2450,7500,9000,12500,15000,37500,52500,4500,7500,
        9750,10000,15000,17500};
    public int allItemBuyValue,cardIndex,itemValue;
    public bool updateUI = false;
    [SerializeField] private SetupUI setupUI;
    [SerializeField] private SetupCard setupCard;
    [SerializeField] private CheckSourceMoney checkSourceMoney;

    public void doBuyItem(int placeIndex)
    {
        SearchItemIndex(placeIndex);
        allItemBuyValue = allItemBuyValue + itemValue;
        if(checkSourceMoney.moneySourceCheck == "Income")
        {
            setupUI.income = setupUI.income - itemValue;
        }
        else if(checkSourceMoney.moneySourceCheck == "Savings")
        {
            setupUI.savings = setupUI.savings - itemValue;
        }
        setupCard.boughtCards.Add(cardIndex);
        updateUI = true;
    }

    public void undoBuyItem(int placeIndex)
    {
        SearchItemIndex(placeIndex);
        allItemBuyValue = allItemBuyValue - itemValue;
        if (checkSourceMoney.moneySourceCheck == "Income")
        {
            setupUI.income = setupUI.income + itemValue;
        }
        else if (checkSourceMoney.moneySourceCheck == "Savings")
        {
            setupUI.savings = setupUI.savings + itemValue;
        }
        for (int i = 0; i < setupCard.boughtCards.Count; i++)
        {
            if (cardIndex == setupCard.boughtCards[i])
            {
                setupCard.boughtCards.RemoveAt(i);
            }
        }
        updateUI = true;
    }

    public void SearchItemIndex(int searchIndex)
    {
        for (int i = 0; i < setupCard.choseCards.Count; i++)
        {
            if(i == searchIndex) 
            {
                cardIndex = setupCard.choseCards[i];
            }
        }
        itemValue = itemMoney[cardIndex];
    }
}
