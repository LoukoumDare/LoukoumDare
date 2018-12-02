using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour {
    public bool follow = false;
    public float speed = 1;
    void Update()
    { 
        if (this.follow == true)
        {
            GameObject Player = GameObject.Find("player");
            Vector3 moveDirection = new Vector3(Player.transform.position.x-transform.position.x, Player.transform.position.y-transform.position.y, transform.position.z);
            moveDirection = moveDirection * speed * Time.deltaTime;
            transform.Translate(moveDirection);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        this.follow |= collision.gameObject.tag == "Player";
        if (collision.gameObject.tag == "Ennemy")
        {
            Destroy(gameObject);
        }
    }
}
