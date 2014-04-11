using UnityEngine;
using System.Collections;

public class LevelData {

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
		int star3Count;
		int star2Count;
		int star1Count;

		public LevelState lvlState;
		public bool collectible;
		public int bestTime;
		public int arrowsUsed;
		public int maxScore;

		public LevelInfo(int star3, int star2, int star1)
		{
			star3Count = star3;
			star2Count = star2;
			star1Count = star1;

			lvlState = LevelState.LOCKED;
			collectible = false;
			bestTime = 0;
			arrowsUsed = 0;
			maxScore = 0;
		}

	};

	public ArrayList levels;

	public LevelData()
	{
		levels = new ArrayList ();

		LevelInfo lvl1 = new LevelInfo(5,3,1);
		LevelInfo lvl2 = new LevelInfo(5,3,1);
		LevelInfo lvl3 = new LevelInfo(5,3,1);
		LevelInfo lvl4 = new LevelInfo(5,3,1);
		LevelInfo lvl5 = new LevelInfo(5,3,1);

		levels.Add (lvl1);
		levels.Add (lvl2);
		levels.Add (lvl3);
		levels.Add (lvl4);
		levels.Add (lvl5);

	}

	public LevelInfo getLevelInfo(int lv)
	{
		if(lv-1 < 0)
			lv = 1;
		return (LevelInfo)levels [lv-1];
	}

	public void setLevelInfo(int lv, LevelInfo lvinfo)
	{
		if(lv-1 < 0)
			lv = 1;
		levels[lv-1] = lvinfo;
	}

}
