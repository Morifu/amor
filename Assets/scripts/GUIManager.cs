using UnityEngine;
using System.Collections;

public class GUIManager: MonoBehaviour {

	static GUIManager instance;
	public Texture2D pauseButtonActive;
	public Texture2D pauseButtonNormal;

	GUIText arrowCountTXT;
	
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
		arrowCountTXT = GameObject.Find("ArrowCountTXT").GetComponent<GUIText> ();
	}

	void Update()
	{
		if(arrowCountTXT != null)
			arrowCountTXT.text = string.Format("x{0}", GameManager.Instance ().arrowCount);
	}

	void OnGUI() {
		GUIStyle style = new GUIStyle ();
		style.active.background = pauseButtonActive;
		style.normal.background = pauseButtonNormal;
		if (GUI.Button(new Rect(580, 10, 50, 50), "",style))
		{
			GameManager.Instance().GamePaused = !GameManager.Instance().GamePaused;
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
