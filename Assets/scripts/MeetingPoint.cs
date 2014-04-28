using UnityEngine;
using System.Collections;

public class MeetingPoint : MonoBehaviour {

	public int loverCount = 0;
	public string nextLevel;
	public int levelNumber;
	public bool completesLevel = false;
	public GameObject[] lovers;

	void Start()
	{
		if(completesLevel)
		{
			GameManager.instance.controller.LevelStart ();
			// just to be sure lets set current level number
			GameManager.instance.controller.currentLvl = levelNumber-1; 
		}
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

		if (loverCount == 2 && completesLevel && !GameManager.instance.controller.levelCompleted)
		{
			GameManager.instance.controller.LevelCompleted();
			GameManager.instance.controller.setNextLevel(levelNumber);
			//Application.LoadLevel (nextLevel);
		}
		else if( loverCount == 2 && !completesLevel)
		{
			GameManager.instance.controller.extraPair = true;
		}
	}
}
