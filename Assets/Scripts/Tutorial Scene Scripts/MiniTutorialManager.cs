using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniTutorialManager : MonoBehaviour
{
    public Sprite[] TutorialSprite;
    public Image TutorialDisplay;
    public Button NextButton;
    public Button StartButton;
    public GameObject TutorialBox;
    public GameObject TutorialManagerObject;
    public Timer TutorialTimer;
    int currentSprite;
    int lastSprite;
    int gameturn;

    void Start()
    {
        gameturn = PlayerPrefs.GetInt("gameturn");

        if (lastSprite == 0)
        {
            lastSprite = TutorialSprite.Length - 1;
        }

        NextButton.onClick.AddListener(GetInputOnClickHandler);
        StartButton.onClick.AddListener(OpenTutorial);
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
            TutorialTimer.IsPausing(false);
        }
    }

    public void OpenTutorial()
    {
        TutorialBox.SetActive(true);
        currentSprite = 0;
        TutorialManagerObject.SetActive(true);
    }
}
