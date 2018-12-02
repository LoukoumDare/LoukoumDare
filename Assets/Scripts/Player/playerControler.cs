using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerControler : MonoBehaviour
{

    public float speed = 4f;

    private Vector3 moveDirection = Vector2.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		moveDirection = moveDirection * speed * Time.deltaTime;
		controller.Move(moveDirection);
    }
}
