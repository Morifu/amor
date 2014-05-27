using UnityEngine;
using System.Collections;

public class MeetingPoint : MonoBehaviour {

	public int loverCount = 0;
	public string nextLevel;
	public int levelNumber;
	public bool completesLevel = false;
	public GameObject[] lovers;
	ParticleSystem partikle;
	public float winDelay = 5f;

	public AudioClip extraPairSound;

	void Start()
	{
		if(completesLevel)
		{
			GameManager.instance.controller.LevelStart ();
			// just to be sure lets set current level number
			GameManager.instance.controller.currentLvl = levelNumber-1; 
		}
		partikle = GetComponentInChildren<ParticleSystem> ();
		if(partikle != null)
		{
			partikle.renderer.sortingLayerName = "inFront";
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
			Invoke("LevelCompleted",winDelay);
			GameManager.instance.controller.setNextLevel(levelNumber);
			AudioHelper.CreatePlayAudioObject(extraPairSound);
			partikle.Play();
			//Application.LoadLevel (nextLevel);
		}
		else if( loverCount == 2 && !completesLevel)
		{
			GameManager.instance.controller.extraPair = true;
			AudioHelper.CreatePlayAudioObject(extraPairSound);
		}
	}

	void LevelCompleted()
	{
		GameManager.instance.controller.LevelCompleted ();
	}
}
