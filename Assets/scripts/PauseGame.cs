using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

	public float TS;
	public bool pause;

	// Use this for initialization
	void Start () {
		TS = Time.timeScale;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("p")) 
		{ 
			GameManager.instance.GamePaused = !GameManager.instance.GamePaused;
		}
		
		if (GameManager.instance.GamePaused) 
		{
			Time.timeScale = 0.0f;
		}
		else 
		{
			Time.timeScale = TS;
		}			
	}

}
