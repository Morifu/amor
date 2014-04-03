using UnityEngine;
using System.Collections;

public class MusicGenerator : MonoBehaviour {
	public GameObject music;
	
	// Use this for initialization
	void Start () {
	GameObject G = GameObject.FindGameObjectWithTag("Respawn");
		if (!G) {
			Instantiate(music, new Vector3(0, 0, 0), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
