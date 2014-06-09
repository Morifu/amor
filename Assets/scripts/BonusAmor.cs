using UnityEngine;
using System.Collections;

public class BonusAmor : MonoBehaviour {

	public AudioClip hitSound;

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if(coll.gameObject.CompareTag("Arrow"))
		{
			Destroy(coll.gameObject);
		}
		AudioHelper.CreatePlayAudioObject (hitSound);
		GameManager.instance.controller.bonusCollected = true;
		Destroy(gameObject);

	} 
}
