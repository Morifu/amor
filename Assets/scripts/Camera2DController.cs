using UnityEngine;
using System.Collections;

public class Camera2DController : MonoBehaviour {
	
	public float minZoom = 1f;
	float maxZoom = 10f;
	public float sensitivity = 1f;

	Vector2 startingPos;
	Vector3 dragOrigin;
	Rect boundingBox;

	public RaycastHit2D hit;

	public LayerMask whatToHit;

	// Use this for initialization
	void Start () 
	{
		GameObject cameraBounds = GameObject.Find ("CameraBounds");
		BoxCollider2D boundBoxColl = cameraBounds.GetComponent<BoxCollider2D> ();

		boundingBox = new Rect (boundBoxColl.center.x - boundBoxColl.size.x / 2, boundBoxColl.center.y + boundBoxColl.size.y / 2,
		                        boundBoxColl.size.x, boundBoxColl.size.y);
		maxZoom = boundingBox.height / 2;
	}
	
	// Update is called once per frame
	void Update () 
	{

		bool canDrag = false;
		if ( Input.GetMouseButtonDown(0))
		{
			//Debug.Log("Mouse position: "+Input.mousePosition);
			dragOrigin = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10);
			dragOrigin = Camera.main.ScreenToWorldPoint(dragOrigin);

			hit = Physics2D.Raycast(dragOrigin, Vector2.zero,10,whatToHit);
		}
		if(hit.collider == null)
			canDrag = true;

		if (canDrag && Input.GetMouseButton (0))
		{
			Vector3 currentPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10);
			currentPos = Camera.main.ScreenToWorldPoint (currentPos);
			Vector3 movePos = dragOrigin - currentPos;
			//Debug.Log ("Move Pos: "+movePos);
			transform.position += movePos;
		} else
		{
			float size = Camera.main.orthographicSize;
			size += Input.GetAxis ("Mouse ScrollWheel") * sensitivity;
			size = Mathf.Clamp (size, minZoom, maxZoom);
			Camera.main.orthographicSize = size;
		}
		CheckBounds();
	}

	void CheckBounds()
	{
		Vector3 pos = transform.position;
		float sizeY = Camera.main.orthographicSize; // orthographic size is its height/2 as height is usually smaller, width is defined by aspect ratio
		float sizeX = (2*sizeY) * 4 / 3;
		float minX, maxX, minY, maxY;
		minX = boundingBox.xMin + sizeX/2;
		maxX = boundingBox.xMax - sizeX/2;
		minY = (boundingBox.yMin-boundingBox.height) + sizeY;
		maxY = boundingBox.yMin - sizeY;

		pos.x = Mathf.Clamp (pos.x, minX, maxX);
		pos.y = Mathf.Clamp (pos.y, minY, maxY);

		transform.position = pos;
		Debug.Log ("position: " + pos);
		sizeY = Mathf.Clamp (sizeY, minZoom, maxZoom);
		Camera.main.orthographicSize = sizeY;

	}
}
