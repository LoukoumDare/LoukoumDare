using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poper : MonoBehaviour {

	public Transform ennemy;

	public float popDelay = 5;
	private float timeSinceLastPop = 0;
	// Use this for initialization
	void Start () {
			
	}

	// Update is called once per frame
	void Update () {
		this.timeSinceLastPop += Time.deltaTime;
		if (this.timeSinceLastPop > popDelay) {
			this.timeSinceLastPop = 0;
			Instantiate(ennemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0), Quaternion.identity);
		}
	}
}
