using UnityEngine;
using System.Collections;

public class GUIManager: MonoBehaviour {

	static GUIManager instance;
	public GUIStyle pauseButtonStyle;
	public Texture2D pauseBG;

	public float width = 80;
	public float height = 80;
	public float offset = 10;

	public GUIText arrowCountTXT;
	public GUIText timeLeftTXT;
	
	// Use this for initialization
	void Awake () {
		if(instance == null)
		{
			DontDestroyOnLoad (gameObject);
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
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
		Rect screenRect = arrowCountTXT.GetScreenRect ();
		screenRect.y = Screen.height - (screenRect.y+screenRect.height);
		DrawOutline(screenRect,arrowCountTXT.text, arrowCountTXT,Color.black,Color.white);

		// time left text outlie draw
		screenRect = timeLeftTXT.GetScreenRect ();
		screenRect.y = Screen.height - (screenRect.y+screenRect.height);
		DrawOutline(screenRect,timeLeftTXT.text, timeLeftTXT,Color.black,Color.white);

		// pause button
		if (GUI.Button(new Rect(Screen.width-width-offset, offset, width, height), "",pauseButtonStyle))
		{
			GameManager.instance.GamePaused = !GameManager.instance.GamePaused;
		}
		if(GameManager.instance.GamePaused)
		{
			Rect rectu = new Rect (0, 0, Screen.width, Screen.height);
			GUI.DrawTexture (rectu, pauseBG);
		}
	}

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

	static public GUIManager Instance()
	{
		if(instance == null)
		{
			instance = new GUIManager();
		} 
		
		return instance;
	}
}
