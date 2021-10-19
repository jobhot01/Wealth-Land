using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupCard : MonoBehaviour
{ 
    public GameObject[] spawnPoint;
    public List<int> cardIndex = new List<int>();
    public List<Sprite> cardSprite = new List<Sprite>();
    public List<int> boughtCards = new List<int>();
    public List<int> alrealySpawnCards = new List<int>();
    public List<int> choseCards = new List<int>();

    int cardSpawn, activeSpawn;
    bool alreadyUsed = false;
    int[] beforeBoughtCards;
    int[] permanentItem = new int[] { 12, 13, 14, 18, 19, 20, 24, 25, 26, 27, 28, 29 };

    void Start()
    {
        beforeBoughtCards = PlayerPrefsX.GetIntArray("allBoughtItem");
        //https://wiki.unity3d.com/index.php/ArrayPrefs2
        for (int i = 0; i < beforeBoughtCards.Length; i++)
        {
            for (int k = 0; k < permanentItem.Length; k++)
            {
                if (beforeBoughtCards[i] == permanentItem[k])
                {
                    boughtCards.Add(beforeBoughtCards[i]);
                }
            } 
        }
        for (int i = 0; i < boughtCards.Count; i++)
        {
            print("Permanent Item: " + boughtCards[i]);
        }
        cardSpawn = cardIndex.Count - boughtCards.Count;
        if (cardSpawn > 5)
        {
            cardSpawn = 5;
            spawnCards();
        }

        else if (cardSpawn > 0)
        {
            spawnCards();
        }
    }


    public void spawnCards()
    {
        for (int i = 0; i < boughtCards.Count; i++)
        {
            for (int j = 0; j < cardIndex.Count; j++)
            {
                if (boughtCards[i] == cardIndex[j])
                {
                    cardIndex.RemoveAt(j);
                    cardSprite.RemoveAt(j);
                }
            }
        }

        for (int i = 0; i < cardSpawn; i++)
        {
            int randomCard = Random.Range(0, cardIndex.Count);
            for (int k = 0; k < alrealySpawnCards.Count; k++)
            {
                if (randomCard == alrealySpawnCards[k])
                {
                    alreadyUsed = true;
                    break;
                }
            }
            if (alreadyUsed == true)
            {
                alreadyUsed = false;
                cardSpawn = cardSpawn + 1;
            }
            else
            {
                alrealySpawnCards.Add(randomCard);
                choseCards.Add(cardIndex[randomCard]);
                print(randomCard);
                spawnPoint[activeSpawn].SetActive(true);
                spawnPoint[activeSpawn].GetComponent<SpriteRenderer>().sprite = cardSprite[randomCard];
                activeSpawn++;
            }
            
        }
    }
}
