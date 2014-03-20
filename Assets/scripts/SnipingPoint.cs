using UnityEngine;
using System.Collections;

public class SnipingPoint : MonoBehaviour {

	public bool startingPoint;
	public Transform player;

	// Use this for initialization
	void Start () {
	}


	void OnMouseUp() 
	{
		Debug.Log ("OnMouseup mouse!");
		if(player != null)
		player.position = transform.position;
	}
}
