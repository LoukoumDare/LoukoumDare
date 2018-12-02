using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerControler : MonoBehaviour
{

    public float speed = 6.0f;

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
		//moveDirection = transform.TransformDirection(moveDirection);
		controller.Move(moveDirection);


		//Vector3 mouseworldpose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //float AngleRad = Mathf.Atan2(mouseworldpose.x - transform.position.x, mouseworldpose.y - transform.position.y);
        //float AngleDeg = -(180 / Mathf.PI) * AngleRad;
        //this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }
}
