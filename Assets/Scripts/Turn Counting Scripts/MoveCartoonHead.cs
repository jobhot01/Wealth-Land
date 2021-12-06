using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCartoonHead : MonoBehaviour
{
    [SerializeField] Sprite femaleCartoonHead;
    [SerializeField] Sprite maleCartoonHead;
    [SerializeField] Image cartoonHeadDisplay;
    [SerializeField] string gender;

    void Start()
    {
        gender = PlayerPrefs.GetString("Gender");
        GetGender();
        CartoonHeadPosition();
    }

    void Update()
    {
        
    }

    void GetGender()
    {
        if (gender == null)
        {
            cartoonHeadDisplay.sprite = maleCartoonHead;
            Debug.LogWarning("No gender found");
        }
        else if (gender == "Male")
        {
            cartoonHeadDisplay.sprite = maleCartoonHead;
        }
        else if (gender == "Female")
        {
            cartoonHeadDisplay.sprite = femaleCartoonHead;
        }
    }

    void CartoonHeadPosition()
    {
        switch (GameController.gameturn)
        {
            case 1:
                cartoonHeadDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector2(-230, 0);
                break;

            case 2:
                cartoonHeadDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector2(-170, 0);
                break;

            case 3:
                cartoonHeadDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector2(-130, 0);
                break;

            case 4:
                cartoonHeadDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector2(-75, 0);
                break;

            case 5:
                cartoonHeadDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector2(-20, 0);
                break;

            case 6:
                cartoonHeadDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector2(10, 0);
                break;

            case 7:
                cartoonHeadDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector2(40, 0);
                break;

            case 8:
                cartoonHeadDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector2(75, 0);
                break;

            case 9:
                cartoonHeadDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector2(130, 0);
                break;

            case 10:
                cartoonHeadDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector2(155, 0);
                break;

            case 11:
                cartoonHeadDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector2(190, 0);
                break;

            case 12:
                cartoonHeadDisplay.GetComponent<RectTransform>().anchoredPosition = new Vector2(230, 0);
                break;
        }
    }
}
