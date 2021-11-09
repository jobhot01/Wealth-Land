using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HobbySelect : MonoBehaviour
{
    public Button plantButton, artButton, foodButton, readButton, computerButton, makingButton, workoutButton,
        travelButton;
    public GameObject[] stamp;
    public string hobby;
    public AudioSource stampSound;
    [SerializeField] private CheckAllCharacterScripts checkAllCharacterScripts;

    void clearButton()
    {
        plantButton.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        artButton.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        foodButton.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        readButton.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        computerButton.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        makingButton.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        workoutButton.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        travelButton.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        for(int i = 0; i < stamp.Length; i++)
        {
            stamp[i].SetActive(false);
        }
    }

    public void selectPlant()
    {
        clearButton();
        stampSound.Play();
        plantButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        stamp[0].SetActive(true);
        hobby = "Plant";
        //checkAllCharacterScripts.UpdateButton();
    }

    public void selectArt()
    {
        clearButton();
        stampSound.Play();
        artButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        stamp[1].SetActive(true);
        hobby = "Art";
        //checkAllCharacterScripts.UpdateButton();
    }

    public void selectFood()
    {
        clearButton();
        stampSound.Play();
        foodButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        stamp[2].SetActive(true);
        hobby = "Food";
        //checkAllCharacterScripts.UpdateButton();
    }

    public void selectReading()
    {
        clearButton();
        stampSound.Play();
        readButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        stamp[3].SetActive(true);
        hobby = "Reading";
        //checkAllCharacterScripts.UpdateButton();
    }

    public void selectComputer()
    {
        clearButton();
        stampSound.Play();
        computerButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        stamp[4].SetActive(true);
        hobby = "Computer";
        //checkAllCharacterScripts.UpdateButton();
    }

    public void selectMaking()
    {
        clearButton();
        stampSound.Play();
        makingButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        stamp[5].SetActive(true);
        hobby = "Making";
        //checkAllCharacterScripts.UpdateButton();
    }

    public void selectWorkout()
    {
        clearButton();
        stampSound.Play();
        workoutButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        stamp[6].SetActive(true);
        hobby = "Workout";
        //checkAllCharacterScripts.UpdateButton();
    }

    public void selectTravel()
    {
        clearButton();
        stampSound.Play();
        travelButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        stamp[7].SetActive(true);
        hobby = "Travel";
        //checkAllCharacterScripts.UpdateButton();
    }
}
