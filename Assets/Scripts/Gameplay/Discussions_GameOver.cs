using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Discussions_GameOver : MonoBehaviour
{

    public Discussions gameOverScript;
    public string GameOver1 = "Oh! so close from her, that's kinda unlucky!";
    public string GameOver2 = "Coming from so far away only to fail so miserabily...";
    public string GameOver3 = "Oh my dear friend, maybe you should be willing to sacrifice a little more!";
    public string GameOver4 = "Please don't tell me you cannot do better for her?";
    public string GameOver5 = "A good chaotic friend of mine once said that without pain, without sacrifice, we would have nothing.They made a movie about him I think.";
    //private List choices<> = false;


    public void GetAnswer()
    {
        List<string> choices = new List<string>(5);
        choices.Add(GameOver1);
        choices.Add(GameOver2);
        choices.Add(GameOver3);
        choices.Add(GameOver4);
        choices.Add(GameOver5);
    }


    // Use this for initialization
    void Start()
    {


     //   RandomString = choices[Random.Range(0, choices.Count - 1)];

      //  gameOverScript.WriteText(Randomstring text);

    }

}

/*
//Gameover1
Oh! so close from her, that's kinda unlucky!
//Gameover2
Coming from so far away only to fail so miserabily...
//Gameover3
Oh my dear friend, maybe you should be willing to sacrifice a little more!
//Gameover4
Please don't tell me you cannot do better for her?
//Gameover5
A good chaotic friend of mine once said that without pain, without sacrifice, we would have nothing.They made a movie about him I think.
*/