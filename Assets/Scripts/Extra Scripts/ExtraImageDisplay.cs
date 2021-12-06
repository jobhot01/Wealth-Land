using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraImageDisplay : MonoBehaviour
{
    [SerializeField] Sprite[] characterProflies;
    [SerializeField] Image ImageDisplay;
    [SerializeField] Button NextButton;
    [SerializeField] Button PrevButton;
    [SerializeField] int currentSprite;
    [SerializeField] int lastSprite;

    void Start()
    {
        if (lastSprite == 0)
        {
            lastSprite = characterProflies.Length - 1;
        }

        PrevButton.interactable = false;
        NextButton.onClick.AddListener(GoNextPage);
        PrevButton.onClick.AddListener(GoPrevPage);
    }

    
    void Update()
    {
        ImageDisplay.sprite = characterProflies[currentSprite];
    }

    public void GoNextPage()
    {
        currentSprite += 1;
        PrevButton.interactable = true;

        if (currentSprite == lastSprite)
        {
            currentSprite = lastSprite;
            NextButton.interactable = false;
            //PrevButton.interactable = true;
        }
    }

    public void GoPrevPage()
    {
        currentSprite -= 1;
        NextButton.interactable = true;

        if (currentSprite == 0)
        {
            currentSprite = 0;
            //NextButton.interactable = true;
            PrevButton.interactable = false;
        }
    }
}
