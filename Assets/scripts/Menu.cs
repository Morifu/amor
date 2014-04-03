using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public string where;
	bool travelNow = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (travelNow == true) {
			travelNow = false;
			Application.LoadLevel(where);
		}

	
	}

	void OnMouseDown() {
		travelNow=true;

	}
}
