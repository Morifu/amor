using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int arrowCount = 0;
	
	public static GameManager instance;

	LevelData lvlData = null;

	bool gamePaused = false;

	public bool GamePaused {
		get {
			return gamePaused;
		}
		set {
			gamePaused = value;
		}
	}

	public void Save()
	{
		PlayerPrefs.SetInt ("lvl1data", 5);
	}

	public void Load()
	{

	}

	// Use this for initialization
	void Awake () {
		if(instance == null)
		{
			DontDestroyOnLoad (gameObject);
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
		if(lvlData == null)
			lvlData = new LevelData ();
	}

}
