using UnityEngine;
using System.Collections;

// class which does not need to be attached to gameobject should 
// derive from ScriptableObject
// There is always one GameController as it
// is created in GameManager singleton
public class GameController : MonoBehaviour {

	// number of current lv
	public int currentLvl = 1;
	public int nextLevel;

	// info on all levels
	[HideInInspector]
	public LevelData lvdata = null;

	// score in current lvl
	public int scoreCount  = 0;
	// best time in level in seconds
	public float time = 0;
	// arrows used on the level
	public int arrowCount = 0;
	// if bonus was collected on level or not
	public bool bonusCollected = false;
	// if bonus was collected on level or not
	public bool extraPair = false;
	// number of stars collected	
	public int starsCount = 0;
	// seconds left from max time
	public float secondsLeft = 0;
	//flag if level is completed
	public bool levelCompleted = false;
	//flag if show level loose
	public bool levelFailed = false;
	//info on current level
	[HideInInspector]
	public LevelData.LevelInfo lvlInfo;


	// scriptableObjects method for enabling script
	void OnEnable()
	{
		// let's create level data if it does not exists already
		if(lvdata == null)
			lvdata = ScriptableObject.CreateInstance<LevelData> ();

	}

	public void setNextLevel(int lvl)
	{
		currentLvl = lvl;
		nextLevel = lvl;
		if(lvl != 0)
		{
			Destroy(GameManager.instance.bgMusic);
			GameManager.instance.needReloadMusic = true;
		}
	}

	// level initializer, here we start counting time
	public void LevelStart()
	{
		levelCompleted = false;
		levelFailed = false;
		time = Time.time;
		scoreCount  = 0;
		arrowCount = 0;
		starsCount = 1;
		bonusCollected = false;
		extraPair = false;
		lvlInfo = lvdata.getLevelInfo (currentLvl);
		if(GameManager.instance.bgMusic == null)
		{
			GameManager.instance.bgMusic = AudioHelper.CreateGetFadeAudioObject (GameManager.instance.BackgroundMusic, true, GameManager.instance.fadeClip);
			StartCoroutine (AudioHelper.FadeAudioObject (GameManager.instance.bgMusic, 0.25f));
		}
	}

	public void Update()
	{
		if(lvlInfo.star3Count >= arrowCount)
			starsCount = 3;
		else if(lvlInfo.star2Count >= arrowCount)
			starsCount = 2;
		else 
			starsCount = 1;
	}

	// level is completed, lets count points and update stats
	public void LevelCompleted()
	{
		scoreCount = 0;
		levelCompleted = true;
		//levelFailed = true;
		// first count stars gathered
		lvlInfo.lvlState = LevelData.LevelState.STAR1COMPLETE;
		if(lvlInfo.star3Count >= arrowCount)
		{
			starsCount = 3;
			lvlInfo.lvlState = LevelData.LevelState.STAR3COMPLETE;
		}
		else if(lvlInfo.star2Count >= arrowCount)
		{
			starsCount = 2;
			lvlInfo.lvlState = LevelData.LevelState.STAR2COMPLETE;
		}
		else
		{
			starsCount = 1;
			lvlInfo.lvlState = LevelData.LevelState.STAR1COMPLETE;
		}

		scoreCount += 1000 * starsCount;

		time = Time.time - time;

		secondsLeft = lvlInfo.timeLimit - time;
		if(secondsLeft > 0)
			scoreCount += ((int)secondsLeft)*20;

		if(bonusCollected)
			scoreCount += 500;

		if(extraPair)
			scoreCount += 1000;

		//GameManager.instance.winScreen.SetActive (true);
		StartCoroutine (AudioHelper.FadeAudioObject (GameManager.instance.bgMusic, -1f));
		AudioHelper.CreatePlayAudioObject (GameManager.instance.winMusic);
		UpdateData ();
	}

	public void LevelFailed()
	{
		StartCoroutine (AudioHelper.FadeAudioObject (GameManager.instance.bgMusic, -1f));
		AudioHelper.CreatePlayAudioObject (GameManager.instance.looseMusic);
		levelFailed = true;
	}

	// method for updating levelData with updated scores and save progress
	void UpdateData()
	{

		// we get current level from level list and update bes scores
		LevelData.LevelInfo info = lvlInfo;
		info.maxScore = (info.maxScore > scoreCount)?info.maxScore:scoreCount;
		info.collectible = bonusCollected;
		info.extraPair = extraPair;
		info.bestTime = (info.bestTime > (Time.time - time))?(Time.time - time):info.bestTime;
		info.arrowsUsed = arrowCount;
		lvdata.updateLevelInfo(currentLvl,info);
		GameManager.instance.Save();
	}
}
