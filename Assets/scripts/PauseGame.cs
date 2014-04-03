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
	void Update () {
		if (Input.GetKeyDown("p")) { 
			if (!pause) {
				pause = true;
			}
			else {
				pause = false;
			}
		}
		
		if (pause) {
			if (Time.timeScale > 0.0f) {
				Time.timeScale = 0.0f;
			//zatrzymanie dzwieku audio.pouse();
			}
		}
			else {
				if (Time.timeScale < TS) {
				Time.timeScale = TS;
				//zatrzymanie dzwieku audio.play();
			}			
		}
	}
	void OnMouseDown() {
		if (!pause) {
			pause = true;
			}
			else {
			pause = false;
			}
		}
		

}
