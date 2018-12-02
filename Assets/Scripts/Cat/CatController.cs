using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour {
    public bool follow = false;
    public float speed = 1;
    public int health;

    bool facingRight = false;

    void Start()
    {
        this.health = 3;
    }
    void Update()
    { 
        if (this.follow == true)
        {
            GameObject Player = GameObject.Find("player");
            Vector3 moveDirection = new Vector3(Player.transform.position.x-transform.position.x, Player.transform.position.y-transform.position.y, transform.position.z);
            moveDirection = moveDirection * speed * Time.deltaTime;
            transform.Translate(moveDirection);

            if ((facingRight && moveDirection.x < -0.01) || (!facingRight && moveDirection.x > 0.01))
            {
                facingRight = !facingRight;
                transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        this.follow |= collision.gameObject.tag == "Player";
        if (collision.gameObject.tag == "Enemy")
        {
            this.health = this.health - 1;
            if (this.health == 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
