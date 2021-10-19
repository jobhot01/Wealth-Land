using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour
{
    public InputField nameInput;
    public string name;
    [SerializeField] private CheckAllCharacterScripts checkAllCharacterScripts;

    public void UpdateName()
    {
        name = nameInput.text;
        //print("Name: " + name);
        checkAllCharacterScripts.UpdateButton();
    }
}
