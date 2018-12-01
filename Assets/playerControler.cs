using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerControler : MonoBehaviour
{

    public float speed = 6.0f;

    private Vector2 moveDirection = Vector2.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // let the gameObject fall down
        gameObject.transform.position = new Vector2(0, 0);
    }

    void Update()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection * speed;
        //rotateDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Horizontal"));
        //transform.rotation = Quaternion.LookRotation(rotateDirection);
        //rotateDirection = transform.Rotate(rotateDirection);
        //rotateDirection = rotateDirection * speed;

        if (Input.GetButton("Jump"))
        {
            //transform.Rotate(moveDirection, Time.deltaTime);
        }
        if (Input.GetButton("Fire1"))
        {
            //controller.Move(*Time.deltaTime);
        }
        controller.Move(moveDirection * Time.deltaTime);
        Vector3 mouseworldpose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float AngleRad = Mathf.Atan2(mouseworldpose.y - transform.position.y, mouseworldpose.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }
}
