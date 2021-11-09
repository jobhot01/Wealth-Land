using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniTutorialManager : MonoBehaviour
{
    public Sprite[] TutorialSprite;
    public Image TutorialDisplay;
    public Button NextButton;
    public GameObject TutorialBox;
    public GameObject TutorialManagerObject;
    int currentSprite;
    int lastSprite;

    void Start()
    {
        //TutorialDisplay = GetComponent<Image>();
        
        if (lastSprite == 0)
        {
            lastSprite = TutorialSprite.Length - 1;
        }

        NextButton.onClick.AddListener(GetInputOnClickHandler);
    }

    void Update()
    {
        TutorialDisplay.sprite = TutorialSprite[currentSprite];
    }

    public void GetInputOnClickHandler()
    {
        currentSprite += 1;

        if (currentSprite > lastSprite)
        {
            TutorialBox.SetActive(false);
            TutorialManagerObject.SetActive(false);
        }
    }
}
