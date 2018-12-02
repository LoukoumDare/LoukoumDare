using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowController : MonoBehaviour {
    private Vector3 moveDirection = Vector3.zero;
    public float damage = 10f;
    public int damageOnPlayerHit = 10;
    void Update()
    {
        moveDirection = new Vector3(1, 0, 0) * Time.deltaTime * 7;
        transform.Translate(moveDirection);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            PlayerHealth playerHealth = collision.gameObject.GetComponentInParent<PlayerHealth>();
            playerHealth.TakeDamage((int)damageOnPlayerHit);
        }
    }
}
