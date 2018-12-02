using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform _player;
	Vector2 minPos;
	Vector2 maxPos;

	public BoxCollider2D _boxCollider;
	private Camera _camera;

	// Use this for initialization
	void Start () {
		//_boxCollider = GetComponent<BoxCollider2D>();
		_camera = GetComponent<Camera>();

		minPos = -_boxCollider.bounds.extents + new Vector3(_camera.orthographicSize * _camera.aspect, _camera.orthographicSize, 0);
		maxPos = _boxCollider.bounds.extents - new Vector3(_camera.orthographicSize * _camera.aspect, _camera.orthographicSize, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(Mathf.Clamp(_player.position.x,minPos.x, maxPos.x), Mathf.Clamp(_player.position.y, minPos.y, maxPos.y) , transform.position.z);
		
	}
}
