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
    int percent;
    [SerializeField] OnStartPhase onStartPhase;

    public void TestCalculate ()
    {
        int.TryParse(percentInput.text, out percent);
        if (percent > 0)
        {
            useSavings = true;
        }
        else if (percent <= 0)
        {
            useSavings = false;
        }
        accountValue = onStartPhase.myIncome * percent / 100;
        remainingValue = onStartPhase.myIncome - accountValue;
        accountText.text = accountValue.ToString("N0") + "      บาท";
        remainingText.text = remainingValue.ToString("N0") + "      บาท";
    }
}
