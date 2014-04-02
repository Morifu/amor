using UnityEngine;
using System.Collections;

public class PouseGame : MonoBehaviour {
	public float TS;
	public bool pouse;
	

	// Use this for initialization
	void Start () {
	TS = Time.timeScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("p")) { 
			if (!pouse) {
				pouse = true;
			}
			else {
				pouse = false;
			}
		}
		
		if (pouse) {
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
			if (!pouse) {
				pouse = true;
			}
			else {
				pouse = false;
			}
		}
		

}
