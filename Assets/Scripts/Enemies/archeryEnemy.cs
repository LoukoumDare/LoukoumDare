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
	private bool needShot = false;
	public float sideStepSpeed = 1f;
	public float damage = 5;

	void Start () {
		this.distanceToMinion = MIN_DISTANCE_TO_MINION + Random.Range (-1f, 1f);
		// aimedPosition = new Vector3(Random.Range (1, 10), Random.Range (0, 10));
	}
	void shot () {
		if (this.state == SHOTING) {
			timeSinceLastShoot += Time.deltaTime;
			if (timeSinceLastShoot > DELAY_BETWEEN_SHOT) {
				// do the action of shoot
				timeSinceLastShoot = 0;
				needShot = true;
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
}
