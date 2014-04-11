using UnityEngine;
using System.Collections;

public class GameController {

	int currentLvl = 1;
	public LevelData lvdata;

	public GameController()
	{
		lvdata = new LevelData ();
	}

	public void UpdateData()
	{
		LevelData.LevelInfo info = lvdata.getLevelInfo(currentLvl);
		info.maxScore = 1000;
		info.collectible = false;
		info.bestTime = 320;
		info.arrowsUsed = 6;
		lvdata.setLevelInfo(1,info);
		GameManager.instance.Save();
	}
}
