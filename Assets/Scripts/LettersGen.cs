using UnityEngine;
using TMPro;

public class LettersGen : MonoBehaviour
{
    [SerializeField] private TMP_Text[] buttonsText;
    private string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    void Start()
    {
        RefreshLetters();
    }
    public void RefreshLetters()
    {
        foreach(TMP_Text buttonText in buttonsText)
        {
            int letterNumber = Random.Range(0, alphabet.Length);
            buttonText.text = alphabet[letterNumber].ToString();
        }
    }
}
