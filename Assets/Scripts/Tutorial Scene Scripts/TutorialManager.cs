using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Sprite[] MaleTutorialSprite;
    public Sprite[] FemaleTutorialSprite;
    public Image TutorialDisplay;
    public Button NextButton;
    public LoadScene loadScene;
    public GameObject TutorialManagerObject;
    int currentSprite;
    int lastSprite;
    string gender;

    void Start()
    {
        gender = PlayerPrefs.GetString("Gender");
        
        if (lastSprite == 0)
        {
            lastSprite = MaleTutorialSprite.Length - 1;
        }

        NextButton.onClick.AddListener(GetInputOnClickHandler);
    }

    void Update()
    {
        GetGender();
    }

    void GetGender()
    {
        //if (gender == null)
        //{
        //    gender = "Male";
        //    return;
        //}
        
        switch (gender)
        {
            case "Male":
                TutorialDisplay.sprite = MaleTutorialSprite[currentSprite];
                break;

            case "Female":
                TutorialDisplay.sprite = FemaleTutorialSprite[currentSprite];
                break;
        }
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
