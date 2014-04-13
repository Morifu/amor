using UnityEngine;
using System.Collections;

public class GUIManager: MonoBehaviour {

	static GUIManager instance;
	public Texture2D pauseButtonActive;
	public Texture2D pauseButtonNormal;
	public GUIStyle windowStyle;


	public float posX = 510;
	public float posY = 10;
	public float width = 50;
	public float height = 50;

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
			arrowCountTXT.text = string.Format("x{0:d}", GameManager.instance.controller.arrowCount);
		if (timeLeftTXT != null)
		{
			int seconds = (int)(Time.time - GameManager.instance.controller.time);
			int minutes = (int)(seconds/60);

			timeLeftTXT.text = string.Format("Time: {0:d2}:{1:d2}", minutes, seconds);
		}
	}

	void OnGUI() {
		GUIStyle style = new GUIStyle ();
		style.active.background = pauseButtonActive;
		style.normal.background = pauseButtonNormal;
		if (GUI.Button(new Rect(posX, posY, width, height), "",style))
		{
			GameManager.instance.GamePaused = !GameManager.instance.GamePaused;
		}
		
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
