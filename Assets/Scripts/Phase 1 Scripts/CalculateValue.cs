using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateValue : MonoBehaviour
{
    public Text incomeText, savingsText,sumIncomeText;
    //public Text[] itemMoneyText;
    public GameObject[] itemMoneyText;
    //public Text[] itemHappyText;
    public GameObject[] itemHappyText;
    public bool changeValue = false;
    public int myIncome, mySavings, allExtraIncome,sumIncome,happiness,usedEnergy;
    int liveEquipment, plantingKit, car, book, craftSet, gadget;
    int liveEquipmentValue, plantingKitValue, carValue, bookValue, craftSetValue, gadgetValue;
    int uncutHappiness;
    int[] extraIncomeArray = new int[10] {9765,5652,9575,5394,3574,10806,7812,1779,11292,3788};
    int[] happinessArray = new int[10] {40,27,35,27,14,36,32,8,54,20};
    int[] energyArray = new int[10] {5,3,5,3,2,6,4,1,6,2};
    public GameObject[] LikedTab;
    public List<string> selectCard;
    string clickOccupation;

    //Card Index 0:เพาะต้นไม้ขาย
    //Card Index 1:ทำอาหารขาย
    //Card Index 2:ขับรถบริการตามแอพพลิเคชั่น
    //Card Index 3:ตัวแขนขายสินค้าออนไลน์
    //Card Index 4:รับจ้างออกแบบ
    //Card Index 5:พนักงาน Part - Time
    //Card Index 6:ทำของขวัญ DIY
    //Card Index 7:แต่งนิยาย/การ์ตูนออนไลน์
    //Card Index 8:สอนพิเศษ
    //Card Index 9:content creator

    void Start()
    {
        myIncome = PlayerPrefs.GetInt("FirstIncome");
        mySavings = PlayerPrefs.GetInt("allSavings");
        incomeText.text = "รายได้ประจำ          "+ myIncome.ToString("N0") + "    บาท";
        savingsText.text = "เงินเก็บ                  "+ mySavings.ToString("N0") + "    บาท";
        sumIncome = myIncome;
        sumIncomeText.text = "รวม                      " + sumIncome.ToString("N0") + "    บาท";
        addHobbyValue();
        addItemValue();
    }

    public void SumValue(int cardIndex)
    {
        //print("Card Index is " + cardIndex);
        SelectCardList(cardIndex,"Add");
        allExtraIncome = allExtraIncome + extraIncomeArray[cardIndex];
        sumIncome = myIncome + allExtraIncome;
        uncutHappiness = uncutHappiness + happinessArray[cardIndex];
        if (uncutHappiness < 101)
        {
            happiness = uncutHappiness;
        }
        else
        {
            happiness = 100;
        }
        //happiness = happiness + happinessArray[cardIndex];
        usedEnergy = usedEnergy + energyArray[cardIndex];
        changeValue = true;
    }

    public void MinusValue(int cardIndex)
    {
        //print("Card Index " + cardIndex + " is out.");
        SelectCardList(cardIndex, "Remove");
        allExtraIncome = allExtraIncome - extraIncomeArray[cardIndex];
        sumIncome = myIncome + allExtraIncome;
        uncutHappiness = uncutHappiness - happinessArray[cardIndex];
        if (uncutHappiness < 101)
        {
            happiness = uncutHappiness;
        }
        else
        {
            happiness = 100;
        }
        //happiness = happiness - happinessArray[cardIndex];
        usedEnergy = usedEnergy - energyArray[cardIndex];
        changeValue = true;
    }

    public void addHobbyValue()
    {
        switch (LoadScene.playerHobby)
        {
            case "Plant": 
                extraIncomeArray[0] = extraIncomeArray[0] + (extraIncomeArray[0] * LoadScene.randomHobbyValue / 100);
                happinessArray[0] = happinessArray[0] + (happinessArray[0] * LoadScene.randomHobbyValue / 100);
                LikedTab[0].SetActive(true);
                break;
            case "Art":
                extraIncomeArray[4] = extraIncomeArray[4] + (extraIncomeArray[4] * LoadScene.randomHobbyValue / 100);
                happinessArray[4] = happinessArray[4] + (happinessArray[4] * LoadScene.randomHobbyValue / 100);
                LikedTab[4].SetActive(true);
                extraIncomeArray[6] = extraIncomeArray[6] + (extraIncomeArray[6] * LoadScene.randomHobbyValue / 100);
                happinessArray[6] = happinessArray[6] + (happinessArray[6] * LoadScene.randomHobbyValue / 100);
                LikedTab[6].SetActive(true);
                extraIncomeArray[7] = extraIncomeArray[7] + (extraIncomeArray[7] * LoadScene.randomHobbyValue / 100);
                happinessArray[7] = happinessArray[7] + (happinessArray[7] * LoadScene.randomHobbyValue / 100);
                LikedTab[7].SetActive(true);
                break;
            case "Food":
                extraIncomeArray[1] = extraIncomeArray[1] + (extraIncomeArray[1] * LoadScene.randomHobbyValue / 100);
                happinessArray[1] = happinessArray[1] + (happinessArray[1] * LoadScene.randomHobbyValue / 100);
                LikedTab[1].SetActive(true);
                break;
            case "Reading":
                extraIncomeArray[7] = extraIncomeArray[7] + (extraIncomeArray[7] * LoadScene.randomHobbyValue / 100);
                happinessArray[7] = happinessArray[7] + (happinessArray[7] * LoadScene.randomHobbyValue / 100);
                LikedTab[7].SetActive(true);
                extraIncomeArray[8] = extraIncomeArray[8] + (extraIncomeArray[8] * LoadScene.randomHobbyValue / 100);
                happinessArray[8] = happinessArray[8] + (happinessArray[8] * LoadScene.randomHobbyValue / 100);
                LikedTab[8].SetActive(true);
                break;
            case "Computer":
                extraIncomeArray[9] = extraIncomeArray[9] + (extraIncomeArray[9] * LoadScene.randomHobbyValue / 100);
                happinessArray[9] = happinessArray[9] + (happinessArray[9] * LoadScene.randomHobbyValue / 100);
                LikedTab[9].SetActive(true);
                break;
            case "Making":
                extraIncomeArray[6] = extraIncomeArray[6] + (extraIncomeArray[6] * LoadScene.randomHobbyValue / 100);
                happinessArray[6] = happinessArray[6] + (happinessArray[6] * LoadScene.randomHobbyValue / 100);
                LikedTab[6].SetActive(true);
                break;
            case "Workout":
                extraIncomeArray[5] = extraIncomeArray[5] + (extraIncomeArray[5] * LoadScene.randomHobbyValue / 100);
                happinessArray[5] = happinessArray[5] + (happinessArray[5] * LoadScene.randomHobbyValue / 100);
                LikedTab[5].SetActive(true);
                break;
            case "Travel":
                extraIncomeArray[9] = extraIncomeArray[9] + (extraIncomeArray[9] * LoadScene.randomHobbyValue / 100);
                happinessArray[9] = happinessArray[9] + (happinessArray[9] * LoadScene.randomHobbyValue / 100);
                LikedTab[9].SetActive(true);
                extraIncomeArray[2] = extraIncomeArray[2] + (extraIncomeArray[2] * LoadScene.randomHobbyValue / 100);
                happinessArray[2] = happinessArray[2] + (happinessArray[2] * LoadScene.randomHobbyValue / 100);
                LikedTab[2].SetActive(true);
                break;
        }
        for (int i = 0; i < happinessArray.Length; i++)
        {
            //itemHappyText[i].text = happinessArray[i].ToString("N0");
            itemHappyText[i].GetComponent<TextMesh>().text = happinessArray[i].ToString("N0");
        }
    }

    public void addItemValue()
    {
        //for (int i = 0; i < extraIncomeArray.Length; i++)
        //{
        //    //itemMoneyText[i].text = extraIncomeArray[i].ToString("N0");
        //    //print("Item Money " + i + " : " + itemMoneyText[i].text);
        //    print("Item Money " + i + " : " + extraIncomeArray[i]);
        //}
        int[] boughtItemArray;
        boughtItemArray = PlayerPrefsX.GetIntArray("allBoughtItem");
        for (int i = 0; i < boughtItemArray.Length; i++)
        {
            print(boughtItemArray[i]);
        }
        for (int i = 0; i < boughtItemArray.Length; i++)
        {
            if (boughtItemArray[i] >= 0 && boughtItemArray[i] < 3)
            {
                if (boughtItemArray[i] == 2)
                {
                    liveEquipment = 3;
                }
                else if (boughtItemArray[i] == 1 && liveEquipment != 3)
                {
                    liveEquipment = 2;
                }
                else if (boughtItemArray[i] == 0 && liveEquipment < 2)
                {
                    liveEquipment = 1;
                }
            }
            else if (boughtItemArray[i] >= 9 && boughtItemArray[i] < 12)
            {
                if (boughtItemArray[i] == 11)
                {
                    plantingKit = 3;
                }
                else if (boughtItemArray[i] == 10 && plantingKit != 3)
                {
                    plantingKit = 2;
                }
                else if (boughtItemArray[i] == 9 && plantingKit < 2)
                {
                    plantingKit = 1;
                }
            }
            else if (boughtItemArray[i] >= 18 && boughtItemArray[i] < 21)
            {
                if (boughtItemArray[i] == 20)
                {
                    car = 3;
                }
                else if (boughtItemArray[i] == 19 && car != 3)
                {
                    car = 2;
                }
                else if (boughtItemArray[i] == 18 && car < 2)
                {
                    car = 1;
                }
            }
            else if (boughtItemArray[i] >= 21 && boughtItemArray[i] < 24)
            {
                if (boughtItemArray[i] == 23)
                {
                    book = 3;
                }
                else if (boughtItemArray[i] == 22 && book != 3)
                {
                    book = 2;
                }
                else if (boughtItemArray[i] == 21 && book < 2)
                {
                    book = 1;
                }
            }
            else if (boughtItemArray[i] >= 24 && boughtItemArray[i] < 27)
            {
                if (boughtItemArray[i] == 26)
                {
                    craftSet = 3;
                }
                else if (boughtItemArray[i] == 25 && craftSet != 3)
                {
                    craftSet = 2;
                }
                else if (boughtItemArray[i] == 24 && craftSet < 2)
                {
                    craftSet = 1;
                }
            }
            else if (boughtItemArray[i] >= 30 && boughtItemArray[i] < 33)
            {
                if (boughtItemArray[i] == 32)
                {
                    gadget = 3;
                }
                else if (boughtItemArray[i] == 31 && gadget != 3)
                {
                    gadget = 2;
                }
                else if (boughtItemArray[i] == 30 && gadget < 2)
                {
                    gadget = 1;
                }
            }
        }
        switch (liveEquipment)
        {
            case 3:
                liveEquipmentValue = 30;
                break;
            case 2:
                liveEquipmentValue = 27;
                break;
            case 1:
                liveEquipmentValue = 20;
                break;
        }
        switch (plantingKit)
        {
            case 3:
                plantingKitValue = 30;
                break;
            case 2:
                plantingKitValue = 27;
                break;
            case 1:
                plantingKitValue = 20;
                break;
        }
        switch (car)
        {
            case 3:
                carValue = 50;
                break;
            case 2:
                carValue = 40;
                break;
            case 1:
                carValue = 35;
                break;
        }
        switch (book)
        {
            case 3:
                bookValue = 18;
                break;
            case 2:
                bookValue = 12;
                break;
            case 1:
                bookValue = 10;
                break;
        }
        switch (craftSet)
        {
            case 3:
                craftSetValue = 15;
                break;
            case 2:
                craftSetValue = 10;
                break;
            case 1:
                craftSetValue = 7;
                break;
        }
        switch (gadget)
        {
            case 3:
                gadgetValue = 18;
                break;
            case 2:
                gadgetValue = 12;
                break;
            case 1:
                gadgetValue = 10;
                break;
        }
        extraIncomeArray[0] = extraIncomeArray[0] + (extraIncomeArray[0] * plantingKitValue / 100);
        extraIncomeArray[1] = extraIncomeArray[1] + (extraIncomeArray[1] * plantingKitValue / 100);
        extraIncomeArray[2] = extraIncomeArray[2] + (extraIncomeArray[2] * carValue / 100);
        extraIncomeArray[2] = extraIncomeArray[2] + (extraIncomeArray[2] * gadgetValue / 100);
        extraIncomeArray[3] = extraIncomeArray[3] + (extraIncomeArray[3] * liveEquipmentValue / 100);
        extraIncomeArray[4] = extraIncomeArray[4] + (extraIncomeArray[4] * bookValue / 100);
        extraIncomeArray[5] = extraIncomeArray[5] + (extraIncomeArray[5] * carValue / 100);
        extraIncomeArray[6] = extraIncomeArray[6] + (extraIncomeArray[6] * craftSetValue / 100);
        extraIncomeArray[7] = extraIncomeArray[7] + (extraIncomeArray[7] * bookValue / 100);
        extraIncomeArray[7] = extraIncomeArray[7] + (extraIncomeArray[7] * gadgetValue / 100);
        extraIncomeArray[8] = extraIncomeArray[8] + (extraIncomeArray[8] * liveEquipmentValue / 100);
        extraIncomeArray[8] = extraIncomeArray[8] + (extraIncomeArray[8] * bookValue / 100);
        extraIncomeArray[9] = extraIncomeArray[9] + (extraIncomeArray[9] * liveEquipmentValue / 100);
        extraIncomeArray[9] = extraIncomeArray[9] + (extraIncomeArray[9] * gadgetValue / 100);

        for (int i = 0; i < extraIncomeArray.Length; i++)
        {
            //itemMoneyText[i].text = extraIncomeArray[i].ToString("N0");
            itemMoneyText[i].GetComponent<TextMesh>().text = extraIncomeArray[i].ToString("N0");
            //print("Item Money "+ i + " : " +itemMoneyText[i].text);
        }

    }

    public void SelectCardList(int occupationIndex, string addOrRemove)
    {
        switch (occupationIndex)
        {
            case 0:
                clickOccupation = "Plant Trees";
                break;
            case 1:
                clickOccupation = "Cook";
                break;
            case 2:
                clickOccupation = "Drive Service";
                break;
            case 3:
                clickOccupation = "Online Sales";
                break;
            case 4:
                clickOccupation = "Contract Design";
                break;
            case 5:
                clickOccupation = "Part-Time Employees";
                break;
            case 6:
                clickOccupation = "Make DIY Gifts";
                break;
            case 7:
                clickOccupation = "Write a Novel/Cartoon Online";
                break;
            case 8:
                clickOccupation = "Tutor";
                break;
            case 9:
                clickOccupation = "Content Creator";
                break;
        }
        if (addOrRemove == "Add")
        {
            print("Add Card");
            selectCard.Add(clickOccupation);
        }
        else if (addOrRemove == "Remove")
        {
            for(int i = 0; i < selectCard.Count; i++)
            {
                if (selectCard[i] == clickOccupation)
                {
                    print("Remove Card");
                    selectCard.RemoveAt(i);
                }
            }
        }
    }
}
