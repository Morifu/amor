﻿using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {
	public string level;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("l")) {
			Application.LoadLevel(level);

		}
	}
}
