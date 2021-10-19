using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestrictMinus : MonoBehaviour
{
    public InputField inputField;

    public void CheckMinus(string text)
    {
        text = inputField.GetComponent<InputField>().text;
        if (text.Length > 0 && text[0] == '-') inputField.text = text.Remove(0, 1);
    }
}
