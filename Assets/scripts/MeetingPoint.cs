using UnityEngine;
using System.Collections;

public class MeetingPoint : MonoBehaviour {

	public int loverCount = 0;
	public string nextLevel;
	public int levelNumber;
	public bool completesLevel = true;
	public GameObject[] lovers;

	void Start()
	{
		if(completesLevel)
			GameManager.instance.controller.LevelStart ();
	}
	
	void OnTriggerEnter2D(Collider2D other) 
	{
//		if (other.gameObject.tag == "Lover")
//			loverCount++;
//		
		if(lovers.Length > 0)
		if (other.gameObject.Equals (lovers [0]) 
		    || other.gameObject.Equals (lovers [1]))
		{
			Debug.Log("IT WORKS");
			other.gameObject.GetComponent<LoverController>().LockLover();
			loverCount++;
		}

		if (loverCount == 2 && completesLevel)
		{
			GameManager.instance.controller.LevelCompleted();
			GameManager.instance.controller.setNextLevel(levelNumber);
			Application.LoadLevel (nextLevel);
		}
	}
}
