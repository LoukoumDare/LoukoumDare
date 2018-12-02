using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour {
	public Transform player;
	private PlayerHealth playerHealth;
	public float damage = 1;
	public float ATTACK_COOLDOWN = 3f;
	public float timeSinceLastAttack = 0f;

	// Use this for initialization
	void Start () {
		playerHealth = GameObject.Find("player").GetComponent<PlayerHealth>();
		// aimedPosition = GameObject.Find("player").transform.position;
	}

	void doAttack () {
		playerHealth.TakeDamage ((int)(this.damage));
	}
	public void checkAttack() {
		this.timeSinceLastAttack += Time.deltaTime;
		if (this.timeSinceLastAttack > ATTACK_COOLDOWN) {
			// do the thing
			doAttack ();
			this.timeSinceLastAttack =  0;	
		}
	}
		
	
	// Update is called once per frame
	void Update () {
		
	}
}
