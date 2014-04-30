using UnityEngine;
using System.Collections;

public class LevelData : ScriptableObject {

	public enum LevelState
	{
		LOCKED = 0,
		UNLOCKED,
		STAR1COMPLETE,
		STAR2COMPLETE,
		STAR3COMPLETE
	}

	public struct LevelInfo
	{
		public int star3Count;
		public int star2Count;
		public int star1Count;

		public LevelState lvlState;
		public bool collectible;
		public bool extraPair;
		public float bestTime;
		public int arrowsUsed;
		public int maxScore;
		public float timeLimit;

		public LevelInfo(int star1, int star2, int star3, float minTime)
		{
			star3Count = star3;
			star2Count = star2;
			star1Count = star1;
			timeLimit = minTime;

			lvlState = LevelState.LOCKED;
			collectible = false;
			extraPair = false;
			bestTime = 3600;
			arrowsUsed = 0;
			maxScore = 0;
		}

	};

	public ArrayList levels = null;

	void OnEnable()
	{
		if (levels == null)
		{
			levels = new ArrayList ();
			// constructor is LevelInfo(for 1 star, for 2 stars, for 3 stars, minimum time in seconds);
			LevelInfo lvl1 = new LevelInfo (10, 6, 3, 10);
			LevelInfo lvl2 = new LevelInfo (15, 10, 5, 20);
			LevelInfo lvl3 = new LevelInfo (14, 9, 4, 30);
			LevelInfo lvl4 = new LevelInfo (8, 15, 25, 50);
			LevelInfo lvl5 = new LevelInfo (7, 14, 24, 50);
			LevelInfo lvl6 = new LevelInfo (11, 19, 30, 50);
			LevelInfo lvl7 = new LevelInfo (15, 20, 25, 70);
			LevelInfo lvl8 = new LevelInfo (15, 20, 25, 70);
			LevelInfo lvl9 = new LevelInfo (15, 20, 25, 80);
			LevelInfo lvl10 = new LevelInfo (15, 20, 25, 80);
			LevelInfo lvl11 = new LevelInfo (15, 20, 25, 110);
			LevelInfo lvl12 = new LevelInfo (15, 20, 25, 200);

			levels.Add (lvl1);
			levels.Add (lvl2);
			levels.Add (lvl3);
			levels.Add (lvl4);
			levels.Add (lvl5);
			levels.Add (lvl6);
			levels.Add (lvl7);
			levels.Add (lvl8);
			levels.Add (lvl9);
			levels.Add (lvl10);
			levels.Add (lvl11);
			levels.Add (lvl12);
		}
	}

	public LevelInfo getLevelInfo(int lv)
	{
		if(lv-1 < 0)
			lv = 1;
		return (LevelInfo)levels [lv-1];
	}

	public void updateLevelInfo(int lv, LevelInfo lvinfo)
	{
		if(lv-1 < 0)
			lv = 1;
		levels[lv-1] = lvinfo;
	}

}
