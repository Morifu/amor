using UnityEngine;
using System.Collections;

public class GUIManager: MonoBehaviour {
	[System.Serializable]
	public class ButtonData
	{
		public float width = 80;
		public float height = 80;
		public float offsetX = 10;
		public float offsetY = 10;
		public float positionX = 0;
		public float positionY = 0;
	}

	[System.Serializable]
	public class TextData
	{
		public string text;
		public GUIText guiTextReference;
		public float width = 80;
		public float height = 80;
		public float positionX = 0;
		public float positionY = 0;
	}

	[System.Serializable]
	public class SpriteData
	{
		public float positionX = 0;
		public float positionY = 0;
		public float size = 1;
	}


	// singleton, dont know what for for now
	[HideInInspector]
	public static GUIManager instance;

	public GUIStyle pauseButtonStyle;
	public ButtonData pauseButtonSizes;

	public GUIStyle restartButtonStyle;
	public ButtonData restartButtonSizes;
	
	public GUIStyle textStyle;

	// references for gui texts
	public GUIText arrowCountTXT;
	public GUITexture starsBG;
	public Sprite star;
	public GUIManager.SpriteData starsData;

	//public GUIText timeLeftTXT;
	GUIText LevelNumberTXT;

	bool hideLevelNumber = false;

	public float targetsHideTime = 5.0f;

	// Use this for initialization
	void Awake () {
//		if(instance == null)
//		{
//			DontDestroyOnLoad (gameObject);
//			instance = this;
//		}
//		else if (instance != this)
//		{
//			Destroy(gameObject);
//		}
	}

	void Start() {
		LevelNumberTXT = GameObject.Find("LevelNumber").GetComponent<GUIText> ();
	}

//	void OnEnable() {
//		Debug.Log ("script was enabled");
//	}
	
	void Update()
	{
		if(arrowCountTXT != null)
		{
			arrowCountTXT.text = string.Format("x{0:d}", GameManager.instance.controller.arrowCount);

		}

		if(LevelNumberTXT != null)
		{
			LevelNumberTXT.text = string.Format("LEVEL {0:d}", GameManager.instance.controller.currentLvl);
		}

//		if (timeLeftTXT != null && !GameManager.instance.controller.levelCompleted)
//		{
//			int seconds = (int)(Time.time - GameManager.instance.controller.time);
//			int minutes = (int)(seconds/60);
//
//			timeLeftTXT.text = string.Format("Time: {0:d2}:{1:d2}", minutes, seconds%60);
//		}

		if(!hideLevelNumber && (int)(Time.time - GameManager.instance.controller.time) > targetsHideTime)
		{
			hideLevelNumber = true;
			GameObject.Find("Targets").SetActive(false);
			LevelNumberTXT.enabled = false;
		}
	}

	void OnGUI() {

		// lets draw outline on all texts
		// outline for arrow count text
		Rect screenRect = arrowCountTXT.GetScreenRect ();
		screenRect.y = Screen.height - (screenRect.y+screenRect.height);
		DrawOutline(screenRect,arrowCountTXT.text, arrowCountTXT,textStyle ,Color.black,arrowCountTXT.color);

		if(!hideLevelNumber)
		{
			// outline for LevelNumberTXT text
			screenRect = LevelNumberTXT.GetScreenRect ();
			screenRect.y = Screen.height - (screenRect.y+screenRect.height);
			DrawOutline(screenRect,LevelNumberTXT.text, LevelNumberTXT, textStyle,Color.black,LevelNumberTXT.color);
		}

		for (int i = 0; i < GameManager.instance.controller.starsCount; i++)
		{

			float starWidth = star.rect.width*((starsBG.GetScreenRect().height/star.rect.height)*starsData.size)*1.07f;
			Rect starFillRect = new Rect(Screen.width*starsData.positionX
			                             + starWidth*i,
			                             Screen.height*starsData.positionY,
			                             starWidth,
			                             starsBG.GetScreenRect().height*starsData.size);
			
			GUI.DrawTexture (starFillRect, star.texture);
			
		}
		// time left text outlie draw
//		screenRect = timeLeftTXT.GetScreenRect ();
//		screenRect.y = Screen.height - (screenRect.y+screenRect.height);
//		DrawOutline(screenRect,timeLeftTXT.text, timeLeftTXT, textStyle,Color.black,timeLeftTXT.color);

		// pause button
		if ( GUI.Button(new Rect(Screen.width*pauseButtonSizes.positionX+pauseButtonSizes.offsetX,
		                        Screen.height*pauseButtonSizes.positionY+pauseButtonSizes.offsetY,
		                        pauseButtonSizes.width,
		                        pauseButtonSizes.height),
		                "",pauseButtonStyle) && !GameManager.instance.GamePaused)
		{
			GameManager.instance.GamePaused = true;
		}

		// restart button
		if( GUI.Button(new Rect(Screen.width*restartButtonSizes.positionX+restartButtonSizes.offsetX,
		                       Screen.height*restartButtonSizes.positionY+restartButtonSizes.offsetY,
		                       restartButtonSizes.width,
		                       restartButtonSizes.height),
		           "",restartButtonStyle) && !GameManager.instance.GamePaused)
		{
			GameManager.instance.GamePaused = false;
			Application.LoadLevel(Application.loadedLevel);
		}

	}

	public static void DrawOutline(Rect position, string text, int fontSize, Font font, GUIStyle style, Color outColor, Color inColor)
	{
		GUIStyle backupStyle = style;// new GUIStyle();
		backupStyle.font = font;
		backupStyle.fontSize = fontSize;
		backupStyle.normal.textColor = outColor;
		//backupStyle.alignment = style.anchor;
		position.x--;
		GUI.Label(position, text, backupStyle);
		position.x +=2;
		GUI.Label(position, text, backupStyle);
		position.x--;
		position.y--;
		GUI.Label(position, text, backupStyle);
		position.y +=2;
		GUI.Label(position, text, backupStyle);
		position.y--;
		backupStyle.normal.textColor = inColor;
		GUI.Label(position, text, backupStyle);
		//style = backupStyle;
	}
	// static method for drawing outline around text
	public static void DrawOutline(Rect position, string text, GUIText textref, GUIStyle style, Color outColor, Color inColor)
	{
		DrawOutline(position, text, textref.fontSize, textref.font, style, outColor, inColor);
	}
	
}
