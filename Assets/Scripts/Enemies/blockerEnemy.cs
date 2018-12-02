using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockerEnemy : MonoBehaviour {
	public Vector3 aimedPosition;
	public float speed = 1f;
	public float bumpSpeed = 0f;
	private float x;
	private float y;
	public float timeSinceLastChangeState = 0;
	public int state = 0;
	private int STANDARD = 0;
	private int CLOSE_BY = 1;
	public float MIN_DISTANCE_TO_MINION = 1;
	public float BOOST_TIME_DURATION = 0.25f;
	public float BUMP_SPEED = -1f;
	public float distanceToMinion = 1f;
	public float damage = 1;
	public float PUSH_DURATION_WHEN_HITED = 0.2f;
	public float attackRange = 2.5f;
	enemyHealth _enemyHealth;
	PlayerHealth playerHealth;

    bool facingRight = true;

    void Start () {
		this.distanceToMinion = MIN_DISTANCE_TO_MINION + Random.Range (-1f, 1f);
		// aimedPosition = new Vector3(Random.Range (1, 10), Random.Range (0, 10));
	}
	void checkBumb () {
		if (state == CLOSE_BY) {
			this.timeSinceLastChangeState += Time.deltaTime;
			if (false) { // cest doka ca
				this.timeSinceLastChangeState = 0;	
				this.state = STANDARD;
				this.bumpSpeed = 0;

			} else {
			}
		} else {
			bumpSpeed = 0f;
		}
	}
	void randomRotateItem () {
		this.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360) * -1);
	}
	void Update () {
		aimedPosition = GameObject.Find("player").transform.position;
		//float AngleRad = Mathf.Atan2(aimedPosition.x - transform.position.x, aimedPosition.y - transform.position.y);
		//float AngleDeg = (180 / Mathf.PI) * AngleRad * -1;
		//this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg); 

		Vector3 diffPosition = aimedPosition - transform.position;
		Vector3 vectorMotion = diffPosition.normalized * speed * Time.deltaTime;
		Vector3 vectorShift = transform.right * this.bumpSpeed * Time.deltaTime;

		// checkBumb ();
		if (diffPosition.magnitude < this.attackRange) {
			GetComponent <enemyAttack> ().checkAttack ();
		} else {
			if (diffPosition.magnitude < speed * Time.deltaTime && state != CLOSE_BY ) {
				// transform.position = aimedPosition;
				this.state = CLOSE_BY;
				this.bumpSpeed = 0;
				this.speed = 0f;
				// randomRotateItem ();

			} else if ( diffPosition.magnitude < (this.distanceToMinion)  && state != CLOSE_BY ) {
				this.state = CLOSE_BY;
				this.bumpSpeed = this.BUMP_SPEED + Random.Range(0f, -2f);
				this.speed = 0f;
			} else {
                var translationVector = vectorMotion + vectorShift;
                transform.Translate(translationVector, Space.World);

                if ((facingRight && translationVector.x < -0.01) || (!facingRight && translationVector.x > 0.01))
                {
                    facingRight = !facingRight;
                    transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
                }
            }
		}
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Bullet")
		{
			_enemyHealth = GetComponent <enemyHealth> ();
			_enemyHealth.TakeDamage ((int)(collision.gameObject.GetComponent<bulletControler> ().damage), new Vector3(0, 0, 0));
			Destroy(collision.gameObject, PUSH_DURATION_WHEN_HITED);
		}
		if (collision.gameObject.tag == "Player")
		{
			// Destroy(gameObject);
			playerHealth = collision.gameObject.GetComponentInParent<PlayerHealth>();
			playerHealth.TakeDamage ((int)(this.damage));
		}
	}
}
