using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickItemCard : MonoBehaviour
{
    int cardSelectIndex;
    [SerializeField] public bool isClick = false;
    public GameObject stamp;
    public AudioSource stampSound;
    [SerializeField] private CalculateSellCards calculateSellCards;
    [SerializeField] private CheckSourceMoney checkSourceMoney;

    void checkPlaceIndex()
    {
        switch (gameObject.name)
        {
            case "Card Place 1":
                cardSelectIndex = 0;
                break;
            case "Card Place 2":
                cardSelectIndex = 1;
                break;
            case "Card Place 3":
                cardSelectIndex = 2;
                break;
            case "Card Place 4":
                cardSelectIndex = 3;
                break;
            case "Card Place 5":
                cardSelectIndex = 4;
                break;
        }
    }

    private void OnMouseDown()
    {
            if (isClick == false && checkSourceMoney.isToggleOn == true)
            {
            //GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.6f);
                print(gameObject.name + " Is Click");
                stamp.SetActive(true);
                stampSound.Play();
                checkPlaceIndex();
                calculateSellCards.doBuyItem(cardSelectIndex);
                isClick = true;
            }
            else if (isClick == true && checkSourceMoney.isToggleOn == true)
            {

            //GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
                print(gameObject.name + " Isn't Click");
                stamp.SetActive(false);
                checkPlaceIndex();
                calculateSellCards.undoBuyItem(cardSelectIndex);
                isClick = false;
            }
    }
}
