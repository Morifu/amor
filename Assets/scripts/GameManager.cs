using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance;

	[HideInInspector]
	public GameController controller = null;

	// musics
	public AudioClip BackgroundMusic;
	public AudioClip winMusic;
	public AudioClip looseMusic;
	public AnimationClip fadeClip;

	[HideInInspector]
	public GameObject bgMusic;

	[HideInInspector]
	public bool isInGame = false;
	
	[HideInInspector]
	public bool GamePaused = false;

	[HideInInspector]
	public bool needReloadMusic = true;
	
	public void Save()
	{
		LevelData lvlData = controller.lvdata;
		for( int i = 1; i < lvlData.levels.Count+1; i++)
		{
			LevelData.LevelInfo lvlinfo = lvlData.getLevelInfo(i);
			PlayerPrefs.SetInt ("lvl"+i+"_arrowscnt", lvlinfo.arrowsUsed);
			PlayerPrefs.SetFloat ("lvl"+i+"_besttime", lvlinfo.bestTime);
			PlayerPrefs.SetInt ("lvl"+i+"_collectible", lvlinfo.collectible?1:0);
			PlayerPrefs.SetInt ("lvl"+i+"_extrapair", lvlinfo.extraPair?1:0);
			PlayerPrefs.SetInt ("lvl"+i+"_maxscore", lvlinfo.maxScore);
			PlayerPrefs.SetInt ("lvl"+i+"_state",(int)lvlinfo.lvlState);
		}
		PlayerPrefs.Save ();
	}

	public void Load()
	{
		LevelData lvlData = controller.lvdata;
		for( int i = 1; i < lvlData.levels.Count+1; i++)
		{
			LevelData.LevelInfo lvlinfo = lvlData.getLevelInfo(i);
			lvlinfo.arrowsUsed = PlayerPrefs.GetInt("lvl"+i+"_arrowscnt",0);
			lvlinfo.bestTime = PlayerPrefs.GetFloat("lvl"+i+"_besttime",3600);
			lvlinfo.collectible = (PlayerPrefs.GetInt("lvl"+i+"_collectible",0) > 0)?true:false;
			lvlinfo.extraPair = (PlayerPrefs.GetInt("lvl"+i+"_extrapair",0) > 0)?true:false;
			lvlinfo.maxScore = PlayerPrefs.GetInt("lvl"+i+"_maxscore",0);
			lvlinfo.lvlState = (LevelData.LevelState)PlayerPrefs.GetInt("lvl"+i+"_state",(int)LevelData.LevelState.LOCKED);
			if(i == 1 && lvlinfo.lvlState == LevelData.LevelState.LOCKED)
				lvlinfo.lvlState = LevelData.LevelState.UNLOCKED;
			lvlData.updateLevelInfo(i,lvlinfo);
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
				controller = gameObject.AddComponent<GameController>();
				Load ();
			}
		}
		else if (instance != this) 
		{
			instance.BackgroundMusic = BackgroundMusic;
			Destroy(gameObject);
		}
		if(instance.needReloadMusic)//instance.bgMusic == null)
		{
			Destroy(instance.bgMusic);
			instance.bgMusic = AudioHelper.CreateGetFadeAudioObject (instance.BackgroundMusic, true, instance.fadeClip);
			StartCoroutine (AudioHelper.FadeAudioObject (instance.bgMusic, 0.25f));
			instance.needReloadMusic = false;
		}
	}

	void Update()
	{
		controller.Update ();
	}

}
