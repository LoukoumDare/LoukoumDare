using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
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
    public int rows = 25;     //nombre de lignes générées
    public Count blockCount = new Count(5, 9);    //fourchette de block générés
    //public Count itemCount = new Count (2-3)
    public GameObject sacrificePit;  //génère 1 GameObject sacrificepit unique
    public GameObject[] floorTiles;
    public GameObject[] blockTiles;
    //public GameObject[] itemTiles;
    //public GameObject[] enemyTitles;
    public GameObject[] outerwallTiles;


    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    void InitialiseList()  //créer une liste de positions carrées
    {
        gridPositions.Clear();

        for (int x = 1; x < columns - 1; x++)
        {
            for (int y = 1; y < rows - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void BoardSetup()   //setup les murs extérieurs et le floor
    {
        boardHolder = new GameObject("Board").transform;

        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                if (x == -1 || x == columns || y == -1 || y == rows)
                    toInstantiate = outerwallTiles[Random.Range(0, outerwallTiles.Length)];
                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);

            }
        }
    }

    Vector3 RandomPosition()   //position aléatoires pour spawn des items,  blocks, etc
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void SetupScene(int level)   //initialisation du lvl
    {
        BoardSetup();
        InitialiseList();
        LayoutObjectAtRandom(blockTiles, blockCount.minimum, blockCount.maximum);
        //LayoutObjectAtRandom(itemTiles, itemCount.minimum, itemCount.maximum);
        //int enemyCount 
        //LayoutObjectAtRandom(enemyTiles, enemyCount.minimum, enemyCount.maximum);
        Instantiate(sacrificePit, new Vector3(columns = 13, rows = 13, 0f), Quaternion.identity);
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
