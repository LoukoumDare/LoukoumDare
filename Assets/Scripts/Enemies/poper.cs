using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poper : MonoBehaviour {

	public Transform ennemy;
	public Transform sharpy;
	public Transform blockerEnemy;
	public Transform archeryEnemy;

	public float popDelay = 5;
	private float timeSinceLastPop = 0;

	public int archeryInstanceNumber = 0;
	public int ennemyInstanceNumber = 0;
	public int sharpyInstanceNumber = 0;
	public int blockerInstanceNumber = 0;
	// Use this for initialization
	void Start () {
			
	}

	// Update is called once per frame
	void Update () {
		this.timeSinceLastPop += Time.deltaTime;
		if (this.timeSinceLastPop > popDelay) {
			this.timeSinceLastPop = 0;
			// Instantiate(sharpy, new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0), Quaternion.identity);
			// Instantiate(ennemy, new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0), Quaternion.identity);
			Instantiate(blockerEnemy, new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0), Quaternion.identity);
			Instantiate(archeryEnemy, new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0), Quaternion.identity);
		}
	}
}
