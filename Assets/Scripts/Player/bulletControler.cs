using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControler : MonoBehaviour {
	public float damage = 10f;
    public float speed = 10f;
    void Update()
    {
        Vector3 moveDirection = new Vector3(1,0,0) * Time.deltaTime*speed;
        transform.Translate(moveDirection);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
