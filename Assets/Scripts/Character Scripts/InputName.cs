using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour
{
    public InputField nameInput;
    public string playerName;
    [SerializeField] private CheckAllCharacterScripts checkAllCharacterScripts;

    public void UpdateName()
    {
        playerName = nameInput.text;
        print("Name: " + playerName);
        checkAllCharacterScripts.UpdateButton();
    }
}
