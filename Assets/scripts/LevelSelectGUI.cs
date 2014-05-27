using UnityEngine;
using System.Collections;

public class LevelSelectGUI : MonoBehaviour {

	public Rect position;
	public GUISkin buttonSkins;
	public Texture2D[] buttons;
	Texture2D[] pageButtons;
	public Texture2D blankLvBG;
	public Texture2D pytajnik;
	public Rect leftButton;
	public GUIStyle leftButtonStyle;
	public Rect rightButton;
	public GUIStyle rightButtonStyle;
	public GUIStyle style;

	LevelData lvldata;

	int selected = -1;
	int pageNum = 0;

	// Use this for initialization
	void Start () {
		pageButtons = new Texture2D[6];
		lvldata = GameManager.instance.controller.lvdata;
		for (int i = 0; i < 6 ; i++)
		{
			LevelData.LevelInfo info = lvldata.getLevelInfo(i+1);
			if(info.lvlState == LevelData.LevelState.LOCKED)
				pageButtons[i] = blankLvBG;
			else
				pageButtons[i] = buttons[i];
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() 
	{
		GUI.depth = -1;

		Rect pos = new Rect (position.x * Screen.width,
		                    position.y * Screen.height,
		                    position.width * Screen.width,
		                    position.height * Screen.height);

		GUI.BeginGroup (pos);
		Rect tempPos = new Rect (0, 0, pos.width, pos.height);


		selected = GUI.SelectionGrid(tempPos, selected, pageButtons, 3, style);

		int lower = (int)(tempPos.y + tempPos.height/2);
		for(int i = 0; i < 3; i++)
		{
			int posx = (int)(tempPos.x + (tempPos.width/3)*(i));
			Rect firstRow = new Rect(posx,tempPos.y,tempPos.width/3,tempPos.height/2);
			Rect secondRow = new Rect(posx, lower, tempPos.width/3,tempPos.height/2);
			drawScores(firstRow,(i+1)+(6*pageNum));
			drawScores(secondRow,(i+4)+(6*pageNum));
		}

		GUI.EndGroup ();

		if(selected != -1)
		{
			Debug.Log("selected = "+selected);
			LevelData.LevelInfo info = lvldata.getLevelInfo(selected+1);
			if(info.lvlState != LevelData.LevelState.LOCKED)
			{
				GameManager.instance.controller.setNextLevel(selected+1);
				GameManager.instance.needReloadMusic = true;
				Application.LoadLevel("lv"+(selected+1));
			}
		}
		
		if(GUI.Button (leftButton,"",leftButtonStyle))
		{
			if(pageNum == 0)
				Application.LoadLevel("mainMenu");
			else
			{
				pageNum--;
				reloadPage();
				Debug.Log("left Button");
			}

		}
		if(GUI.Button (rightButton, "",rightButtonStyle))
		{
			if(pageNum < 1)
			{
				pageNum++;
				reloadPage();
				Debug.Log("right Button");
			}
		}
	}

	void reloadPage()
	{
		for (int i = 0; i < 6 ; i++)
		{
			LevelData.LevelInfo info = lvldata.getLevelInfo((i+1)+(6*pageNum));
			if(info.lvlState == LevelData.LevelState.LOCKED)
				pageButtons[i] = blankLvBG;
			else
				pageButtons[i] = buttons[i+(6*pageNum)];
		}
	}

	void drawScores(Rect position, int lvlNumber)
	{
		Debug.Log ("position: " + position + " lvlnumber: " + lvlNumber);

		GUI.BeginGroup (position);

		LevelData.LevelInfo info = lvldata.getLevelInfo(lvlNumber);

		if(info.lvlState == LevelData.LevelState.LOCKED)
		{
			// if level is locked draw just question mark
			GUI.DrawTexture(new Rect (position.width/2-pytajnik.width/2,
			                          position.height/2-pytajnik.height/2,pytajnik.width,
			                          pytajnik.height),
			                pytajnik);
		}
		else
		{
			// here we draw all the scores for the level


		}

		GUI.EndGroup();
	}
}
