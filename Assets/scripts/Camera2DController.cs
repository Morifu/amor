using UnityEngine;
using System.Collections;

public class Camera2DController : MonoBehaviour {


	public bool turnOnDrag = false;
	public float minZoom = 1f;
	public float maxZoom = 10f;
	public float sensitivity = 50f;

	Vector2 startingPos;
	Vector3 dragOrigin;

	// Use this for initialization
	void Start () 
	{
		//transform.parent = null;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(turnOnDrag)
		{
			if ( Input.GetMouseButtonDown(0))
			{
				//Debug.Log("Mouse position: "+Input.mousePosition);
				dragOrigin = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10);
				dragOrigin = Camera.main.ScreenToWorldPoint(dragOrigin);
			}
			
			if ( Input.GetMouseButton(0))
			{
				
				Vector3 currentPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10);
				currentPos = Camera.main.ScreenToWorldPoint(currentPos);
				Vector3 movePos = dragOrigin - currentPos;
				//Debug.Log ("Move Pos: "+movePos);
				transform.position += movePos;
			}
		}
		float size = Camera.main.orthographicSize;
		size += Input.GetAxis ("Mouse ScrollWheel") * sensitivity;
		size = Mathf.Clamp (size, (int)minZoom, (int)maxZoom);
		Camera.main.orthographicSize = size;

	}
}
