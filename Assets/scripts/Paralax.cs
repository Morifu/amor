using UnityEngine;
using System.Collections;

public class Paralax : MonoBehaviour {
	public Transform camer;
	public float movingXpower=0.15f;
	float moving;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		moving = camer.position.x * movingXpower;
		transform.position = new Vector3(-moving, transform.position.y, transform.position.z);
		
	}
}
