using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAllCharacterScripts : MonoBehaviour
{
    [SerializeField] private HobbySelect hobbySelect;
    [SerializeField] private GenderSelect genderSelect;
    [SerializeField] private InputName inputName;
    public Button nextButton;

    void Start()
    {
        nextButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        nextButton.GetComponent<Button>().interactable = false;
    }

    public void UpdateButton()
    {
        if(hobbySelect.hobby != "" && genderSelect.gender != "" && inputName.name != "")
        {
            nextButton.GetComponent<Image>().color = new Color(255, 255, 255, 1);
            nextButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            nextButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
            nextButton.GetComponent<Button>().interactable = false;
        }
    }
}
