﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Bow weapon; // reference to bow of player

	Vector2 startingPos;
	Vector2 endingPos;

	bool flippedCharacter = false; // if we should flip the player

	// Use this for initialization
	void Start () {
		weapon = transform.FindChild ("Bow").GetComponent<Bow> ();
	}

	void OnMouseDown() 
	{
		Debug.Log ("Mouse Position: " + Input.mousePosition);
		Vector3 v3 = Input.mousePosition;
		v3.z = 10;
		Vector3 pos = Camera.main.ScreenToWorldPoint (v3);
		startingPos = new Vector2 (pos.x, pos.y);
		Debug.Log ("Starting Position x: " + pos.x + " y: " + pos.y);
	}

	void OnMouseDrag() 
	{
		//Debug.Log ("Dragging mouse!");
		Vector3 v3 = Input.mousePosition;
		v3.z = 10;
		Vector3 pos = Camera.main.ScreenToWorldPoint (v3);
		Debug.DrawLine (startingPos, new Vector2(pos.x,pos.y));

		int sign = (int)(startingPos - new Vector2(pos.x,pos.y)).x;
		if (sign < 0 && !flippedCharacter) 
		{
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
			flippedCharacter = true;
		}
		else if (sign > 0 && flippedCharacter)
		{
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
			flippedCharacter = false;
		}
	}

	void OnMouseUp () 
	{
		Debug.Log ("Clicked!");
		Debug.Log ("Mouse Position: " + Input.mousePosition);
		Vector3 v3 = Input.mousePosition;
		v3.z = 10;
		Vector3 pos = Camera.main.ScreenToWorldPoint (v3);
		endingPos = new Vector2 (pos.x, pos.y);
		Debug.Log ("Ending Position x: " + pos.x + " y: " + pos.y);
		weapon.shootArrow (startingPos-endingPos);
	}
}