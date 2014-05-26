using UnityEngine;
using System.Collections;

public class LevelSelectGUI : MonoBehaviour {

	public Rect position;
	public GUISkin buttonSkins;
	public Texture2D[] buttons;
	Texture2D[] pageButtons;
	public Rect leftButton;
	public GUIStyle leftButtonStyle;
	public Rect rightButton;
	public GUIStyle rightButtonStyle;
	public GUIStyle style;

	int selected = -1;
	int pageNum = 0;

	// Use this for initialization
	void Start () {
		pageButtons = new Texture2D[6];

		for (int i = 0; i < 6 ; i++)
		{
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


		selected = GUI.SelectionGrid(tempPos, selected, pageButtons, 3,style);

		GUI.EndGroup ();

		if(selected != -1)
		{
			Debug.Log("selected = "+selected);
			GameManager.instance.controller.setNextLevel(selected+1);
			GameManager.instance.needReloadMusic = true;
			Application.LoadLevel("lv"+(selected+1));
		}
		
		if(GUI.Button (leftButton,"",leftButtonStyle))
		{
			if(pageNum == 0)
				Application.LoadLevel("mainMenu");
			else
			{
				pageNum--;
				reloadPage();
			}

		}
		if(GUI.Button (rightButton, "",rightButtonStyle))
		{
			if(pageNum < 1)
			{
				pageNum++;
				reloadPage();
			}
		}
	}

	void reloadPage()
	{
		for (int i = 0; i < 6 ; i++)
		{
			pageButtons[i] = buttons[i+(6*pageNum)];
		}
	}

	void drawScores(Rect position, int lvlNumber)
	{

	}
}
