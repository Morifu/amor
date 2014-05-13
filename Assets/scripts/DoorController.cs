using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
	
	public bool opened = false;

	public Lever.State[] leverProperStates;
	public Lever[] levers;
	public AudioClip openSound;

	SpriteRenderer odrzwiaSprite;
	BoxCollider2D ramaCollider;

	// Use this for initialization
	void Start () {
		odrzwiaSprite = transform.FindChild("odrzwia").GetComponent<SpriteRenderer> ();
		ramaCollider = GetComponent<BoxCollider2D> ();
		if(ramaCollider == null)
			ramaCollider = GetComponentInChildren<BoxCollider2D>();
	}

	void Update()
	{
		if(opened) return;

		bool shouldOpen = true;
		for ( int i = 0; i < levers.Length && shouldOpen ; i++)
		{
			if(levers[i].getState() != leverProperStates[i])
				shouldOpen = false;
		}
		if(shouldOpen)
		{
			odrzwiaSprite.enabled = true;
			ramaCollider.enabled = false;
			opened = true;
			AudioHelper.CreatePlayAudioObject(openSound);
		}
	}

//	void OnCollisionEnter2D(Collision2D other) 
//	{
//		if (!Shooted) 
//		{
//			if (other.gameObject.tag == "Arrow") 
//			{
//				Opened = true;
//				Shooted=true;
//
//			}
//		}
//	}
}
