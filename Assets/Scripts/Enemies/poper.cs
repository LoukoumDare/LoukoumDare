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

	public static bool needSpawnCat = false;
	public bool isCatspawner;
	
	public int probaSharpy = 5;
	public int probaBlocker = 5;
	public int probaArchery = 5;
	public static int nbmobsMax = 30;

	public int archeryInstanceNumber = 0;
	public int sharpyInstanceNumber = 0;
	public int blockerInstanceNumber = 0;
	private int enemylevel = 0;
	

	void start ()
	{
		EventManager.StartListening("INCREASE_ENNEMY", () => { enemylevel++; });
	}

	// Update is called once per frame
	void Update()
	{
		this.timeSinceLastPop += Time.deltaTime;
		if (this.timeSinceLastPop > popDelay)
		{
			this.timeSinceLastPop = 0;

			Transform go;
			var r = Random.Range(0, probaSharpy + probaBlocker + probaArchery);

			if (needSpawnCat && isCatspawner)
			{
				go = cat;
			}
			else
			{
				if (r < probaSharpy)
				{
					go = sharpy;
					Transform tr = Instantiate(go, transform.position, Quaternion.identity);
					tr.GetComponent<sharpy>().speed = Mathf.Pow(tr.GetComponent<sharpy>().speed, 1.1f * enemylevel);
					tr.GetComponent<sharpy>().attackRange = Mathf.Pow(tr.GetComponent<sharpy>().damageOnPlayerHit, 1.2f * enemylevel);
					tr.GetComponent<enemyHealth>().startingHealth = (int)Mathf.Pow(tr.GetComponent<enemyHealth>().startingHealth, 1.2f * enemylevel);
				}
				else if (r < probaSharpy + probaBlocker)
				{
					go = blockerEnemy;
					Transform tr = Instantiate(go, transform.position, Quaternion.identity);
					tr.GetComponent<blockerEnemy>().speed = Mathf.Pow(tr.GetComponent<sharpy>().speed, 1.1f * enemylevel);
					tr.GetComponent<blockerEnemy>().attackRange = Mathf.Pow(tr.GetComponent<sharpy>().damageOnPlayerHit, 1.2f * enemylevel);
					tr.GetComponent<enemyHealth>().startingHealth = (int)Mathf.Pow(tr.GetComponent<enemyHealth>().startingHealth, 1.2f * enemylevel);
				}
				else
				{
					go = archeryEnemy;
					Transform tr = Instantiate(go, transform.position, Quaternion.identity);

				}
			}

			nbmobsMax--;



			//Instantiate(ennemy, new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0), Quaternion.identity);
			//Instantiate(blockerEnemy, new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0), Quaternion.identity);
			//Instantiate(archeryEnemy, new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0), Quaternion.identity);
		}
	}
}
