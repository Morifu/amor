using UnityEngine;
using System.Collections;

public class StateChanger : MonoBehaviour {

	public bool activated = false;

	public Lever.State[] leverProperStates;
	public Lever[] levers;

	public bool turnOffColliders = false;
	public bool turnOffObject = false;
	public bool changeTransform = false;
	public Transform transformToApply;
	
//	// Use this for initialization
//	void Start () {
//
//	}
	
	void Update()
	{
		if(activated) this.enabled = false;
		
		bool shouldOpen = true;
		for ( int i = 0; i < levers.Length && shouldOpen ; i++)
		{
			if(levers[i].getState() != leverProperStates[i])
				shouldOpen = false;
		}
		if(shouldOpen)
		{
			if(turnOffColliders)
			{
				collider2D.enabled = false;
			}
			if(turnOffObject)
			{
				gameObject.SetActive(false);
			}
			if(changeTransform)
			{
				transform.position = transformToApply.position;
				transform.localScale = transformToApply.localScale;
				transform.rotation = transformToApply.rotation;
			}
		}
	}
}
