using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class FloorManager : MonoBehaviour
{

    public FloorGenerator boardScript;

    private int level = 1;




    // Use this for initialization
    void Awake()
    {
        boardScript = GetComponent<FloorGenerator>();
        InitGame();
    }

    void InitGame()
    {
        boardScript.SetupScene(level);
    }

    // Update is called once per frame
    void Update()
    {

    }
}