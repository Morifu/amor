using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Bow weapon; // reference to bow of player

	Vector2 startingPos;
	Vector2 endingPos;

	Transform upperBody;

	Animator legAnim, bodyAnim, arrowAnim;

	bool flippedCharacter = false; // if we should flip the player

	public float maxAngle = 70;
	// Use this for initialization
	void Start () {

		upperBody = transform.FindChild("UpperBody");
		weapon = upperBody.FindChild ("Bow").GetComponent<Bow> ();
		startingPos = new Vector2(transform.position.x,transform.position.y+0.5f);
		bodyAnim = upperBody.GetComponentInChildren<Animator> ();
		arrowAnim = weapon.GetComponentInChildren<Animator> ();
		arrowAnim.SetFloat ("Magnitude", 0);
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

		int sign = (startingPos.x > pos.x) ? 1 : -1;
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

		Debug.Log ("magnitude : " + v2.magnitude);
		bodyAnim.SetFloat ("Magnitude", v2.magnitude);
		arrowAnim.SetFloat ("Magnitude", v2.magnitude);
		v2.Normalize ();
		// we don't need rotation on x and y within 2D space
		Quaternion rot = Quaternion.LookRotation (v2);
		rot.x = 0;
		rot.y = 0;
		float cosz = Mathf.Cos (rot.eulerAngles.z*Mathf.Deg2Rad); 
		rot.z *= transform.localScale.x;
		//Debug.Log ("Cosinus z : " + cosz+" Cosinus 70 : "+maxAngle + " rotz: "+rot.eulerAngles.z);
		if(cosz > Mathf.Cos (maxAngle*Mathf.Deg2Rad))
			upperBody.rotation = rot;

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
		Vector2 direction = startingPos - endingPos;
		bool canshoot = false;
		if(direction.magnitude > 0.25f)
			canshoot = true;
	
		float tanmax = Mathf.Tan (maxAngle * Mathf.Deg2Rad);
		//Debug.Log("Tan konta "+tanmax);
		if(Mathf.Abs( direction.y/direction.x) > tanmax)
		{
			direction.x = 1*Mathf.Sign(direction.x);
			direction.y = tanmax*Mathf.Sign(direction.y);
		}

		//Debug.Log ("y do x : " + direction.y / direction.x);
//		if (direction.y > Mathf.Tan (maxAngle * Mathf.Deg2Rad))
//						direction.y = Mathf.Tan (maxAngle * Mathf.Deg2Rad);
		//endingPos.Normalize ();
		//Debug.Log ("Ending Position x: " + endingPos.x + " y: " + endingPos.y);
		Debug.Log ("Direction magnitude : " + direction.magnitude);
		if(canshoot)
		{
			weapon.shootArrow (direction);
			bodyAnim.SetTrigger ("Shoot");
		}
		bodyAnim.SetFloat ("Magnitude", 0);
		arrowAnim.SetFloat ("Magnitude", 0);
	}
}
