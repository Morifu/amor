using UnityEngine;
using System.Collections;

public class MeetingPoint : MonoBehaviour {

	public int loverCount = 0;
	public string nextLevel;
	public int levelNumber;
	public bool completesLevel = false;
	public GameObject[] lovers;
	ArrayList loverLocked = null;
	ParticleSystem partikle;
	public float winDelay = 3f;
	bool meetingCompleted = false;

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
		if (loverLocked == null)
			loverLocked = new ArrayList (2);
	}
	
	void OnTriggerEnter2D(Collider2D other) 
	{
//		if (other.gameObject.tag == "Lover")
//			loverCount++;
//		
		if(meetingCompleted) return;

		if(lovers.Length > 0)
		if (other.gameObject.Equals (lovers [0]) 
		    || other.gameObject.Equals (lovers [1]))
		{
			if(!loverLocked.Contains(other))
			{
				Debug.Log("IT WORKS");
				other.gameObject.GetComponent<LoverController>().LockLover();
				loverCount++;
				loverLocked.Add(other);
			}
		}

		if (loverCount == 2 && completesLevel && !GameManager.instance.controller.levelCompleted)
		{
			Invoke("LevelCompleted",winDelay);
			GameManager.instance.controller.setNextLevel(levelNumber);
			AudioHelper.CreatePlayAudioObject(extraPairSound);
			partikle.Play();
			meetingCompleted = true;
			//Application.LoadLevel (nextLevel);
		}
		else if( loverCount == 2 && !completesLevel)
		{
			GameManager.instance.controller.extraPair = true;
			AudioHelper.CreatePlayAudioObject(extraPairSound);
			meetingCompleted = true;
		}
	}

	void LevelCompleted()
	{
		GameManager.instance.controller.LevelCompleted ();
	}
}
