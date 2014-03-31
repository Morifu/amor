using UnityEngine;
using System.Collections;

public class Bow : MonoBehaviour {

	/// <summary>
	/// The arrow prefab to link.
	/// </summary>
	public Rigidbody2D arrow;	// Prefab of the arrow.
	Rigidbody2D arrowInstance;
	/// <summary>
	/// Speed of the arrow shot
	/// </summary>
	public float speed = 5;		

	bool arrowShot = false;

	void Start()
	{
		arrowInstance = Instantiate(arrow, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
		arrowInstance.transform.parent = transform;
		arrowInstance.transform.rotation = transform.rotation;
		arrowInstance.isKinematic = true;
	}

	void Update()
	{

	}

	public void shootArrow( Vector2 direction )
	{
		arrowInstance.isKinematic = false;
		arrowInstance.velocity = direction*speed;
		arrowInstance.transform.parent = null;
		arrowShot = true;
		StartCoroutine (spawnArrow());
	}

	
	IEnumerator spawnArrow()
	{
		yield return new WaitForSeconds(2);
		if(arrowShot)
		{
			arrowInstance = Instantiate(arrow, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			arrowInstance.transform.parent = transform;
			arrowInstance.transform.rotation = transform.rotation;
			arrowInstance.isKinematic = true;
			arrowShot = false;
		}
	}
}
