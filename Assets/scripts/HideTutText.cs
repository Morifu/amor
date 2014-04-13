using UnityEngine;
using System.Collections;

public class HideTutText : MonoBehaviour {
	public int timeToHide;
	int timeLeft;
	int fpsToHide;
	// Use this for initialization
	void Start () {
		timeLeft=0;
		fpsToHide=timeToHide*60;

	}
	
	// Update is called once per frame
	void Update () {
		timeLeft++;
	if (fpsToHide < timeLeft)
			Destroy (gameObject);
	}
}
