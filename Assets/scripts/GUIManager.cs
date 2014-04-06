using UnityEngine;
using System.Collections;

public class GUIManager: MonoBehaviour {

	static GUIManager instance;

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
	
	static public GUIManager Instance()
	{
		if(instance == null)
		{
			instance = new GUIManager();
		} 
		
		return instance;
	}
}
