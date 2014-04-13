using UnityEngine;
using System.Collections;

public class MeetingPoint : MonoBehaviour {

	public int loverCount = 0;
	public string nextLevel;
	public int levelNumber;

	void Start()
	{
		GameManager.instance.controller.LevelStart ();
	}
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Lover")
			loverCount++;
		
		Debug.Log ("LoverCount: " + loverCount);
		if (loverCount == 2)
		{
			GameManager.instance.controller.LevelCompleted();
			GameManager.instance.controller.setNextLevel(levelNumber);
			Application.LoadLevel (nextLevel);
		}
	}
}
