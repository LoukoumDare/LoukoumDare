using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Discussions : MonoBehaviour {
    
    private string textShownOnScreen;
    public Text textBox;
    public string fullText = "The text you want shown on screen with typewriter effect.";
    public float wordsPerSecond = 2; // speed of typewriter
    private float timeElapsed = 0;
    public float timeLeftBeforeClean = 3f;
    private bool destroyed = false;
    public Image img;
    

    void Update()
    {
        timeElapsed += Time.deltaTime;
        textShownOnScreen = GetWords(fullText, timeElapsed * wordsPerSecond);
    }

    public void WriteText(string text)
    {
        fullText = text;
        timeElapsed = 0;
        destroyed = false;
        img.enabled = true;
    }

    private string GetWords(string text, float wordCount)
    {
        float words = wordCount;
        // loop through each character in text
        for (int i = 0; i < text.Length; i++)
        {
            words--;
            textBox.text = textShownOnScreen;
            if (words <= 0)
            {
                return text.Substring(0, i);
            }
        }
        if ( timeLeftBeforeClean > 0 )
        {
            timeLeftBeforeClean -= Time.deltaTime;
        }
        else if (!destroyed)
        {
            textBox.text = "";
            fullText = "";
            textShownOnScreen = "";
            img.enabled = false;
            destroyed = true;
        }
        return text;
    }
}