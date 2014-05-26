using UnityEngine;
using System.Collections;

public class WinScreenGUI : MonoBehaviour {


	// texture with background style
	public Texture2D background;
	public Sprite stars;
	public Sprite star;
	public GUIManager.SpriteData starsData;

	public GUIStyle textStyle;

	public GUIStyle repeatButtonStyle;
	public GUIManager.ButtonData repeatButtonSizes;
	
	public GUIStyle homeButtonStyle;
	public GUIManager.ButtonData homeButtonSizes;
	
	public GUIStyle nextButtonStyle;
	public GUIManager.ButtonData nextButtonSizes;

	public GUIManager.TextData LevelCompletedText;
	public GUIManager.TextData bestTimeText;
	public GUIManager.TextData scoreText;
	public GUIManager.TextData bonusText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		if (!GameManager.instance.controller.levelCompleted) return;
						
		GUI.depth = -1;

		// first draw bg texture
		Rect rectu = new Rect (0, 0, Screen.width, Screen.height);
		GUI.DrawTexture (rectu, background);

		// draw stars collected
		Rect starsRect = new Rect (Screen.width*starsData.positionX,
		                           Screen.height*starsData.positionY,
		                           stars.rect.width*starsData.size,
		                           stars.rect.height*starsData.size);
		GUI.DrawTexture (starsRect, stars.texture);

		for (int i = 0; i < GameManager.instance.controller.starsCount; i++)
		{
			float starWidth = star.rect.width*((star.rect.height/stars.rect.height)*starsData.size)*0.9f;
			Rect starFillRect = new Rect(Screen.width*starsData.positionX
			                             + starWidth*i,
			                             Screen.height*starsData.positionY,
			                             starWidth,
			                             stars.rect.height*starsData.size);

			GUI.DrawTexture (starFillRect, star.texture);
		}

		// draw level completed text
		GUIManager.DrawOutline (new Rect (Screen.width*LevelCompletedText.positionX,
		                                  Screen.height*LevelCompletedText.positionY,
		                                  LevelCompletedText.width,
		                                  LevelCompletedText.height),
		                        LevelCompletedText.text, 
		                        LevelCompletedText.guiTextReference, 
		                        textStyle , Color.black, 
		                        LevelCompletedText.guiTextReference.color);

		// draw best time 
		int seconds = (int)(GameManager.instance.controller.time);
		int minutes = (int)(seconds/60);
		
		string textbesttime = string.Format(bestTimeText.text+" {0:d2}:{1:d2}", minutes, seconds%60);

		GUIManager.DrawOutline (new Rect (Screen.width*bestTimeText.positionX,
		                                  Screen.height*bestTimeText.positionY,
		                                  bestTimeText.width,
		                                  bestTimeText.height),
		                        textbesttime,
		                        bestTimeText.guiTextReference, 
		                        textStyle , Color.black, 
		                        bestTimeText.guiTextReference.color);

		// draw bonus colleted string
		string temp1 = (GameManager.instance.controller.bonusCollected) ? (" collected!") : (" none");
		string textbonus = string.Format(bonusText.text+temp1);

		GUIManager.DrawOutline (new Rect (Screen.width*bonusText.positionX,
		                                  Screen.height*bonusText.positionY,
		                                  bonusText.width,
		                                  bonusText.height), 
		                        textbonus, 
		                        bonusText.guiTextReference, 
		                        textStyle , Color.black, 
		                        bonusText.guiTextReference.color);

		string textScoreCount = string.Format(scoreText.text+"\n{0}", 
		                                      GameManager.instance.controller.scoreCount);
		TextAnchor tempAnchor = textStyle.alignment;
		textStyle.alignment = TextAnchor.UpperCenter;
		GUIManager.DrawOutline (new Rect (Screen.width*scoreText.positionX,
		                                  Screen.height*scoreText.positionY,
		                                  scoreText.width,
		                                  scoreText.height),
		                        textScoreCount, 
		                        scoreText.guiTextReference, 
		                        textStyle , Color.black, 
		                        scoreText.guiTextReference.color);
		textStyle.alignment = tempAnchor;

		// back button 
		if(GUI.Button(new Rect(Screen.width*homeButtonSizes.positionX+homeButtonSizes.offsetX,
		                       Screen.height*homeButtonSizes.positionY+homeButtonSizes.offsetY,
		                       homeButtonSizes.width,
		                       homeButtonSizes.height),
		              "",homeButtonStyle))
		{
			Application.LoadLevel("selectLevel");
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
		// next level button 
		if(GUI.Button(new Rect(Screen.width*nextButtonSizes.positionX+nextButtonSizes.offsetX,
		                       Screen.height*nextButtonSizes.positionY+nextButtonSizes.offsetY,
		                       nextButtonSizes.width,
		                       nextButtonSizes.height),
		              "",nextButtonStyle))
		{
			if(GameManager.instance.controller.nextLevel == 13)
				Application.LoadLevel("outro");
			else
				Application.LoadLevel("lv"+GameManager.instance.controller.nextLevel);
		}
	}
}
