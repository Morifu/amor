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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		GUI.depth = -1;
		// first draw bg texture
		Rect rectu = new Rect (0, 0, Screen.width, Screen.height);
		GUI.DrawTexture (rectu, background);


	}
}
