using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacrificeManager : MonoBehaviour
{

	//private Transform player;



	/// Useful object
	public Transform halfVisionHidingObj;

	public enum e_sacrifice
	{
		HIDE_HUD,
		REDUCE_VISION,
		HALF_VISION,
		SLIPPERY,
		MOVE_OR_SHOOT,

		COUNT
	}

	// Use this for initialization
	void Start()
	{
		//TODO get player
	}

	// Update is called once per frame
	void Update()
	{

		for (int i = 0; i < 10; ++i)
		{
			if (Input.GetKeyDown("" + i))
			{
				Debug.Log((e_sacrifice)i);
				Sacrifice((e_sacrifice)i);
			}
		}


	}

	void Sacrifice(e_sacrifice _sacrificeType)
	{
		//e_sacrifice sacr = (e_sacrifice)Random.Range(0, (int)e_sacrifice.COUNT);

		//_sacrificeType = e_sacrifice.HALF_VISION;
		switch (_sacrificeType)
		{
			case e_sacrifice.HIDE_HUD:

				break;
			case e_sacrifice.REDUCE_VISION:
				{
					GameObject player = GameObject.FindGameObjectWithTag("Player");
					Transform visionMaskField = player.transform.Find("VisionFieldMask");
					visionMaskField.localScale -= new Vector3(1, 1, 0);
					Debug.Log("Reduce Vision");
					break;
				}
			case e_sacrifice.HALF_VISION:
				{
					GameObject player = GameObject.FindGameObjectWithTag("Player");
					var halfVisionObject = Instantiate(halfVisionHidingObj, player.transform.position, player.transform.rotation);
					halfVisionObject.transform.parent = player.transform;
					Debug.Log("HalF Vision");
					break;
				}
			case e_sacrifice.SLIPPERY:
				break;
			case e_sacrifice.MOVE_OR_SHOOT:
				break;
			default:
				break;
		}

	}

}
