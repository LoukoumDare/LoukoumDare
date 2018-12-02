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
        transform.rotation = Player.transform.rotation;
    }
}
