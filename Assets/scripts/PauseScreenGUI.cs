using UnityEngine;
using System.Collections;

public class PauseScreenGUI : MonoBehaviour {
	
	// texture with background style
	public Texture2D pauseBG;

	public GUIStyle textStyle;

	// gui button styles
	public GUIStyle backButtonStyle;
	public GUIManager.ButtonData backButtonSizes;
	
	public GUIStyle repeatButtonStyle;
	public GUIManager.ButtonData repeatButtonSizes;
	
	public GUIStyle soundButtonStyle;
	public GUIManager.ButtonData soundButtonSizes;
	
	public GUIStyle homeButtonStyle;
	public GUIManager.ButtonData homeButtonSizes;

	public GUIManager.TextData star1Text;
	public GUIManager.TextData star2Text;
	public GUIManager.TextData star3Text;

	public GUIManager.TextData manDetailText;
	public GUIManager.TextData womanDetailText;

	public Sprite mainTargetWoman;
	public GUIManager.ButtonData womanPosition;

	public Sprite mainTargetMan;
	public GUIManager.ButtonData manPosition;

	public bool haveExtraPair = false;

	public Sprite extraPairBG;
	public GUIManager.ButtonData eextraPairBgPosition;

	public Sprite extraTargetWoman;
	public GUIManager.ButtonData extraWomanPosition;
	
	public Sprite extraTargetMan;
	public GUIManager.ButtonData extraManPosition;

	// Use this for initialization
	void Start () {
		if(AudioListener.pause)
		{
			GUIStyleState temp = new GUIStyleState();
			temp.background = soundButtonStyle.normal.background;
			soundButtonStyle.normal.background = soundButtonStyle.active.background;
			soundButtonStyle.active.background = temp.background;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.depth = -1;
		// if game paused, draw pause screen
		if(GameManager.instance.GamePaused)
		{

			// first draw bg texture
			Rect rectu = new Rect (0, 0, Screen.width, Screen.height);
			GUI.DrawTexture (rectu, pauseBG);

			//draw womans portrait
			GUI.DrawTexture ( new Rect (Screen.width*womanPosition.positionX,
			                            Screen.height*womanPosition.positionY,
			                            womanPosition.width,
			                            womanPosition.height), 
			                 mainTargetWoman.texture);

			//draw mans portrait
			GUI.DrawTexture ( new Rect (Screen.width*manPosition.positionX,
			                            Screen.height*manPosition.positionY,
			                            manPosition.width,
			                            manPosition.height), 
			                 mainTargetMan.texture);

			// draw stars
			string startemp = star1Text.text;
			startemp += " "+GameManager.instance.controller.lvlInfo.star2Count;
			// draw level star 1 text
			GUIManager.DrawOutline (new Rect (Screen.width*star1Text.positionX,
			                                  Screen.height*star1Text.positionY,
			                                  star1Text.width,
			                                  star1Text.height), 
			                        startemp, 
			                        star1Text.guiTextReference, 
			                        textStyle , Color.black, 
			                        star1Text.guiTextReference.color);

			startemp = star2Text.text;
			startemp += " "+GameManager.instance.controller.lvlInfo.star2Count;
			// draw level star 2 text
			GUIManager.DrawOutline (new Rect (Screen.width*star2Text.positionX,
			                                  Screen.height*star2Text.positionY,
			                                  star2Text.width,
			                                  star2Text.height), 
			                        startemp, 
			                        star2Text.guiTextReference, 
			                        textStyle , Color.black, 
			                        star2Text.guiTextReference.color);

			startemp = star3Text.text;
			startemp += " "+GameManager.instance.controller.lvlInfo.star3Count;
			// draw level star 3 text
			GUIManager.DrawOutline (new Rect (Screen.width*star3Text.positionX,
			                                  Screen.height*star3Text.positionY,
			                                  star3Text.width,
			                                  star3Text.height), 
			                        startemp, 
			                        star3Text.guiTextReference, 
			                        textStyle , Color.black,
			                        star3Text.guiTextReference.color);

			GUIManager.DrawOutline (new Rect (Screen.width*manDetailText.positionX,
			                                  Screen.height*manDetailText.positionY,
			                                  manDetailText.width,
			                                  manDetailText.height), 
			                        manDetailText.text, 
			                        manDetailText.guiTextReference, 
			                        textStyle , Color.black,
			                        manDetailText.guiTextReference.color);

			GUIManager.DrawOutline (new Rect (Screen.width*womanDetailText.positionX,
			                                  Screen.height*womanDetailText.positionY,
			                                  womanDetailText.width,
			                                  womanDetailText.height), 
			                        womanDetailText.text, 
			                        womanDetailText.guiTextReference, 
			                        textStyle , Color.black,
			                        womanDetailText.guiTextReference.color);
			
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
				AudioListener.pause = !AudioListener.pause;
				// switch backgrounds so button looks like switch
				GUIStyleState temp = new GUIStyleState();
				temp.background = soundButtonStyle.normal.background;
				soundButtonStyle.normal.background = soundButtonStyle.active.background;
				soundButtonStyle.active.background = temp.background;

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


			
			if(haveExtraPair)
			{
				GUI.DrawTexture ( new Rect (Screen.width*eextraPairBgPosition.positionX,
				                            Screen.height*eextraPairBgPosition.positionY,
				                            eextraPairBgPosition.width,
				                            eextraPairBgPosition.height), 
				                 extraPairBG.texture);
				
				//draw womans portrait
				GUI.DrawTexture ( new Rect (Screen.width*extraWomanPosition.positionX,
				                            Screen.height*extraWomanPosition.positionY,
				                            extraWomanPosition.width,
				                            extraWomanPosition.height), 
				                 extraTargetWoman.texture);
				
				//draw mans portrait
				GUI.DrawTexture ( new Rect (Screen.width*extraManPosition.positionX,
				                            Screen.height*extraManPosition.positionY,
				                            extraManPosition.width,
				                            extraManPosition.height), 
				                 extraTargetMan.texture);
			}
		}
	}
}
