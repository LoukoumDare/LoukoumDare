using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMotion : MonoBehaviour {
	public Vector3 aimedPosition;
	public float speed = 1f;
	private float x;
	private float y;
	// Use this for initialization
	void Start () {
		aimedPosition = new Vector3(Random.Range (-3, 3), Random.Range (-3, 3));
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 diffPosition = aimedPosition - transform.position;

		if (diffPosition.magnitude < speed * Time.deltaTime) {
			transform.position = aimedPosition;
			
		} else {
			
			transform.Translate (diffPosition.normalized * speed * Time.deltaTime);
		}
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Bullet")
        //{
            Destroy(gameObject);
        //}
    }
}
