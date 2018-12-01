using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var horizontalRight = Input.GetAxis("HorizontalRight");
        var verticalLeft = Input.GetAxis("VerticalRight");

        Debug.Log(new { horizontalRight, verticalLeft });

        transform.Rotate(Vector3.back, horizontalRight * 180f * Time.deltaTime);

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        Debug.Log(new { horizontal, vertical });

        var movement = new Vector3(vertical, -horizontal);

        transform.Translate(movement * Time.deltaTime * 10f);
    }
}
