using UnityEngine;
using System.Collections;

public class intro : MonoBehaviour {
	float timeStart;
	public float timeToWait;
	public string MoveTo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= timeStart+timeToWait)
			Application.LoadLevel(MoveTo); //
		else {
			if (Input.GetKey(KeyCode.Space)) { 
				Application.LoadLevel(MoveTo);
			}
		}

	}
}
