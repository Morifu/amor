using UnityEngine;
using System.Collections;

public class MeetingPoint : MonoBehaviour {

	public int loverCount = 0;
	public string nextLevel;
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Lover")
			loverCount++;
		
		Debug.Log ("LoverCount: " + loverCount);
		if (loverCount == 2)
		{
			GameManager.instance.controller.UpdateData();
			Application.LoadLevel (nextLevel);
		}
	}
}
