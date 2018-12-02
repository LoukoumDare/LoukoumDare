﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControler : MonoBehaviour {
	public float damage = 100f;

    void Update()
    {
        Vector3 moveDirection = new Vector3(1,0,0) * Time.deltaTime*5;
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
