using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHUD : MonoBehaviour
{
    float lastHit;
    PlayerHealth playerHealth;

    // Use this for initialization
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        lastHit += Time.deltaTime;
        if(lastHit > 1f && Input.GetKey(KeyCode.Space))
        {
            playerHealth.TakeDamage(12);
            lastHit = 0;
        }
    }
}
