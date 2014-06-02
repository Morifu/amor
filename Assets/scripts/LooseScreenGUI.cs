using UnityEngine;
using System.Collections;

public class LooseScreenGUI : MonoBehaviour {

	// texture with background style
	public Texture2D background;
	
	public GUIStyle textStyle;
	
	public GUIStyle repeatButtonStyle;
	public GUIManager.ButtonData repeatButtonSizes;
	
	public GUIStyle homeButtonStyle;
	public GUIManager.ButtonData homeButtonSizes;
	
//	public GUIStyle nextButtonStyle;
//	public GUIManager.ButtonData nextButtonSizes;
	
	public GUIManager.TextData LevelLoseText;
	public GUIManager.TextData againText;


	void OnGUI() {
		
		if (!GameManager.instance.controller.levelFailed) return;
		
		GUI.depth = -1;
		
		// first draw bg texture
		Rect rectu = new Rect (0, 0, Screen.width, Screen.height);
		GUI.DrawTexture (rectu, background);

		// draw level completed text
		GUIManager.DrawOutline (new Rect (Screen.width*LevelLoseText.positionX,
		                                  Screen.height*LevelLoseText.positionY,
		                                  LevelLoseText.width,
		                                  LevelLoseText.height), LevelLoseText.text,
		                        LevelLoseText.guiTextReference, textStyle , Color.black, Color.white);

		// draw again text
		GUIManager.DrawOutline (new Rect (Screen.width*againText.positionX,
		                                  Screen.height*againText.positionY,
		                                  againText.width,
		                                  againText.height), againText.text,
		                        againText.guiTextReference, textStyle , Color.black, Color.white);
		
		// back button 
		if(GUI.Button(new Rect(Screen.width*homeButtonSizes.positionX+homeButtonSizes.offsetX,
		                       Screen.height*homeButtonSizes.positionY+homeButtonSizes.offsetY,
		                       homeButtonSizes.width,
		                       homeButtonSizes.height),
		              "",homeButtonStyle))
		{
			Application.LoadLevel("mainMenu");
		}
		// repeat button 
		if(GUI.Button(new Rect(Screen.width*repeatButtonSizes.positionX+repeatButtonSizes.offsetX,
		                       Screen.height*repeatButtonSizes.positionY+repeatButtonSizes.offsetY,
		                       repeatButtonSizes.width,
		                       repeatButtonSizes.height),
		              "",repeatButtonStyle))
		{
			GameManager.instance.GamePaused = false;
			Application.LoadLevel(Application.loadedLevel);
		}
//		// next button 
//		if(GUI.Button(new Rect(Screen.width*nextButtonSizes.positionX+nextButtonSizes.offsetX,
//		                       Screen.height*nextButtonSizes.positionY+nextButtonSizes.offsetY,
//		                       nextButtonSizes.width,
//		                       nextButtonSizes.height),
//		              "",nextButtonStyle))
//		{
//			
//		}
	}
}
