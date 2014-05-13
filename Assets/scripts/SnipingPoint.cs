using UnityEngine;
using System.Collections;

public class SnipingPoint : MonoBehaviour {

	public bool startingPoint;
	GameObject player; 
	Transform spawnPoint;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Amor");

		if (startingPoint && player != null)
			player.transform.position = transform.position;
	}

	void OnMouseUp() 
	{
		if(GameManager.instance.GamePaused || 
		   GameManager.instance.controller.levelCompleted ||
		   GameManager.instance.controller.levelFailed) return;
		Debug.Log ("OnMouseup mouse!");
		if(player != null)
			player.transform.position = transform.position;
	}
}
