using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    public Text extraIncomeText, sumIncomeText, happinessText, energyText, NameDisplay;
    public Button nextButton;
    public int maxEnergy = 7;
    public GameObject TutorialBox;
    [SerializeField] private CalculateValue calculateValue;

    void Start()
    {
        if ( GameController.gameturn <= 1 )
        {
            TutorialBox.gameObject.SetActive(true);
        }
        else
        {
            TutorialBox.gameObject.SetActive(false);
        }

        if (LoadScene.playerName == null)
        {
            LoadScene.playerName = "No name detected";
        }
        NameDisplay.text = LoadScene.playerName.ToString();
    }

    
    void Update()
    {
        if (calculateValue.changeValue == true)
        {
            extraIncomeText.text = "รายได้เสริม            " + calculateValue.allExtraIncome.ToString("N0") + "    บาท";
            sumIncomeText.text = "รวม                      " + calculateValue.sumIncome.ToString("N0") + "    บาท";
            happinessText.text = "ค่าความสุข            " + calculateValue.happiness + "    หน่วย";
            energyText.text = "ค่าพลังงาน " + calculateValue.usedEnergy + "/" + maxEnergy;
            if(calculateValue.usedEnergy <= maxEnergy)
            {
                nextButton.GetComponent<Image>().color = new Color(255, 255, 255, 1);
                nextButton.GetComponent<Button>().interactable = true;
            }
            else
            {
                nextButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
                nextButton.GetComponent<Button>().interactable = false;
            }
            calculateValue.changeValue = false;
        }
    }
}
