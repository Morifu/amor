using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {

	Animator anim;
	public AudioClip leverSound;

	// public for other classes
	[HideInInspector]
	public enum State { OFF = 0, ON };
	bool clearToShot = true;

	public State currentState;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		anim.SetInteger("State",(int)currentState);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if((other.gameObject.CompareTag("Box") ||
		    other.gameObject.CompareTag("Arrow") ) && clearToShot)
		{
			if(currentState == State.ON)
				currentState = State.OFF;
			else
				currentState = State.ON;

			anim.SetInteger("State",(int)currentState);
			clearToShot = false;
			AudioHelper.CreatePlayAudioObject(leverSound);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		clearToShot = true;
	}

	public State getState() 
	{
		return currentState;
	}
}
