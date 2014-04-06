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
			GameManager.Instance().GamePaused = !GameManager.Instance().GamePaused;
		}
		
		if (GameManager.Instance().GamePaused) 
		{
			Time.timeScale = 0.0f;
		}
		else 
		{
			Time.timeScale = TS;
		}			
	}

}
