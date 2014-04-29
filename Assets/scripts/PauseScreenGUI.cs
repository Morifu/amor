using UnityEngine;
using System.Collections;

public class PauseScreenGUI : MonoBehaviour {
	
	// texture with background style
	public Texture2D pauseBG;

	// gui button styles
	public GUIStyle backButtonStyle;
	public GUIManager.ButtonData backButtonSizes;
	
	public GUIStyle repeatButtonStyle;
	public GUIManager.ButtonData repeatButtonSizes;
	
	public GUIStyle soundButtonStyle;
	public GUIManager.ButtonData soundButtonSizes;
	
	public GUIStyle homeButtonStyle;
	public GUIManager.ButtonData homeButtonSizes;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		// if game paused, draw pause screen
		if(GameManager.instance.GamePaused)
		{
			
			// first draw bg texture
			Rect rectu = new Rect (0, 0, Screen.width, Screen.height);
			GUI.DrawTexture (rectu, pauseBG);
			
			// back button on screen
			if(GUI.Button(new Rect(Screen.width*backButtonSizes.positionX+backButtonSizes.offsetX,
			                       Screen.height*backButtonSizes.positionY+backButtonSizes.offsetY,
			                       backButtonSizes.width,
			                       backButtonSizes.height),
			              "",backButtonStyle))
			{
				GameManager.instance.GamePaused = !GameManager.instance.GamePaused;
			}
			// repeat button on screen
			if(GUI.Button(new Rect(Screen.width*repeatButtonSizes.positionX+repeatButtonSizes.offsetX,
			                       Screen.height*repeatButtonSizes.positionY+repeatButtonSizes.offsetY,
			                       repeatButtonSizes.width,
			                       repeatButtonSizes.height),
			              "",repeatButtonStyle))
			{
				GameManager.instance.GamePaused = false;
				Application.LoadLevel(Application.loadedLevel);
			}
			// sound button on screen
			if(GUI.Button(new Rect(Screen.width*soundButtonSizes.positionX+soundButtonSizes.offsetX,
			                       Screen.height*soundButtonSizes.positionY+soundButtonSizes.offsetY,
			                       soundButtonSizes.width,
			                       soundButtonSizes.height),
			              "",soundButtonStyle))
			{
				
			}
			// home button on screen
			if(GUI.Button(new Rect(Screen.width*homeButtonSizes.positionX+homeButtonSizes.offsetX,
			                       Screen.height*homeButtonSizes.positionY+homeButtonSizes.offsetY,
			                       homeButtonSizes.width,
			                       homeButtonSizes.height),
			              "",homeButtonStyle))
			{
				GameManager.instance.GamePaused = false;
				Application.LoadLevel("selectLevel");
			}
		}
	}
}
