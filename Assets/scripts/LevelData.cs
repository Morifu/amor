using UnityEngine;
using System.Collections;

public class LevelData {

	public struct LevelInfo
	{
		public int star3Count;
		public int star2Count;
		public int star1Count;

		public bool cleared;
		public bool collectible;
		public int bestTime;
		public int arrowsUsed;
		public int maxScore;

		public LevelInfo(int star3, int star2, int star1)
		{
			star3Count = star3;
			star2Count = star2;
			star1Count = star1;

			cleared = false;
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



}
