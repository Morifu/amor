using UnityEngine;
using System.Collections;

public class intro : MonoBehaviour {
	float timeStart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= timeStart+1)
			Application.LoadLevel("lv1"); //
	
	}
}
