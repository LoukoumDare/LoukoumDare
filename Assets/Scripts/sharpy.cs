using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharpy : MonoBehaviour {

	public Vector3 aimedPosition;
	public float speed = 1f;
	private float SPEED_BOOST = 3f;
	private float SPEED_STANDARD = 1f;
	private float x;
	private float y;
	public float timeSinceLastChangeState = 0;
	public int state;
	private int STANDARD = 0;
	private int BOOST = 1;

	public float BOOST_TIME_DURATION = 4;
	public float STANDARD_TIME_DURATION = 10;

	void Start () {
		aimedPosition = new Vector3(Random.Range (1, 10), Random.Range (0, 10));
	}

	void checkState () {
		this.timeSinceLastChangeState += Time.deltaTime;
		if (state == BOOST) {
			if (this.timeSinceLastChangeState > this.BOOST_TIME_DURATION) {
				this.timeSinceLastChangeState =  0;	
				this.state = STANDARD;
				this.speed = SPEED_STANDARD;
			}
		} else if (state == STANDARD) {
			if (this.timeSinceLastChangeState > this.STANDARD_TIME_DURATION) {
				this.timeSinceLastChangeState =  0;	
				this.state = BOOST;
				this.speed = SPEED_BOOST;
			}
		}

	}

	void Update () {
		Vector3 diffPosition = aimedPosition - transform.position;
		this.checkState ();

		if (diffPosition.magnitude < speed * Time.deltaTime) {
			transform.position = aimedPosition;

		} else {
			transform.Translate (diffPosition.normalized * speed * Time.deltaTime);
		}
	}
}
