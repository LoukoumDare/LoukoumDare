using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class FloorGenerator : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public int columns = 25;  //nombre de colonnes générées
    public int rows = 12;     //nombre de lignes générées
    public int floorTileLenght = 3;  //longueur de la tuile Mur
    public int wallTileLenght = 5;  //longueur de la tuile Mur
    public int angleWallTileLenght = 4;  //longueur de la tuile Mur
    //public Count blockCount = new Count(5, 9);    //fourchette de block générés
    //public Count itemCount = new Count (2-3)
    public GameObject sacrificePit;  //génère 1 GameObject sacrificepit unique
    public GameObject[] floorTiles;
    //public GameObject[] blockTiles;
    //public GameObject[] itemTiles;
    //public GameObject[] enemyTitles;
    public GameObject[] wallTiles;
    public GameObject[] angleWallTiles;


    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    void InitialiseList()  //créer une liste de positions carrées
    {
        gridPositions.Clear();

        for (int x = -(columns / 2); x < (columns / 2) - 1; x++)
        {
            for (int y = -(rows / 2); y < (rows / 2) - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void BoardSetup()   //setup le board
    {
        boardHolder = new GameObject("Board").transform;

        //  floor
        for (int x = -(columns / 2); x < (columns / 2) + 1 ; x+= floorTileLenght)      
        {
            for (int y = -(rows / 2); y < (rows / 2) + 1 ; y+= floorTileLenght)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }

        // murs du bas
        for (int x = -(columns / 2) + angleWallTileLenght; x < (columns / 2) - angleWallTileLenght + 1; x += wallTileLenght)   
        {           
            GameObject toInstantiate = wallTiles[0];
            GameObject instance = Instantiate(toInstantiate, new Vector3(x + 1, -(rows / 2), 0f), Quaternion.identity) as GameObject;
            instance.transform.SetParent(boardHolder);            
        }

        // murs du haut
        for (int x = -(columns / 2) + angleWallTileLenght; x < (columns / 2) - angleWallTileLenght + 1; x += wallTileLenght)   
        {
            GameObject toInstantiate = wallTiles[0];
            GameObject instance = Instantiate(toInstantiate, new Vector3(x + 1, (rows / 2), 0f), Quaternion.identity) as GameObject;
            instance.transform.Rotate(0, 0, 180);
            instance.transform.SetParent(boardHolder);
        }

        // murs de gauche
        for (int y = -(rows / 2) + angleWallTileLenght; y < (rows / 2) - angleWallTileLenght + 1; y += wallTileLenght)   
        {
            GameObject toInstantiate = wallTiles[0];
            GameObject instance = Instantiate(toInstantiate, new Vector3(-(columns / 2), y + 1, 0f), Quaternion.identity) as GameObject;
            instance.transform.Rotate(0, 0, -90);
            instance.transform.SetParent(boardHolder);
        }

        // murs de droite
        for (int y = -(rows / 2) + angleWallTileLenght; y < (rows / 2) - angleWallTileLenght + 1; y += wallTileLenght)
        {
            GameObject toInstantiate = wallTiles[0];
            GameObject instance = Instantiate(toInstantiate, new Vector3((columns / 2), y + 1, 0f), Quaternion.identity) as GameObject;
            instance.transform.Rotate(0, 0, 90);
            instance.transform.SetParent(boardHolder);
        }

        //Angles des murs  
        //bas gauche
        {
            GameObject toInstantiate = angleWallTiles[0];
            GameObject instance = Instantiate(toInstantiate, new Vector3(-(columns / 2), -(rows / 2), 0f), Quaternion.identity) as GameObject;
            instance.transform.SetParent(boardHolder);
        }
        //bas droite
        {
            GameObject toInstantiate = angleWallTiles[0];
            GameObject instance = Instantiate(toInstantiate, new Vector3((columns / 2), -(rows / 2), 0f), Quaternion.identity) as GameObject;
            instance.transform.Rotate(0, 0, 90);
            instance.transform.SetParent(boardHolder);
        }
        //haut droite
        {
            GameObject toInstantiate = angleWallTiles[0];
            GameObject instance = Instantiate(toInstantiate, new Vector3((columns / 2), (rows / 2), 0f), Quaternion.identity) as GameObject;
            instance.transform.Rotate(0, 0, 180);
            instance.transform.SetParent(boardHolder);
        }
        //haut gauche
        {
            GameObject toInstantiate = angleWallTiles[0];
            GameObject instance = Instantiate(toInstantiate, new Vector3(-(columns / 2), (rows / 2), 0f), Quaternion.identity) as GameObject;
            instance.transform.Rotate(0, 0, -90);
            instance.transform.SetParent(boardHolder);
        }
    }




    public void SetupScene(int level)   //initialisation du lvl
    {
        BoardSetup();
        InitialiseList();
        //LayoutObjectAtRandom(blockTiles, blockCount.minimum, blockCount.maximum);
        //LayoutObjectAtRandom(itemTiles, itemCount.minimum, itemCount.maximum);
        //int enemyCount 
        //LayoutObjectAtRandom(enemyTiles, enemyCount.minimum, enemyCount.maximum);
        Instantiate(sacrificePit, new Vector3(0, 0.5f, 0f), Quaternion.identity);
    }



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
