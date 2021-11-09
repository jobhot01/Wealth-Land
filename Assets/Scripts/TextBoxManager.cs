using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    public GameObject TextImporter;
    public Text SpeechText;
    public Button NextButton;
    public Button BackButton;
    public TextAsset TextFile;
    public string[] TextLines;
    public int CurrentLine;
    public int EndAtLine;
    
    void Start()
    {
        if (TextFile != null)
        {
            TextLines = (TextFile.text.Split('\n'));
        }

        if (EndAtLine == 0)
        {
            EndAtLine = TextLines.Length - 1;
        }

        NextButton.onClick.AddListener(GetInputOnClickHandler);
        BackButton.onClick.AddListener(GetInputOnClickHandler2);
        //StartCoroutine("SetSize");
    }

    void Update() 
    {
        SpeechText.text = TextLines[CurrentLine];

        // if (Input.GetKeyDown(KeyCode.Return))
        // {
        //     CurrentLine += 1;
        // }

        // if (CurrentLine > EndAtLine)
        // {
        //     TextImporter.SetActive(false);
        // }
    }

    public void GetInputOnClickHandler()
    {
        CurrentLine += 1;

        if (CurrentLine > EndAtLine)
        {
            CurrentLine = EndAtLine;
            //TextImporter.SetActive(false);
            //NextButton.interactable = false;
        }
    }

    public void GetInputOnClickHandler2()
    {
        CurrentLine -= 1;
        if (CurrentLine < 0)
        {
            CurrentLine = 0;
        }
    }

    // IEnumerator SetSize()
    // {
    //     yield return new WaitForEndOfFrame();
    //     int sizeAux  = SpeechText.cachedTextGenerator.fontSizeUsedForBestFit;
    //     SpeechText.fontSize = sizeAux;

    //     if (TextFile != null)
    //     {
    //         TextLines = (TextFile.text.Split('\n'));
    //     }

    //     if (EndAtLine == 0)
    //     {
    //         EndAtLine = TextLines.Length - 1;
    //     }
    // }
}
