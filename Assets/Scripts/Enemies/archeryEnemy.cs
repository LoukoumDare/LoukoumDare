using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archeryEnemy : MonoBehaviour {
	public Vector3 aimedPosition;
	public float speed = 1f;
	private float x;
	private float y;
	public float timeSinceLastShoot = 0;
	public float timeSinceStartRepositioning = 0;
	public int state = 0;
	private int STANDARD = 0;
	private int SHOTING = 1;
	private int REPOSITIONING = 2;
	public float DELAY_BETWEEN_SHOT = 2f;
	public float MIN_DISTANCE_TO_MINION = 6;
	public float DELAY_FOR_REPOSITIONING = 1f;
	private float distanceToMinion = 1f;
	public float sideStepSpeed = 1f;
	public float damage = 5;
	public float damageOnPlayerHit = 1;
	enemyHealth _enemyHealth;
	PlayerHealth playerHealth;

	void Start () {
		this.distanceToMinion = MIN_DISTANCE_TO_MINION + Random.Range (-1f, 1f);
		// aimedPosition = new Vector3(Random.Range (1, 10), Random.Range (0, 10));
	}
	void shot () {
		if (this.state == SHOTING) {
			timeSinceLastShoot += Time.deltaTime;
			if (timeSinceLastShoot > DELAY_BETWEEN_SHOT) {
                timeSinceLastShoot = 0;
                GameObject arrow = Instantiate(Resources.Load("arrow", typeof(GameObject)), new Vector3(transform.position.x, transform.position.y, -2), transform.rotation * Quaternion.Euler(0, 0, 90)) as GameObject;
                arrow.GetComponent<bulletControler>().damage = this.damage;
                //Destroy(arrow, 5);
                Debug.Log("arrow");
				this.state = REPOSITIONING;
				sideStepSpeed = Random.Range (-1f, 1f);
			}
		}
	}
	void repositioning () {
		if (this.state == REPOSITIONING) {
			timeSinceStartRepositioning += Time.deltaTime;
			if (timeSinceStartRepositioning > DELAY_FOR_REPOSITIONING) {
				timeSinceStartRepositioning = 0;
				this.state = SHOTING;
			}
		}
	}
	void Update () {
		aimedPosition = GameObject.Find("player").transform.position;

		float AngleRad = Mathf.Atan2(aimedPosition.x - transform.position.x, aimedPosition.y - transform.position.y);
		float AngleDeg = (180 / Mathf.PI) * AngleRad * -1;
		this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg); 

		Vector3 diffPosition = aimedPosition - transform.position;
		Vector3 vectorMotion = diffPosition.normalized * speed * Time.deltaTime;

		if (diffPosition.magnitude > speed * Time.deltaTime && diffPosition.magnitude < (this.distanceToMinion -1f) ) {
			// transform.position = aimedPosition;
			// this.speed = 0f;
			// randomRotateItem ();
			this.state = STANDARD;
			transform.Translate (vectorMotion * -1, Space.World);

		} else if ( diffPosition.magnitude < this.distanceToMinion ) {
			if (state == REPOSITIONING) {
				repositioning ();
				Vector3 vectorShift = transform.right * sideStepSpeed * Time.deltaTime;;
				transform.Translate (vectorShift, Space.World);
			} else {
				this.state = SHOTING;
				shot ();
			}

		} else {
			this.state = STANDARD;
			transform.Translate (vectorMotion, Space.World);
		}
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Bullet")
		{
			// Destroy(gameObject);
			Destroy(collision.gameObject);
			_enemyHealth = GetComponent <enemyHealth> ();
			_enemyHealth.TakeDamage ((int)(collision.gameObject.GetComponent<bulletControler> ().damage), new Vector3(0, 0, 0));
			Debug.Log (collision.gameObject.GetComponent<bulletControler> ().damage);
		}
		if (collision.gameObject.tag == "Player")
		{
			// Destroy(gameObject);
			playerHealth = collision.gameObject.GetComponentInParent<PlayerHealth>();
			playerHealth.TakeDamage ((int)(this.damageOnPlayerHit));
		}
	}

}
