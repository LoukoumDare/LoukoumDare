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

        // let the gameObject fall down
        gameObject.transform.position = new Vector2(0, 0);
    }

    void Update()
    {
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), transform.position.z);
		moveDirection = moveDirection * speed * Time.deltaTime;
		//moveDirection = transform.TransformDirection(moveDirection);
		controller.Move(moveDirection);


		Vector3 mouseworldpose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float AngleRad = Mathf.Atan2(mouseworldpose.x - transform.position.x, mouseworldpose.y - transform.position.y);
        float AngleDeg = -(180 / Mathf.PI) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }
    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    Rigidbody body = hit.collider.attachedRigidbody;

    //    // no rigidbody
    //    if (body == null || body.isKinematic)
    //    {
    //        return;
    //    }

    //    // We dont want to push objects below us
    //    if (hit.moveDirection.y < -0.3)
    //    {
    //        return;
    //    }

    //    // Calculate push direction from move direction,
    //    // we only push objects to the sides never up and down
    //    Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

    //    // If you know how fast your character is trying to move,
    //    // then you can also multiply the push velocity by that.

    //    // Apply the push
    //    body.velocity = pushDir * pushPower;
    //}
}
