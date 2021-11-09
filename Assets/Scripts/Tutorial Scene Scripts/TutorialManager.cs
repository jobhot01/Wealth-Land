using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Sprite[] TutorialSprite;
    public Image TutorialDisplay;
    public Button NextButton;
    public LoadScene loadScene;
    public GameObject TutorialManagerObject;
    int currentSprite;
    int lastSprite;

    void Start()
    {
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
            TutorialManagerObject.SetActive(false);
            loadScene.GoGameplay();
        }
    }
}
