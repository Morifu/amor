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
		//arrowCountTXT = GameObject.Find("ArrowCountTXT").GetComponent<GUIText> ();
	}

	void Update()
	{
		if(arrowCountTXT != null)
		{
			arrowCountTXT.text = string.Format("x{0:d}", GameManager.instance.controller.arrowCount);

		}
		if (timeLeftTXT != null)
		{
			int seconds = (int)(Time.time - GameManager.instance.controller.time);
			int minutes = (int)(seconds/60);

			timeLeftTXT.text = string.Format("Time: {0:d2}:{1:d2}", minutes, seconds%60);
		}
	}

	void OnGUI() {

		// lets draw outline on all texts
		// outline for arrow count text
		Rect screenRect = arrowCountTXT.GetScreenRect ();
		screenRect.y = Screen.height - (screenRect.y+screenRect.height);
		DrawOutline(screenRect,arrowCountTXT.text, arrowCountTXT,Color.black,Color.white);

		// time left text outlie draw
		screenRect = timeLeftTXT.GetScreenRect ();
		screenRect.y = Screen.height - (screenRect.y+screenRect.height);
		DrawOutline(screenRect,timeLeftTXT.text, timeLeftTXT,Color.black,Color.white);

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
	// static method for drawing outline around text
	public static void DrawOutline(Rect position, string text, GUIText style, Color outColor, Color inColor){
		GUIStyle backupStyle = new GUIStyle();
		backupStyle.font = style.font;
		backupStyle.fontSize = style.fontSize;
		backupStyle.normal.textColor = Color.black;
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
		backupStyle.normal.textColor = Color.white;
		GUI.Label(position, text, backupStyle);
		//style = backupStyle;
	}
	
}
