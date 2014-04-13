using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance;

	[HideInInspector]
	public GameController controller = null;

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
		LevelData lvlData = controller.lvdata;
		for( int i = 1; i < lvlData.levels.Count+1; i++)
		{
			LevelData.LevelInfo lvlinfo = lvlData.getLevelInfo(i);
			PlayerPrefs.SetInt ("lvl"+i+"_arrowscnt", lvlinfo.arrowsUsed);
			PlayerPrefs.SetFloat ("lvl"+i+"_besttime", lvlinfo.bestTime);
			PlayerPrefs.SetInt ("lvl"+i+"_collectible", lvlinfo.collectible?1:0);
			PlayerPrefs.SetInt ("lvl"+i+"_maxscore", lvlinfo.maxScore);
		}
		PlayerPrefs.Save ();
	}

	public void Load()
	{
		LevelData lvlData = controller.lvdata;
		for( int i = 1; i < lvlData.levels.Count+1; i++)
		{
			LevelData.LevelInfo lvlinfo = lvlData.getLevelInfo(i);
			lvlinfo.arrowsUsed = PlayerPrefs.GetInt("lvl"+i+"_arrowscnt");
			lvlinfo.bestTime = PlayerPrefs.GetFloat("lvl"+i+"_besttime");
			lvlinfo.collectible = (PlayerPrefs.GetInt("lvl"+i+"_collectible") > 0)?true:false;
			lvlinfo.maxScore = PlayerPrefs.GetInt("lvl"+i+"_maxscore");
		}

	}

	// Use this for initialization
	void Awake () {
		if(instance == null)
		{
			DontDestroyOnLoad (gameObject);
			instance = this;

			// create level controller
			if(controller == null)
			{
				controller = ScriptableObject.CreateInstance<GameController>();
				Load ();
			}
		}
		else if (instance != this) 
		{
			Destroy(gameObject);
		}

	}

}
