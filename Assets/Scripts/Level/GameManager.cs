using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

	//change game mode
	//pause game
	//check for mode completion
	//switch to sacrifice mode

	static GameManager mInstance;

	public static GameManager Instance
	{
		get
		{
			if (mInstance == null)
			{
				GameObject go = new GameObject();
				mInstance = go.AddComponent<GameManager>();
			}
			return mInstance;
		}
	}

	enum e_gameMode
	{
		PROTECT,
		FETCH,
		SHMUP,
		COUNT
	}
	private e_gameMode currentGameMode;
	private AGameMode gameMode;

	void Awake()
	{
		EventManager.StartListening("MODE_SUCCEDED", gameModeSucceded);
		ChangeGameMode();
	}

	// Update is called once per frame
	void Update()
	{
		gameMode.Update();
	}

	public void gameModeSucceded()
	{
		//launch exchange with devil



		//launch new game mode
		ChangeGameMode();
	}

	private void ChangeGameMode()
	{
		if (gameMode != null)
			gameMode.Disable();

		currentGameMode = (e_gameMode)Random.Range(0, (int)e_gameMode.COUNT);
		switch (currentGameMode)
		{
			case e_gameMode.PROTECT:
				gameMode = new ProtectGameMode();
				break;
			case e_gameMode.FETCH:
				gameMode = new ProtectGameMode();
				break;
			case e_gameMode.SHMUP:
				gameMode = new ProtectGameMode();
				break;
			default:
				break;
		}
	}
}

public class AGameMode
{
	public virtual void checkGameModeCompletion() { }

	public virtual void Disable() { }

	public virtual void Update() { }
}

public class ProtectGameMode
	: AGameMode
{
	public float timerMax = 25;
	public float timer;
	//private bool killAllowed = false; //to allow the kill of a cat

	public ProtectGameMode()
		: base()
	{
		timer = timerMax;
		EventManager.StartListening("KILL_CAT", checkKillCat);
	}

	public override void Disable()
	{
		EventManager.StopListening("KILL_CAT", checkKillCat);
	}


	public void checkKillCat()
	{
		if (timer <= 0)
		{
			timer = 0;
			EventManager.TriggerEvent("MODE_SUCCEDED");
		}
		else
		{
			EventManager.TriggerEvent("SPAWN_LARGE_WAVE");
		}
	}

	public override void Update()
	{
		timer -= Time.deltaTime;
	}

}

public class FetchGameMode
	: AGameMode
{
	public FetchGameMode()
		: base()
	{
		EventManager.StartListening("KILL_CAT", killCat);
	}

	public override void Disable()
	{
		EventManager.StopListening("KILL_CAT", killCat);
	}

	public void killCat()
	{
		EventManager.TriggerEvent("MODE_SUCCEDED");
	}

}

public class ShmupGameMode
	: AGameMode
{
	public int nbCatKilledMax = 10;

	public ShmupGameMode()
		: base()
	{
		EventManager.StartListening("KILL_CAT", killCat);
	}

	public override void Disable()
	{
		EventManager.StopListening("KILL_CAT", killCat);
	}

	public void killCat()
	{
		nbCatKilledMax--;
		if (nbCatKilledMax <= 0)
			EventManager.TriggerEvent("MODE_SUCCEDED");
	}
}