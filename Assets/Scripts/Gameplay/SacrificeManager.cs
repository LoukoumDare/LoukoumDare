using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacrificeManager : MonoBehaviour {

	//private Transform player;



	/// Useful object
	public Transform halfVisionHidingObj;

	public enum e_sacrifice
	{
		HIDE_HUD,
		REDUCE_VISION,
		HALF_VISION,
		SLIPPERY,

		COUNT
	}

	// Use this for initialization
	void Start () {
		//TODO get player
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("HalF Vision");

			Sacrifice();
		}

		
	}

	void Sacrifice ()
	{
		//e_sacrifice sacr = (e_sacrifice)Random.Range(0, (int)e_sacrifice.COUNT);

		e_sacrifice sacr = e_sacrifice.HALF_VISION;
		switch (sacr)
		{
			case e_sacrifice.HIDE_HUD:

				break;
			case e_sacrifice.REDUCE_VISION:
				break;
			case e_sacrifice.HALF_VISION:
				GameObject player = GameObject.FindGameObjectWithTag("Player");
				var halfVisionObject = Instantiate(halfVisionHidingObj, player.transform.position, player.transform.rotation);
				halfVisionObject.transform.parent = player.transform;
				Debug.Log("HalF Vision");
				break;
			case e_sacrifice.SLIPPERY:
				break;
			case e_sacrifice.COUNT:
				break;
			default:
				break;
		}

	}

}
