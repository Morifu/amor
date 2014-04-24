using UnityEngine;
using System.Collections;

// class which does not need to be attached to gameobject should 
// derive from ScriptableObject
// There is always one GameController as it
// is created in GameManager singleton
public class GameController : ScriptableObject {

	// number of current lv
	public int currentLvl = 1;

	// info on all levels
	[HideInInspector]
	public LevelData lvdata = null;

	// score in current lvl
	int scoreCount  = 0;
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
	//info on current level
	LevelData.LevelInfo lvlInfo;

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
	}

	// level initializer, here we start counting time
	public void LevelStart()
	{
		time = Time.time;
		scoreCount  = 0;
		arrowCount = 0;
		bonusCollected = false;
		extraPair = false;
		lvlInfo = lvdata.getLevelInfo (currentLvl);
	}

	// level is completed, lets count points and update stats
	public void LevelCompleted()
	{
		scoreCount = 0;

		// first count stars gathered
		starsCount = 1;
		lvlInfo.lvlState = LevelData.LevelState.STAR1COMPLETE;
		if(lvlInfo.star3Count > arrowCount)
		{
			starsCount = 3;
			lvlInfo.lvlState = LevelData.LevelState.STAR3COMPLETE;
		}
		else if(lvlInfo.star2Count > arrowCount)
		{
			starsCount = 2;
			lvlInfo.lvlState = LevelData.LevelState.STAR2COMPLETE;
		}
		scoreCount += 1000 * starsCount;

		secondsLeft = lvlInfo.timeLimit - (Time.time - time);
		if(secondsLeft > 0)
			scoreCount += ((int)secondsLeft)*20;

		if(bonusCollected)
			scoreCount += 500;

		if(extraPair)
			scoreCount += 1000;

		GameManager.instance.winScreen.SetActive (true);

		UpdateData ();
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
