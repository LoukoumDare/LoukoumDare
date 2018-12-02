using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject Player = GameObject.Find("player");
        transform.position= new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
        transform.rotation = Player.transform.rotation* Quaternion.Euler(0,0,90);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Enemi")
        //{
        //    // Destroy(gameObject);
        //    PlayerHealth playerHealth = this.GetComponentInParent<PlayerHealth>();
        //    playerHealth.TakeDamage((int)(collision.gameObject.damage));
        //}
    }
}
