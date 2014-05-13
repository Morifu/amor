using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Bow weapon; // reference to bow of player

	Vector2 startingPos;
	Vector2 endingPos;

	Transform upperBody;

	Animator legAnim, bodyAnim;

	bool flippedCharacter = false; // if we should flip the player

	public float maxAngle = 70;
	// Use this for initialization
	void Start () {

		upperBody = transform.FindChild("UpperBody");
		weapon = upperBody.FindChild ("Bow").GetComponent<Bow> ();
		startingPos = new Vector2(transform.position.x,transform.position.y+0.5f);
		bodyAnim = upperBody.GetComponentInChildren<Animator> ();

	}

	void OnMouseDown() 
	{
		if(GameManager.instance.GamePaused || 
		   GameManager.instance.controller.levelCompleted || 
		   GameManager.instance.controller.levelFailed) return;
//		Debug.Log ("Mouse Position: " + Input.mousePosition);
//		Vector3 v3 = Input.mousePosition;
//		v3.z = 10;
//		Vector3 pos = Camera.main.ScreenToWorldPoint (v3);
		//startingPos = new Vector2 (pos.x, pos.y);
		startingPos = new Vector2(transform.position.x,transform.position.y+0.5f);
//		Debug.Log ("Starting Position x: " + pos.x + " y: " + pos.y);
	}

	void OnMouseDrag() 
	{
		//Debug.Log ("Dragging mouse!");
		if(GameManager.instance.GamePaused || 
		   GameManager.instance.controller.levelCompleted || 
		   GameManager.instance.controller.levelFailed) return;

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
		Vector2 v2 = startingPos - new Vector2 (pos.x, pos.y);
		Quaternion rot = Quaternion.LookRotation (v2);
		//Debug.Log ("magnitude : " + v2.magnitude);
		bodyAnim.SetFloat ("Magnitude", v2.magnitude);
		v2.Normalize ();

		// we don't need rotation on x and y within 2D space
		rot.x = 0;
		rot.y = 0;
		float cosz = Mathf.Cos (rot.eulerAngles.z*Mathf.Deg2Rad); 
		rot.z *= transform.localScale.x;
		//Debug.Log ("Cosinus z : " + cosz+" Cosinus 70 : "+maxAngle + "rotz: "+rot.eulerAngles.z);
		if(cosz > Mathf.Cos (maxAngle*Mathf.Deg2Rad))
			upperBody.rotation = rot;

		// here will be code for arrow trajectory
		// ------
	}

	void OnMouseOver() {

	}

	void OnMouseUp () 
	{
		if(GameManager.instance.GamePaused || 
		   GameManager.instance.controller.levelCompleted || 
		   GameManager.instance.controller.levelFailed) return;
		Debug.Log ("Clicked!");
		Debug.Log ("Mouse Position: " + Input.mousePosition);
		Vector3 v3 = Input.mousePosition;
		v3.z = 10;
		Vector3 pos = Camera.main.ScreenToWorldPoint (v3);
		endingPos = new Vector2 (pos.x, pos.y);
		Debug.Log ("Ending Position x: " + pos.x + " y: " + pos.y);
		weapon.shootArrow (startingPos-endingPos);
		bodyAnim.SetTrigger ("Shoot");
		bodyAnim.SetFloat ("Magnitude", 0);
	}
}
