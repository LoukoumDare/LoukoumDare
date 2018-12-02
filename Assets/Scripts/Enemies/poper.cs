using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poper : MonoBehaviour
{

	public Transform cat;
	public Transform ennemy;
	public Transform sharpy;
	public Transform blockerEnemy;
	public Transform archeryEnemy;

	public float popDelay = 15;
	private float timeSinceLastPop = 0;

	public bool needSpawnCat = false;
	public int probaEnemy = 5;
	public int probaSharpy = 5;
	public int probaBlocker = 5;
	public int probaArchery = 5;

	public int archeryInstanceNumber = 0;
	public int ennemyInstanceNumber = 0;
	public int sharpyInstanceNumber = 0;
	public int blockerInstanceNumber = 0;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		this.timeSinceLastPop += Time.deltaTime;
		if (this.timeSinceLastPop > popDelay)
		{
			this.timeSinceLastPop = 0;
			Transform go;

			var r = Random.Range(0, probaEnemy + probaSharpy + probaBlocker + probaArchery);

			if (needSpawnCat)
			{
				go = cat;
			}
			else
			{
				if (r < probaEnemy)
				{
					go = sharpy;
				}
				else if (r < probaEnemy + probaSharpy)
				{
					go = ennemy;

				}
				else if (r < probaEnemy + probaSharpy)
				{
					go = blockerEnemy;
				}
				else
				{
					go = archeryEnemy;
				}
			}



			Instantiate(sharpy,transform.position, Quaternion.identity);

			//Instantiate(ennemy, new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0), Quaternion.identity);
			//Instantiate(blockerEnemy, new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0), Quaternion.identity);
			//Instantiate(archeryEnemy, new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0), Quaternion.identity);
		}
	}
}
