using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateSavings : MonoBehaviour
{
    public InputField percentInput;
    public Text accountText, remainingText;
    public int accountValue, remainingValue;
    public bool useSavings = false;
    public int percent;
    [SerializeField] OnStartPhase onStartPhase;

    public void TestCalculate ()
    {
        int.TryParse(percentInput.text, out percent);
        if (percent > 0)
        {
            useSavings = true;
        }
        else if (percent <= 0 || percentInput.text != "")
        {
            useSavings = false;
            //print("Good");
        }
        accountValue = onStartPhase.myIncome * percent / 100;
        if (percentInput.text != "") 
        {
            remainingValue = onStartPhase.myIncome - accountValue;
        }
        else
        {
            remainingValue = 0;
        }
        accountText.text = accountValue.ToString("N0");
        remainingText.text = remainingValue.ToString("N0");
    }
}
