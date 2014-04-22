using UnityEngine;
using System.Collections;

public class HideTutText : MonoBehaviour {
	public float timeToleft = 10f;
	float timeStart;
	public int clickToHide=3;
	bool travelNow = false;
	public int clickLeft;
	int fpsToHide;
	// Use this for initialization
	void Start () {
		clickLeft=0;
		timeStart=Time.time;
		//fpsToHide=timeToHide*60;

	}
	

	void Update () {
		if (Time.time >= timeStart+timeToleft) 
			Destroy (gameObject);
		/*if (travelNow == true) {
			clickLeft++;
			travelNow = false;
			if (clickToHide <= clickLeft)
				Destroy (gameObject);


		}*/
		
	}
	/*
	void OnMouseDown() {
		travelNow=true;
		
	}
	*/
}
