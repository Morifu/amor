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
		public Font font;
		public int fontSize;
		[HideInInspector]
		public float width = 80;
		[HideInInspector]
		public float height = 80;
		public float positionX = 0;
		public float positionY = 0;
	}

	// singleton, dont know what for for now
	[HideInInspector]
	public static GUIManager instance;

	// gui button styles
	public GUIStyle pauseButtonStyle;
	public ButtonData pauseButtonSizes;

	public GUIStyle backButtonStyle;
	public ButtonData backButtonSizes;

	public GUIStyle repeatButtonStyle;
	public ButtonData repeatButtonSizes;

	public GUIStyle soundButtonStyle;
	public ButtonData soundButtonSizes;

	public GUIStyle homeButtonStyle;
	public ButtonData homeButtonSizes;

	public GUIContent buttonContent;

	// texture with background style
	public Texture2D pauseBG;

	// pause button sizes and offset

	// references for gui texts
	public GUIText arrowCountTXT;
	public GUIText timeLeftTXT;
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

	void OnEnable() {
		Debug.Log ("script was enabled");
	}
	
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

		if (timeLeftTXT != null)
		{
			int seconds = (int)(Time.time - GameManager.instance.controller.time);
			int minutes = (int)(seconds/60);

			timeLeftTXT.text = string.Format("Time: {0:d2}:{1:d2}", minutes, seconds%60);
		}

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
		DrawOutline(screenRect,arrowCountTXT.text, arrowCountTXT,Color.black,arrowCountTXT.color);

		if(!hideLevelNumber)
		{
			// outline for LevelNumberTXT text
			screenRect = LevelNumberTXT.GetScreenRect ();
			screenRect.y = Screen.height - (screenRect.y+screenRect.height);
			DrawOutline(screenRect,LevelNumberTXT.text, LevelNumberTXT,Color.black,LevelNumberTXT.color);
		}
		// time left text outlie draw
		screenRect = timeLeftTXT.GetScreenRect ();
		screenRect.y = Screen.height - (screenRect.y+screenRect.height);
		DrawOutline(screenRect,timeLeftTXT.text, timeLeftTXT,Color.black,timeLeftTXT.color);

		// pause button
		if (GUI.Button(new Rect(Screen.width-pauseButtonSizes.width-pauseButtonSizes.offsetX,
		                        pauseButtonSizes.offsetY,
		                        pauseButtonSizes.width,
		                        pauseButtonSizes.height),
		               	"",pauseButtonStyle))
		{
			if(!GameManager.instance.GamePaused)
			GameManager.instance.GamePaused = true;

		}

		// if game paused, draw pause screen
		if(GameManager.instance.GamePaused)
		{

			// first draw bg texture
			Rect rectu = new Rect (0, 0, Screen.width, Screen.height);
			GUI.DrawTexture (rectu, pauseBG);

			// back button on screen
			if(GUI.Button(new Rect(Screen.width*0.1f+backButtonSizes.offsetX,
			                       Screen.height*0.25f+backButtonSizes.offsetY,
			                       backButtonSizes.width,
			                       backButtonSizes.height),
			              "",backButtonStyle))
			{
				GameManager.instance.GamePaused = !GameManager.instance.GamePaused;
			}
			// repeat button on screen
			if(GUI.Button(new Rect(Screen.width*0.1f+repeatButtonSizes.offsetX,
			                       Screen.height*0.4f+repeatButtonSizes.offsetY,
			                       repeatButtonSizes.width,
			                       repeatButtonSizes.height),
			              "",repeatButtonStyle))
			{
				GameManager.instance.GamePaused = false;
				Application.LoadLevel(Application.loadedLevel);
			}
			// sound button on screen
			if(GUI.Button(new Rect(Screen.width*0.1f+soundButtonSizes.offsetX,
			                       Screen.height*0.55f+soundButtonSizes.offsetY,
			                       soundButtonSizes.width,
			                       soundButtonSizes.height),
			              "",soundButtonStyle))
			{
				
			}
			// home button on screen
			if(GUI.Button(new Rect(Screen.width*0.1f+homeButtonSizes.offsetX,
			                       Screen.height*0.7f+homeButtonSizes.offsetY,
			                       homeButtonSizes.width,
			                       homeButtonSizes.height),
			              "",homeButtonStyle))
			{
				GameManager.instance.GamePaused = false;
				Application.LoadLevel("selectLevel");
			}
		}
	}

	public static void DrawOutline(Rect position, string text,Font font, int fontSize, Color outColor, Color inColor)
	{
		GUIStyle backupStyle = new GUIStyle();
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
	public static void DrawOutline(Rect position, string text, GUIText style, Color outColor, Color inColor)
	{
		DrawOutline(position, text, style.font, style.fontSize, outColor, inColor);
	}
	
}
