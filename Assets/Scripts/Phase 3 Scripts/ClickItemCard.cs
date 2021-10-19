using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickItemCard : MonoBehaviour
{
    int cardSelectIndex;
    bool isClick = false;
    public GameObject stamp;
    public AudioSource stampSound;
    [SerializeField] private CalculateSellCards calculateSellCards;

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
            if (isClick == false)
            {
                //GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.6f);
                stamp.SetActive(true);
                stampSound.Play();
                checkPlaceIndex();
                calculateSellCards.doBuyItem(cardSelectIndex);
                isClick = true;
            }
            else if (isClick == true)
            {

                //GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
                stamp.SetActive(false);
                checkPlaceIndex();
                calculateSellCards.undoBuyItem(cardSelectIndex);
                isClick = false;
            }
    }
}
