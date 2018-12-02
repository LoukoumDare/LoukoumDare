using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SacrificeManager : MonoBehaviour
{

	//private Transform player;



	/// Useful object
	public Transform halfVisionHidingObj;
	public Transform hudToHide;
	public PlayerHealth phealth;
	public GameObject satanCanvas;

	private bool hudneedtobeshownagainafterdevil = false;

	private e_sacrifice sacri1;
	private e_sacrifice sacri2;

	[Flags]
	public enum e_sacrifice
	{
		HIDE_HUD = 1,
		REDUCE_VISION = 2,
		HALF_VISION = 4,
		NONE = 8,
		MOVE_OR_SHOOT = 16,
		NO_AUTOSHOOT = 32,
		HALF_LIFE = 64
	}
	e_sacrifice sacrificesDone = 0;

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
				Sacrifice((e_sacrifice)(1 << i));
			}
		}

		if (Input.GetKeyDown(KeyCode.Return))
		{
			WaitForSacrifice();
			Debug.Log("coucou");
		}

	}

	public e_sacrifice getRandomSacrifice()
	{
		List<int> sacrificePool = new List<int>();


		foreach (int i in Enum.GetValues(typeof(e_sacrifice)))
		{
		//Debug.Log(i);
			if ((sacrificesDone & (e_sacrifice)i) != 0)
			{
			}
			else
			{
				//Debug.Log(i);
				sacrificePool.Add(i);
			}
		}
		return (e_sacrifice)sacrificePool[UnityEngine.Random.Range(0, sacrificePool.Count - 1)];
	}

	private void WaitForSacrifice()
	{
		hudneedtobeshownagainafterdevil = hudToHide.gameObject.activeInHierarchy;
		Debug.Log(hudneedtobeshownagainafterdevil);
		hudToHide.gameObject.SetActive(false);
		satanCanvas.SetActive(true);
		Time.timeScale = 0.1f;
		sacri1 = getRandomSacrifice();
		sacri2 = getRandomSacrifice();
	}

	public void Sacrifice(int _sacrificeType)
	{
		Debug.Log(_sacrificeType);
		if (_sacrificeType == 0)
			Sacrifice((e_sacrifice)sacri1);
		else
			Sacrifice((e_sacrifice)sacri2);

		satanCanvas.SetActive(false);

		hudToHide.gameObject.SetActive(hudneedtobeshownagainafterdevil);
	}

	void Sacrifice(e_sacrifice _sacrificeType)
	{
		switch (_sacrificeType)
		{
			case e_sacrifice.HIDE_HUD:
				hudToHide.gameObject.SetActive(false);
				hudneedtobeshownagainafterdevil = false;
				Debug.Log("HIDE_HUD");
				break;
			case e_sacrifice.REDUCE_VISION:
				{
					Transform player = GameObject.FindGameObjectWithTag("Player").transform;
					Transform visionMaskField = player.parent.transform.Find("VisionMaskPrefab");
					visionMaskField.localScale -= new Vector3(3, 3, 0);
					if (visionMaskField.localScale.x <= 1)
					{
						visionMaskField.localScale = new Vector3(1, 1, 1);
						sacrificesDone |= e_sacrifice.REDUCE_VISION;
					}
					Debug.Log("Reduce Vision");
					break;
				}
			case e_sacrifice.HALF_VISION:
				{
					Debug.Log("HalF Vision");
					GameObject player = GameObject.FindGameObjectWithTag("Player");
					var halfVisionObject = Instantiate(halfVisionHidingObj, player.transform.position, player.transform.rotation);
					halfVisionObject.transform.parent = player.transform;
					sacrificesDone |= e_sacrifice.HALF_VISION;
					break;
				}
			case e_sacrifice.NONE:
				break;
			case e_sacrifice.MOVE_OR_SHOOT:
				EventManager.TriggerEvent("MOVE_OR_SHOOT");
				sacrificesDone |= e_sacrifice.MOVE_OR_SHOOT;
				Debug.Log("MOVE_OR_SHOOT");
				break;
			case e_sacrifice.NO_AUTOSHOOT:
				EventManager.TriggerEvent("NO_AUTOSHOOT");
				sacrificesDone |= e_sacrifice.NO_AUTOSHOOT;
				Debug.Log("NO_AUTOSHOOT");
				break;
			case e_sacrifice.HALF_LIFE:
				phealth.diminishHealth(0.35f);
				Debug.Log("HALF_LIFE");
				break;
			default:
				break;
		}

		Time.timeScale = 1;

	}

}
