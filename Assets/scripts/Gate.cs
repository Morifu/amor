using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

	public bool opened = false;
	
	public Lever.State[] leverProperStates;
	public Lever[] levers;

	public GameObject destination;

	GameObject kraty;
	// Use this for initialization
	void Start () {
		kraty = transform.FindChild ("kraty_brama").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(opened) return;
		
		bool shouldOpen = true;
		for ( int i = 0; i < levers.Length && shouldOpen ; i++)
		{
			if(levers[i] == null || levers[i].getState() != leverProperStates[i])
				shouldOpen = false;
		}
		if(shouldOpen)
		{
			kraty.SetActive(false);
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		coll.transform.position = destination.transform.position;
	}
}
