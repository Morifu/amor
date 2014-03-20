using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Bow weapon; // reference to bow of player

	// Use this for initialization
	void Start () {
		weapon = transform.FindChild ("Bow").GetComponent<Bow> ();
	}
	
	void OnMouseDrag() 
	{
		Debug.Log ("Dragging mouse!");
	}

	void OnMouseUp () 
	{
		Debug.Log ("Clicked!");
		weapon.shootArrow ();
	}
}
