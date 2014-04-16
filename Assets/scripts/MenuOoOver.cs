using UnityEngine;
using System.Collections;

public class MenuOoOver : MonoBehaviour {
	public int procent =95;
	float xx;
	float yy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseEnter () {
		xx=transform.localScale.x;
		yy=transform.localScale.y;
		transform.localScale = new Vector2(transform.localScale.x*procent/100, transform.localScale.y*procent/100); ///= 2

	}
	void OnMouseExit () {
		transform.localScale = new Vector2(xx, yy);
	}
}
