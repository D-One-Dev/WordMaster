using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonsController : MonoBehaviour
{
    [SerializeField] private TMP_Text wordText, scoreText;
    private List<Button> pressedButtons = new List<Button>();
    private string currentWord;
    private int score  = 0;
    public void ButtonPress(Button thisButton)
    {
        string thisButtonText = thisButton.GetComponentInChildren<TMP_Text>().text;
        Debug.Log(thisButtonText);
        thisButton.interactable = false;
        pressedButtons.Add(thisButton);
        currentWord += thisButtonText;
        wordText.text = currentWord;
    }
    public void Confirm()
    {
        if(this.gameObject.GetComponent<ListGenerator>().wordsList.Find(item => item == currentWord) != null)
        {
            Debug.Log("Found");
            score++;
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.Log("Not found");
        }
        wordText.text = "Waiting For Word";
        foreach(Button thisButton in pressedButtons)
        {
            thisButton.interactable = true;
        }
        currentWord = "";
    }
}
