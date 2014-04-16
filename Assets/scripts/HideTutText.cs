using UnityEngine;
using System.Collections;

public class HideTutText : MonoBehaviour {
	public int clickToHide=3;
	bool travelNow = false;
	int clickLeft;
	int fpsToHide;
	// Use this for initialization
	void Start () {
		clickLeft=0;
		//fpsToHide=timeToHide*60;

	}
	

	void Update () {
		if (travelNow == true) {
			clickLeft++;
			travelNow = false;
			if (clickToHide <= clickLeft)
				Destroy (gameObject);


		}
		
	}
	
	void OnMouseDown() {
		travelNow=true;
		
	}
}
