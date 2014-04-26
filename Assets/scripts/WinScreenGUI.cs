using UnityEngine;
using System.Collections;

public class WinScreenGUI : MonoBehaviour {
	// texture with background style
	public Texture2D background;

	public GUIStyle repeatButtonStyle;
	public GUIManager.ButtonData repeatButtonSizes;
	
	public GUIStyle homeButtonStyle;
	public GUIManager.ButtonData homeButtonSizes;
	
	public GUIStyle nextButtonStyle;
	public GUIManager.ButtonData nextButtonSizes;

	public GUIManager.TextData LevelCompletedText;
	public GUIManager.TextData bestTimeText;
	public GUIManager.TextData scoreText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		if (!GameManager.instance.controller.levelCompleted)
						return;
		GUI.depth = -1;
		// first draw bg texture
		Rect rectu = new Rect (0, 0, Screen.width, Screen.height);
		GUI.DrawTexture (rectu, background);

//		GUI.TextArea (new Rect (LevelCompletedPosition.positionX,
//		                      LevelCompletedPosition.positionY,
//		                      LevelCompletedPosition.width,
//		                      LevelCompletedPosition.height), LevelCompletedTXT.text);

		GUIManager.DrawOutline (new Rect (Screen.width*LevelCompletedText.positionX,
		                                  Screen.height*LevelCompletedText.positionY,
		                                  LevelCompletedText.width,
		                                  LevelCompletedText.height), LevelCompletedText.text, LevelCompletedText.font,
		                        LevelCompletedText.fontSize , Color.black, Color.white);

		GUIManager.DrawOutline (new Rect (Screen.width*bestTimeText.positionX,
		                                  Screen.height*bestTimeText.positionY,
		                                  bestTimeText.width,
		                                  bestTimeText.height), bestTimeText.text, bestTimeText.font,
		                        bestTimeText.fontSize , Color.black, Color.white);

		GUIManager.DrawOutline (new Rect (Screen.width*scoreText.positionX,
		                                  Screen.height*scoreText.positionY,
		                                  scoreText.width,
		                                  scoreText.height), scoreText.text, scoreText.font,
		                        scoreText.fontSize , Color.black, Color.white);

		// back button on screen
		if(GUI.Button(new Rect(Screen.width*homeButtonSizes.positionX+homeButtonSizes.offsetX,
		                       Screen.height*homeButtonSizes.positionY+homeButtonSizes.offsetY,
		                       homeButtonSizes.width,
		                       homeButtonSizes.height),
		              "",homeButtonStyle))
		{
			Application.LoadLevel("selectLevel");
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
		if(GUI.Button(new Rect(Screen.width*nextButtonSizes.positionX+nextButtonSizes.offsetX,
		                       Screen.height*nextButtonSizes.positionY+nextButtonSizes.offsetY,
		                       nextButtonSizes.width,
		                       nextButtonSizes.height),
		              "",nextButtonStyle))
		{
			
		}
	}
}
