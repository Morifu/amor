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

		public LevelState lvlState;
		public bool collectible;
		public bool extraPair;
		public float bestTime;
		public int arrowsUsed;
		public int maxScore;
		public float timeLimit;

		public bool hasBonus;
		public bool hasCollectible;

		public LevelInfo(int star2, int star3, float minTime, bool bonus = false, bool collect = false)
		{
			star3Count = star3;
			star2Count = star2;
			timeLimit = minTime;

			lvlState = LevelState.LOCKED;
			collectible = false;
			extraPair = false;
			bestTime = 3600;
			arrowsUsed = 0;
			maxScore = 0;
			hasBonus = bonus;
			hasCollectible = collect;
		}
		public string ToString()
		{
			return (int)lvlState +" "+ collectible.ToString()+ " " + maxScore;
		}

	};

	public ArrayList levels = null;

	void OnEnable()
	{
		if (levels == null)
		{
			levels = new ArrayList ();
			// constructor is LevelInfo( for 2 stars, for 3 stars, minimum time in seconds);
			LevelInfo lvl1 = new LevelInfo ( 8, 5, 10, false, false);
			LevelInfo lvl2 = new LevelInfo ( 12, 6, 20, false, false);
			LevelInfo lvl3 = new LevelInfo ( 10, 5, 30, false, false);
			LevelInfo lvl4 = new LevelInfo ( 22, 11, 50, true, false);
			LevelInfo lvl5 = new LevelInfo ( 15, 8, 50, false, true);
			LevelInfo lvl6 = new LevelInfo ( 25, 11, 50, true, true);
			LevelInfo lvl7 = new LevelInfo ( 15, 7, 70, false, true);
			LevelInfo lvl8 = new LevelInfo ( 20, 14, 70, true, true);
			LevelInfo lvl9 = new LevelInfo ( 20, 12, 80, false, true);
			LevelInfo lvl10 = new LevelInfo ( 23, 11, 80, true, true);
			LevelInfo lvl11 = new LevelInfo ( 45, 20, 110, true, true);
			LevelInfo lvl12 = new LevelInfo ( 32, 15, 200, false, true);

			lvl1.lvlState = LevelState.UNLOCKED;
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

	public void unlockLevel(int lv)
	{
		if(lv-1 < 0)
			lv = 1;
		if(lv > 12) return;
		LevelInfo info = (LevelInfo)levels [lv - 1];
		if(info.lvlState == LevelState.LOCKED)
		{
			info.lvlState = LevelState.UNLOCKED;
			levels [lv - 1] = info;
		}
	}

}
