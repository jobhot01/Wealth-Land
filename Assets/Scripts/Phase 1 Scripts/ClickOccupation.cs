using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ClickOccupation : MonoBehaviour
{
    int occupationIndex;
    bool isClick = false;
    public GameObject stamp;
    public AudioSource stampSound;
    [SerializeField] private CalculateValue calculateValue;

    void Start()
    {
        //stampSound = GameObject.Find("Stamp Sound");
    }

    public void CheckOccupationIndex()
    {
        switch (gameObject.name)
        {
            case "Plant Trees Card":
                occupationIndex = 0;
                break;
            case "Cook Card":
                occupationIndex = 1;
                break;
            case "Drive Service Card":
                occupationIndex = 2;
                break;
            case "Online Sales Card":
                occupationIndex = 3;
                break;
            case "Contract Design Card":
                occupationIndex = 4;
                break;
            case "Part-Time Employees Card":
                occupationIndex = 5;
                break;
            case "Make DIY Gifts Card":
                occupationIndex = 6;
                break;
            case "Write a Novel/Cartoon Online Card":
                occupationIndex = 7;
                break;
            case "Tutor Card":
                occupationIndex = 8;
                break;
            case "Content Creator Card":
                occupationIndex = 9;
                break;
        }
    }

    private void OnMouseDown()
    {
        if(isClick == false)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.6f);
            stamp.SetActive(true);
            stampSound.Play();
            CheckOccupationIndex();
            calculateValue.SumValue(occupationIndex);
            isClick = true;
        }
        else if (isClick == true)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            stamp.SetActive(false);
            CheckOccupationIndex();
            calculateValue.MinusValue(occupationIndex);
            isClick = false;
        }
    }
}
