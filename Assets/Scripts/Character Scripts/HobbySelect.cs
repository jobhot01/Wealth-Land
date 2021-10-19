using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HobbySelect : MonoBehaviour
{
    public Button plantButton, artButton, foodButton, readButton, computerButton, makingButton, workoutButton,
        travelButton;
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
    }

    public void selectPlant()
    {
        clearButton();
        stampSound.Play();
        plantButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        hobby = "Plant";
        checkAllCharacterScripts.UpdateButton();
    }

    public void selectArt()
    {
        clearButton();
        stampSound.Play();
        artButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        hobby = "Art";
        checkAllCharacterScripts.UpdateButton();
    }

    public void selectFood()
    {
        clearButton();
        stampSound.Play();
        foodButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        hobby = "Food";
        checkAllCharacterScripts.UpdateButton();
    }

    public void selectReading()
    {
        clearButton();
        stampSound.Play();
        readButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        hobby = "Reading";
        checkAllCharacterScripts.UpdateButton();
    }

    public void selectComputer()
    {
        clearButton();
        stampSound.Play();
        computerButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        hobby = "Computer";
        checkAllCharacterScripts.UpdateButton();
    }

    public void selectMaking()
    {
        clearButton();
        stampSound.Play();
        makingButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        hobby = "Making";
        checkAllCharacterScripts.UpdateButton();
    }

    public void selectWorkout()
    {
        clearButton();
        stampSound.Play();
        workoutButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        hobby = "Workout";
        checkAllCharacterScripts.UpdateButton();
    }

    public void selectTravel()
    {
        clearButton();
        stampSound.Play();
        travelButton.GetComponent<Image>().color = new Color(255, 255, 255, 0.6f);
        hobby = "Travel";
        checkAllCharacterScripts.UpdateButton();
    }
}
