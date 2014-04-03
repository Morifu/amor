using UnityEngine;
using System.Collections;

public class AudioOnOff : MonoBehaviour {
	public bool AudioOn = true;
	public string button;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (AudioOn == true) {
			//play teh music
			AudioListener.pause = false;
		}
		else if (AudioOn == false) {
			//stop
			AudioListener.pause = true;
		}
	
	}

	void OnMouseDown() {
		if (AudioOn != true)
				AudioOn = true;
		else if (AudioOn != false)
				AudioOn = false;
		}



}
