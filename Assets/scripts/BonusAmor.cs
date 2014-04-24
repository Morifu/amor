using UnityEngine;
using System.Collections;

public class BonusAmor : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) 
	{

		GameManager.instance.controller.bonusCollected = true;
		Destroy(gameObject);
	} 
}
